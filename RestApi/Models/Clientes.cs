namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clientes")]
    public partial class Clientes
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Cliente()
        //{
        //    Sucursales = new HashSet<Sucursales>();
        //    StCliente = new HashSet<StCliente>();
        //    Servicios = new HashSet<Servicios>();
        //}

        [Key]
        public int IDcliente { get; set; }

        [Required]
        [StringLength(30)]
        public string RFC { get; set; }

        [Required]
        [StringLength(80)]
        public string Cliente { get; set; } //Aqui tenia un 1

        [Required]
        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Ciudad { get; set; }

        [StringLength(150)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string Cp { get; set; }

        public string Observaciones { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FechaReg { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Sucursales> Sucursales { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StCliente> StCliente { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Servicios> Servicios { get; set; }
    }
}
