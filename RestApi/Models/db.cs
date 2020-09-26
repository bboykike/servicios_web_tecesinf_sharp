namespace RestApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db : DbContext
    {
        internal object historico_CorreoSE;

        public db()
            : base("name=db")
        {
        }

        public  DbSet<Accesorios> Accesorios { get; set; }
        public  DbSet<Clientes> Clientes { get; set; }
        public  DbSet<DetallesUs> DetallesUs { get; set; }
        public  DbSet<Equipos> Equipos { get; set; }
        public  DbSet<Historial> Historial { get; set; }
        public  DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public  DbSet<StatusServicio> StatusServicio { get; set; }
        public  DbSet<StatusUsuario> StatusUsuario { get; set; }
        public DbSet<StatusEquipo> StatusEquipo { get; set; }
        public  DbSet<StCliente> StCliente { get; set; }
        public  DbSet<Sucursales> Sucursales { get; set; }
        public  DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<StatusSe> StatusSe { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<ServiciosSE> ServiciosSE { get; set; }
        public DbSet<HistorialSE> HistorialSE { get; set; }
        public DbSet<InformeTec> InformeTec { get; set; }
        public DbSet<InformeTecSE> InformeTecSE { get; set; }
        public DbSet<historico_correoSE> historico_correoSEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Accesorios>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Accesorios>()
            //    .Property(e => e.Marca)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Accesorios>()
            //    .Property(e => e.NoSerie)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Accesorios>()
            //    .HasMany(e => e.Equipos)
            //    .WithRequired(e => e.Accesorios)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.RFC)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Cliente1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Contacto)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Telefono)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Celular)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Estado)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Ciudad)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Observaciones)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.Sucursales)
            //    .WithRequired(e => e.Cliente)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.StCliente)
            //    .WithRequired(e => e.Cliente)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.Servicios)
            //    .WithRequired(e => e.Cliente)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .Property(e => e.Apellido)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .Property(e => e.Area)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .Property(e => e.FotoUsuario)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .HasMany(e => e.Usuarios)
            //    .WithRequired(e => e.DetallesUs)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DetallesUs>()
            //    .HasMany(e => e.StatusUsuario)
            //    .WithRequired(e => e.DetallesUs)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.TipoEquipo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.NomEquipo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.Marca)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.Modelo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.NoSerie)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .Property(e => e.FuncionStatus)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Equipos>()
            //    .HasMany(e => e.Historial)
            //    .WithRequired(e => e.Equipos)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Evidencias>()
            //    .Property(e => e.FotoEvidencia)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Historial>()
            //    .Property(e => e.Comentario)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Module>()
            //    .Property(e => e.ModuleName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Module>()
            //    .HasMany(e => e.ModuleRol)
            //    .WithRequired(e => e.Module)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Module>()
            //    .HasMany(e => e.PermissionRol)
            //    .WithRequired(e => e.Module)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ModuleRol>()
            //    .HasMany(e => e.Roles)
            //    .WithRequired(e => e.ModuleRol)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PermissionRol>()
            //    .HasMany(e => e.PermisoAcceso)
            //    .WithRequired(e => e.PermissionRol)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Permissions>()
            //    .Property(e => e.PermissionName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Permissions>()
            //    .HasMany(e => e.PermissionRol)
            //    .WithRequired(e => e.Permissions)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Presupuestos>()
            //    .Property(e => e.Cliente)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Presupuestos>()
            //    .Property(e => e.Articulo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Presupuestos>()
            //    .Property(e => e.Comentario)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Presupuestos>()
            //    .HasMany(e => e.StatusPre)
            //    .WithRequired(e => e.Presupuestos)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Roles>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Roles>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Roles>()
            //    .HasMany(e => e.PermisoAcceso)
            //    .WithRequired(e => e.Roles)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Roles>()
            //    .HasMany(e => e.Usuarios)
            //    .WithRequired(e => e.Roles)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Servicios>()
            //    .Property(e => e.Tipo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Servicios>()
            //    .Property(e => e.Problema)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Servicios>()
            //    .HasMany(e => e.Evidencias)
            //    .WithRequired(e => e.Servicios)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Servicios>()
            //    .HasMany(e => e.Historial)
            //    .WithRequired(e => e.Servicios)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Servicios>()
            //    .HasMany(e => e.StatusServicio)
            //    .WithRequired(e => e.Servicios)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<StatusServicio>()
            //    .Property(e => e.NombreStatus)
            //    .IsUnicode(false);

            //modelBuilder.Entity<StatusUsuario>()
            //    .Property(e => e.status)
            //    .IsUnicode(false);

            //modelBuilder.Entity<StCliente>()
            //    .Property(e => e.Status)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Sucursales>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Sucursales>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Sucursales>()
            //    .HasMany(e => e.Equipos)
            //    .WithRequired(e => e.Sucursales)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Usuarios>()
            //    .Property(e => e.Contraseña)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuarios>()
            //    .Property(e => e.Usuario)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Usuarios>()
            //    .HasMany(e => e.Presupuestos)
            //    .WithRequired(e => e.Usuarios)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Usuarios>()
            //    .HasMany(e => e.Servicios)
            //    .WithRequired(e => e.Usuarios)
            //    .WillCascadeOnDelete(false);
        }
    }
}
