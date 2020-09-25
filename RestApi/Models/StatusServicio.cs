namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusServicio")]
    public partial class StatusServicio
    {
        [Key]
        public int IDstatus { get; set; }

        [StringLength(30)]
        public string NombreStatus { get; set; }

        public int IDservicio { get; set; }

        //    public virtual Servicios Servicios { get; set; }
    }
}
