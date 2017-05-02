using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }

        public string IPAdress { get; set; }

        public string IPCompanyName { get; set; }

        public DateTimeOffset? Time { get; set; }

        public string PageName { get; set; }

        public string HTTPMethod { get; set; }

        public int? HTTPStatus { get; set; }
    }
}