using System;
using System.Linq;
using LogParser.Entity;
using LogParser.WebSiteRequest;
using System.Text.RegularExpressions;

namespace LogParser.Managers
{
    public class FileManager
    {
        LogModel db = new LogModel();
        public FileManager() { }

        public int GetId(string filePathAndName, int size)
        {
            if (isHtml(filePathAndName))
            {
                File file = db.Files.Where(f => f.PathAndName == filePathAndName).FirstOrDefault();
                if (file != null)
                {
                    return file.Id;
                }
                else
                {
                    return CreateFile(filePathAndName, size);
                }
            }
            else
                return -1;
        }

        private int CreateFile(string filePathAndName, int size)
        {
            File file = db.Files.Add(new File()
            {
                PathAndName = filePathAndName,
                PageName = MainSite.GetDocHendler(filePathAndName),
                Size = size
            });
            db.SaveChanges();
            return file.Id;
        }

        private bool isHtml(string str)
        {
            string pattern1 = @"(\S*\\)$";
            string pattern2 = @"(\S*\.html)$";

            if(Regex.IsMatch(str, pattern1) || Regex.IsMatch(str, pattern2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
