namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusEquipo")]
    public partial class StatusEquipo
    {
        [Key]
        public int IDstEquipo { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public int IDequipo { get; set; }

    }
}