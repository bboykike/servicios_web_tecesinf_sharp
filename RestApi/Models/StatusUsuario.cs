namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusUsuario")]
    public partial class StatusUsuario
    {
        [Key]
        public int IDstUsuario { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public int IDdetalle { get; set; }


        //public virtual DetallesUs DetallesUs { get; set; }
    }
}
