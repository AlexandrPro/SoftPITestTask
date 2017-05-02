namespace LogParser.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogModel : DbContext
    {
        public LogModel()
            : base("name=LogModel")
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<HTTPMethod> HTTPMethods { get; set; }
        public virtual DbSet<IPAdress> IPAdresses { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IPAdress>()
                .HasMany(e => e.Logs)
                .WithOptional(e => e.IPAdress1)
                .HasForeignKey(e => e.IPAdress);
        }
    }
}
