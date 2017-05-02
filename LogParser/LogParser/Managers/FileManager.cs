using System;
using System.Linq;
using LogParser.Entity;

namespace LogParser.Managers
{
    public class FileManager
    {
        LogModel db = new LogModel();
        public FileManager() { }

        public int GetId(string filePathAndName, int size)
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

        private int CreateFile(string filePathAndName, int size)
        {
            File file = db.Files.Add(new File()
            {
                PathAndName = filePathAndName,
                Size = size
            });
            db.SaveChanges();
            return file.Id;
        }
    }
}
