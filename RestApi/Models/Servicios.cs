namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Servicios
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Servicios()
        //{
        //    Evidencias = new HashSet<Evidencias>();
        //    Historial = new HashSet<Historial>();
        //    StatusServicio = new HashSet<StatusServicio>();
        //}

        [Key]
        public int IDservicio { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }
        [StringLength(50)]
        public string FechaIn { get; set; }

        public string Problema { get; set; }

        public int? Encargado { get; set; }

        public int IDusuario { get; set; }

        public int IDcliente { get; set; }

        public int IDequipo { get; set; }

        public DateTime fechaRegistro { get; set; }

        //public virtual Cliente Cliente { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Evidencias> Evidencias { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Historial> Historial { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StatusServicio> StatusServicio { get; set; }

        //public virtual Usuarios Usuarios { get; set; }
    }
}
