using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LogsController : Controller
    {
        private LogModel db = new LogModel();

        // GET: Logs
        public ActionResult Index()
        {
            var logs = db.Logs.Include(l => l.File).Include(l => l.HTTPMethod).Include(l => l.IPAdress1);
            return View(logs.ToList());
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
