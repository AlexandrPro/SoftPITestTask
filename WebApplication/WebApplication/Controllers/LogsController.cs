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
        public ActionResult Index(int? method)
        {
            var logs = db.Logs.Include(l => l.File).Include(l => l.HTTPMethod).Include(l => l.IPAdress1);
            if(method != null)
            {
                logs = logs.Where(l => l.HTTPMethodId == method);
            }

            List<HTTPMethod> httpMethods = db.HTTPMethods.ToList();
            httpMethods.Insert(0, new HTTPMethod { Name = "All", Id = 0 });

            LogListViewModel llvm = new LogListViewModel
            {
                Logs = logs.ToList(),
                HTTPMethods = new SelectList(httpMethods, "Id", "Name")
            };
            return View(llvm);
            /*
            var logs = db.Logs.Include(l => l.File).Include(l => l.HTTPMethod).Include(l => l.IPAdress1);
            return View(logs.ToList());
            */
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
