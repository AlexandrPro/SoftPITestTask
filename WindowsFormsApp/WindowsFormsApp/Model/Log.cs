namespace WindowsFormsApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int Id { get; set; }

        [StringLength(16)]
        public string IPAdress { get; set; }

        public DateTimeOffset? Time { get; set; }

        public int? FileId { get; set; }

        public int? HTTPMethodId { get; set; }

        public int? HTTPStatus { get; set; }

        public virtual File File { get; set; }

        public virtual HTTPMethod HTTPMethod { get; set; }

        public virtual IPAdress IPAdress1 { get; set; }
    }
}
