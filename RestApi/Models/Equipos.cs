namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipos
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Equipos()
        //{
        //    Historial = new HashSet<Historial>();
        //}

        [Key]
        public int IDequipo { get; set; }

        [Required]
        [StringLength(25)]
        public string TipoEquipo { get; set; }

        [Required]
        [StringLength(25)]
        public string Marca { get; set; }

        [StringLength(30)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(35)]
        public string NoSerie { get; set; }


        public int IDsucursal { get; set; }

        //public virtual Accesorios Accesorios { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Historial> Historial { get; set; }

        //public virtual Sucursales Sucursales { get; set; }
    }
}
