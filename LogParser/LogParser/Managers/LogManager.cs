using System;
using LogParser.Entity;

namespace LogParser.Managers
{
    public class LogManager
    {
        LogModel db = new LogModel();
        public LogManager() { }

        public void Add(string ip, DateTimeOffset time, int fileId, 
            int httpMethodId, int httpStatus)
        {
            Log log = new Log()
            {
                IPAdress = ip,
                Time = time,
                FileId = fileId,
                HTTPMethodId = httpMethodId,
                HTTPStatus = httpStatus
            };
            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}
