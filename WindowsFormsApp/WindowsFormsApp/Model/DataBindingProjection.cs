using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Model
{
    class DataBindingProjection
    {
        public string IPAdress { get; set; }

        public string IPAdressCompanyName { get; set; }

        public string FileTitle { get; set; }

        public string PathAndName { get; set; }

        public string HTTPMethod { get; set; }

        public int? HTTPStatus { get; set; }
    }
}
