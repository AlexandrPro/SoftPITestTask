using System.IO;

namespace LogParser.FileOutput
{
    public class LogFile
    {
        StreamReader file;
        public LogFile(string path)
        {
            file = new StreamReader(path);
        }

        public string NextLine()//return null if end of file
        {
            return file.ReadLine();
        }
    }
}
