namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistorialSE")]
    public partial class HistorialSE
    {
        [Key]
        public int IDhistorialSe { get; set; }
        public string Comentario { get; set; }
        [StringLength(50)]
        public string Fecha { get; set; }
        public int IDusuario { get; set; }
        public int IDServiceSE { get; set; }
    }
}
