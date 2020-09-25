namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformeTecSE")]
    public partial class InformeTecSE
    {
        [Key]
        public int IDinforme { get; set; }
        public string Comentario { get; set; }
        [StringLength(50)]
        public string Fecha { get; set; }
        public int IDServiceSE { get; set; }
    }
}
