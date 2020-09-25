namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusSe")]
    public partial class StatusSe
    {
        [Key]
        public int IDSe{ get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public int IDServiceSE{ get; set; }

    }
}