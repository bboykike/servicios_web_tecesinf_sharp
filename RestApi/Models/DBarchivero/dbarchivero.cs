namespace RestApi.Models.DBarchivero
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbarchivero : DbContext
    {
        public dbarchivero()
            : base("name=dbarchivero")
        {
        }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<ImagenesSE> ImagenesSE { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public System.Data.Entity.DbSet<RestApi.Models.HistorialSE> HistorialSEs { get; set; }
    }
}
