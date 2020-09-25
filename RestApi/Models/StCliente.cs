namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StCliente")]
    public partial class StCliente
    {
        [Key]
        public int IDstCliente { get; set; }

        [StringLength(100)]
        public string Status { get; set; }
        public int IDcliente { get; set; }


        // public virtual Cliente Cliente { get; set; }
    }
}
