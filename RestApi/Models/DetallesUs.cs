namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetallesUs
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public DetallesUs()
        //{
        //    Usuarios = new HashSet<Usuarios>();
        //    StatusUsuario = new HashSet<StatusUsuario>();
        //}

        [Key]
        public int IDdetalle { get; set; }

        [Required]
        [StringLength(35)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(35)]
        public string Apellido { get; set; }

        [StringLength(80)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Area { get; set; }

        [StringLength(70)]
        public string FotoUsuario { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Usuarios> Usuarios { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StatusUsuario> StatusUsuario { get; set; }
    }
}
