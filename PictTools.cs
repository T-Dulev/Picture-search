using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ExifLib;

namespace Picture_search
{
    class PictTools
    {
    }

    public class ExifParser
    {
        // взето от https://codereview.stackexchange.com/questions/77453/c-photo-sorter

        public static DateTime getTakenDateTime(string filePath)
        {
            try
            {
                ExifReader reader = new ExifReader(filePath);
                DateTime datePictureTaken;
                if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                {
                    reader.Dispose();
                    return datePictureTaken;
                }
                else
                {
                    reader.Dispose();
                    return new DateTime(0001, 01, 01); //The FolderPath builder will recognize a date as 0001 for the year as an error and build a path to the error folder!
                }
            }
            catch
            {
                return File.GetCreationTime(filePath);
            }
        }

    }

}
