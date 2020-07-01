using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Picture_search
{
    public partial class MainForm : Form
    {

        FileDelegate DateFilter;
        string FileData = "I:\\FileData.txt";

        public Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();

        public MainForm()
        {
            InitializeComponent();

            DateFilter = GetFileDateFilter();

            List<string> files = new List<string>();

            if (File.Exists(FileData))
            {
                //load files info
                var text = File.ReadAllLines(FileData, Encoding.Default);


                for (var i = 0; i < text.Length; i += 2)
                {
                    dict.Add(text[i], Convert.ToDateTime(text[i + 1]));
                }
            }

            lblDataInfo.Text = "Saved file info for " + dict.Count() + " files";
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
                Cursor.Current = Cursors.WaitCursor;
                long totalSize = 0;

                listProgress.Items.Clear();

                var currentPath = lblSearchFolder.Text;
                var folderStat = GetAllFilesStat(currentPath, 0, "*.jpg");
                lblCurrFolder.Text = "";
                lblCurrFolder.Refresh();

                if (folderStat.FilesCount > 0)
                {
                }

                // save files info
                var files = new List<string>();
                foreach (var item in dict)
                {
                    files.Add(item.Key);
                    files.Add(item.Value.ToString());
                }
                File.WriteAllLines(FileData, files, Encoding.Default);

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

                foreach (var item in files)
                {
                    if (!dict.ContainsKey(item.FullName))
                    {
                        dict.Add(item.FullName, ExifParser.getTakenDateTime(item.FullName));
                        lblDataInfo.Text = "Saved file info for " + dict.Count() + " files";
                        lblDataInfo.Refresh();
                    }
                }

                var fl = files.Where(x => DateFilter(x));
                var currFiles = new List<FileInfo>();
                currFiles.AddRange(fl);

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
                try
                {
                    FileStream fs = new FileStream(pict, FileMode.Open, FileAccess.Read);
                    picPreview.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
                catch
                { }
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
                        if (checkAfter.Checked)
                        {
                            return delegate(FileInfo x)
                            {
                                DateTime y = dict[x.FullName];
                                return (dateTimePicker.Value.Date.CompareTo(y)<=0);
                            };
                        }
                        else
                        {
                            return delegate(FileInfo x)
                            {
                                //var y = ExifParser.getTakenDateTime(x.FullName);
                                DateTime y = dict[x.FullName];
                                return (y.Year == year) && (y.Month == month) && (y.Day == day);
                            };
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
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
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
                            return (y.Year == year) && (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
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
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
                            return (y.Month == month) && (y.Day == day);
                        };
                    }
                    else
                    {
                        return delegate(FileInfo x)
                        {
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
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
                            //var y = ExifParser.getTakenDateTime(x.FullName);
                            DateTime y = dict[x.FullName];
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

        private void ShowAfter()
        {
            checkAfter.Visible = (checkYear.Checked) && (checkMonth.Checked) && (checkDay.Checked);
        }
        private void checkDay_CheckedChanged(object sender, EventArgs e)
        {
            ShowAfter();
            DateFilter = GetFileDateFilter();
        }

        private void checkMonth_CheckedChanged(object sender, EventArgs e)
        {
            ShowAfter();
            DateFilter = GetFileDateFilter();
        }

        private void checkYear_CheckedChanged(object sender, EventArgs e)
        {
            ShowAfter();
            DateFilter = GetFileDateFilter();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateFilter = GetFileDateFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string pict = listProgress.FocusedItem.Text;

            if (File.Exists(pict))
            {
                var list = new StringCollection();
                list.Add(pict);
                Clipboard.SetFileDropList(list);
            }
        }

        private void buttonCopyBMP_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(picPreview.Image);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var half = dict.Count / 2;

            for (int i = 0; i < half; i++)
			{
                dict.Remove(dict.Keys.First()); 
			}

            // save files info
            var files = new List<string>();
            foreach (var item in dict)
            {
                files.Add(item.Key);
                files.Add(item.Value.ToString());
            }
            File.WriteAllLines(FileData, files, Encoding.Default);
            lblDataInfo.Text = "Saved file info for " + dict.Count() + " files";
        }

    }
}
