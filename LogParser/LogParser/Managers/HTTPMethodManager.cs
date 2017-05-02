using System;
using System.Linq;
using LogParser.Entity;

namespace LogParser.Managers
{
    public class HTTPMethodManager
    {
        LogModel db = new LogModel();
        public HTTPMethodManager() { }

        public int GetId(string methodName)
        {
            try
            {
                HTTPMethod method = db.HTTPMethods.Where(m => m.Name == methodName).First();
                if (method != null)
                {
                    return method.Id;
                }
                else throw new ArgumentException("String \"" + methodName + "\" has not name of HTTP method!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("ОШИБКА!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Возникла при попытке найти HTTP метод:");
                Console.WriteLine(methodName);
                return -1;
            }
        }
    }
}
