using System;
using System.Linq;
using LogParser.Entity;

namespace LogParser.Managers
{
    public class IPAdressManager
    {
        LogModel db = new LogModel();
        public IPAdressManager() { }

        public void AddIP(string ip)
        {
            IPAdress ipAdress = db.IPAdresses.Where(i => i.IP == ip).FirstOrDefault();
            if (ipAdress != null)
            {
                return;
            }
            else
            {
                CreateIPAdress(ip);
            }
        }

        private void CreateIPAdress(string ip)
        {
            db.IPAdresses.Add(new IPAdress()
            {
                IP = ip,
                NAme = "qwerty"
            });
            db.SaveChanges();
        }
    }
}
