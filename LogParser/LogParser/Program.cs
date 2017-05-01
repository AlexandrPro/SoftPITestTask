using LogParser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LogModel db = new LogModel())
            {

                Log log = new Log()
                {
                    IPAdress = "51.255.65.5",
                    Time = DateTime.Now,
                    FileId = 1,
                    HTTPMethodId = 1,
                    HTTPStatus = 1
                };
                db.Logs.Add(log);
                db.SaveChanges();
            }

            using (LogModel db = new LogModel())
            {
                List<Log> items = db.Logs.ToList();
                foreach (Log item in items)
                {
                    Console.WriteLine(item.IPAdress);
                }
            }
            Console.WriteLine("all done");
            Console.ReadKey();
        }
    }
}
