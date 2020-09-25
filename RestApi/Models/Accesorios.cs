namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography.X509Certificates;

    public partial class Accesorios
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Accesorios()
        //{
        //    Equipos = new HashSet<Equipos>();
        //}

        [Key]
        public int IDaccesorio { get; set; }

        [StringLength(25)]
        public string Nombre { get; set; }

        [StringLength(25)]
        public string Marca { get; set; }

        [StringLength(30)]
        public string NoSerie { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        public int IDequipo { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
