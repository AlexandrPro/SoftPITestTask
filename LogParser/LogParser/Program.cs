using LogParser.Entity;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogParser.FileOutput;
using LogParser.Parsers;
using LogParser.Managers;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFile file = new LogFile(@"C:\Users\Aleks_000\Google Диск\Работа\Soft PI\task\tariscope.com.access.log.0");
            string str = "";
            HTTPMethodManager httpMethodManager = new HTTPMethodManager();
            FileManager fileManager = new FileManager();
            IPAdressManager ipAdressManager = new IPAdressManager();
            LogManager logManager = new LogManager();

            int i = 0;
            do
            {
                str = file.NextLine();
                if (str != null)
                {
                    string[] strs = LogStringParser.Split(str);

                    int fileId = fileManager.GetId(strs[3], Int32.Parse(strs[5]));
                    if (fileId > 0)
                    {
                        string ipAdress = strs[0];
                        ipAdressManager.AddIP(ipAdress);
                        int httpMethodId = httpMethodManager.GetId(strs[2]);
                        DateTimeOffset dateTime = DateTimeOffset.Parse(strs[1]);
                        int httpStatus = Int32.Parse(strs[4]);

                        logManager.Add(ipAdress, dateTime, fileId, httpMethodId, httpStatus);
                    }
                }
                else break;
                Console.WriteLine(i++);
            }
            while (str != null /*&& i<20*/);
            Console.WriteLine("all done");
            Console.ReadKey();
        }
    }
}
