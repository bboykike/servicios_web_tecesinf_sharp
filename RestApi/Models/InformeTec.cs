namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformeTec")]
    public partial class InformeTec
    {
        [Key]
        public int IDinforme { get; set; }
        public string Comentario { get; set; }
        [StringLength(50)]
        public string Fecha { get; set; }
        public int IDservicio { get; set; }
    }
}
