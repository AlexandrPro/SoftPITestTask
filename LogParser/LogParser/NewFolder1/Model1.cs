namespace LogParser.NewFolder1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
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
