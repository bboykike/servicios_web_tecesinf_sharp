namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Usuarios()
        //{
        //    Presupuestos = new HashSet<Presupuestos>();
        //    Servicios = new HashSet<Servicios>();
        //}

        [Key]
        public int IDusuario { get; set; }

        [Required]
        [StringLength(15)]
        public string UserName { get; set; }

        [Required]
        public string Pass { get; set; }

        public int IDdetalle { get; set; }

        public int IDrol { get; set; }

        //public virtual DetallesUs DetallesUs { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Presupuestos> Presupuestos { get; set; }

        //public virtual Roles Roles { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Servicios> Servicios { get; set; }
    }
}
