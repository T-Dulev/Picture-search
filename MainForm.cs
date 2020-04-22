using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_search
{
    public partial class MainForm : Form
    {

        FileDelegate DateFilter;

                
        public MainForm()
        {
            InitializeComponent();

            DateFilter = GetFileDateFilter();
           
        }

        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            var folder = new FolderBrowserDialog();

            folder.ShowDialog();
            if (folder.SelectedPath != "")
            {
                lblSearchFolder.Text = folder.SelectedPath;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lblSearchFolder.Text != "")
            {
                string FileData = "FileData.txt";

                Cursor.Current = Cursors.WaitCursor;
                long totalSize = 0;

                listProgress.Items.Clear();

                var currentPath = lblSearchFolder.Text;
                var folderStat = GetAllFilesStat(currentPath, 0, "*.jpg");
                lblCurrFolder.Text = "";
                lblCurrFolder.Refresh();

                //var text = File.ReadAllLines(FileData, Encoding.Default);

                //for (var i = 0; i < values.Length; i += 2)
                //{
                //    deserts.Add(int.Parse(values[i]), values[i + 1]);
                //}

                if (folderStat.FilesCount > 0)
                {
                    List<string> files = new List<string>();
                    var dict = new Dictionary<string, string>();

                    foreach (var item in folderStat.FileList)
                    {
                        //        listProgress.Items.Add(new ListViewItem(new[] { item.FullName, ((int)item.Length / 1024 / 1024).ToString(), ExifParser.getTakenDateTime(item.FullName).ToString() }));
                        //        listProgress.Refresh();

                        //        listProgress.Items[listProgress.Items.Count - 1].EnsureVisible();
                        var fileDate = ExifParser.getTakenDateTime(item.FullName).ToString();
                        files.Add(item.FullName);
                        files.Add(fileDate);

                        dict.Add(item.FullName, fileDate);
                    }

                    //var values = files.ToArray();

                    //Dictionary<string, string> dict = 
                    //    //(
                    //    //from p in arr
                    //    //where index % 2 == 0 
                    //    //select new { p., Projects = g })

                    //    //arr.Where((x, index) => index % 2 == 0).ToDictionary(x => x, v => arr[arr.IndexOf(v) + 1]);
                    //values.Where((v,index) =>index % 2 == 0).ToDictionary(v => int.Parse(v), v => values[values.IndexOf(v) + 1]);

                    File.WriteAllLines(FileData, files, Encoding.Default);

                }
                totalSize += folderStat.Size;
                lblTotalFound.Text = "Found " + folderStat.FilesCount + " files, " + (long)totalSize / 1024 / 1024 / 1024 + " GB ";
                lblTotalFound.Refresh();

                Cursor.Current = Cursors.Default;
            }
        }

        delegate bool FileDelegate(FileInfo x);

        private DirInfo GetAllFilesStat(string path, int level, string pattern)
        {
            var resultSubfolders = new DirInfo();
            var directory = new DirectoryInfo(path);

            var result = new DirInfo();
            string pathSub = directory.Name;
            var parent = directory;

            result.FullPath = path;

            for (int i = 1; i <= level; i++)
            {
                parent = parent.Parent;
                if (parent.Parent != null)
                {
                    pathSub = parent.Name + "\\" + pathSub;
                }
                else
                {
                    pathSub = parent.Name[0] + "\\" + pathSub;
                }
            }

            try
            {
                var files = directory.GetFiles(pattern);

                var currFiles = files.Where(x => DateFilter(x));

                resultSubfolders.FileList.AddRange(currFiles);
                resultSubfolders.FilesCount += currFiles.Count();
                resultSubfolders.Size += currFiles.Select(x => x.Length).Sum();

                if (currFiles.Count() > 0)
                {
                    foreach (var item in currFiles)
                    {
                        listProgress.Items.Add(new ListViewItem(new[] { item.FullName, ((int)item.Length / 1024 / 1024).ToString(), ExifParser.getTakenDateTime(item.FullName).ToString() }));
                        listProgress.Refresh();

                        listProgress.Items[listProgress.Items.Count - 1].EnsureVisible();
                    }
                }

                var folders = directory.GetDirectories().ToList();
                foreach (var item in folders)
                {
                    if (item.Name != "System Volume Information" && item.Name != "$RECYCLE.BIN")
                    {
                        var folder = GetAllFilesStat(item.FullName, level + 1, pattern);
                        if (folder.FilesCount > 0)
                        {
                            resultSubfolders.FilesCount += folder.FilesCount;
                            resultSubfolders.FileList.AddRange(folder.FileList);
                            resultSubfolders.Size += folder.Size;
                        }
                    }
                }

            }
            catch
            {
                // some error reading directory
            }

            lblCurrFolder.Text = path;
            lblCurrFolder.Refresh();

            result.FileList = resultSubfolders.FileList;
            result.FilesCount = resultSubfolders.FilesCount;
            result.Size = resultSubfolders.Size;

            return result;
        }

        public class DirInfo
        {
            public string FullPath { get; set; }
            public long FilesCount { get; set; }
            public long Size { get; set; }
            public List<FileInfo> FileList { get; set; }

            public DirInfo()
            {
                FileList = new List<FileInfo>();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listProgress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pict = listProgress.FocusedItem.Text;

            if (File.Exists(pict))
            {
                FileStream fs = new FileStream(pict, FileMode.Open, FileAccess.Read);
                picPreview.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
        }


        private FileDelegate GetFileDateFilter()
        {
            int day = dateTimePicker.Value.Day;
            int month = dateTimePicker.Value.Month;
            int year = dateTimePicker.Value.Year;

            if (checkYear.Checked)
            {
                if (checkMonth.Checked)
                {
                    if (checkDay.Checked)
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Year == year) && (y.Month == month) && (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Year == year) && (y.Month == month);
                        };
                    }
                }
                else
                {
                    if (checkDay.Checked)
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Year == year) && (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Year == year);
                        };
                    }
                }
            }
            else
            {
                if (checkMonth.Checked)
                {
                    if (checkDay.Checked)
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Month == month) && (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Month == month);
                        };
                    }
                }
                else
                {
                    if (checkDay.Checked)
                    {
                        return delegate(FileInfo x)
                        {
                            var y = ExifParser.getTakenDateTime(x.FullName);
                            return (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            return false;
                        };
                    }
                }
            }
        }

        private void checkDay_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = GetFileDateFilter();
        }

        private void checkMonth_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = GetFileDateFilter();
        }

        private void checkYear_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = GetFileDateFilter();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateFilter = GetFileDateFilter();
        }

    }
}
