namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roles
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Roles()
        //{
        //    PermisoAcceso = new HashSet<PermisoAcceso>();
        //    Usuarios = new HashSet<Usuarios>();
        //}

        [Key]
        public int IDrol { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        //public virtual ModuleRol ModuleRol { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PermisoAcceso> PermisoAcceso { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
