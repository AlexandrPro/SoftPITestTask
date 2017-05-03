using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class LogListViewModel
    {
        public IEnumerable<Log> Logs { get; set; }
        public SelectList HTTPMethods { get; set; }
    }
}