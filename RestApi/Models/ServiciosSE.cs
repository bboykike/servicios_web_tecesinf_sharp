using System;
using System.Collections.Generic;
namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiciosSE")]
    public partial class ServiciosSE
    {
        [Key]
        public int IDServiceSE { get; set; }
        public string Problema { get; set; }
        [StringLength(100)]
        public string Tipo { get; set; }
        public int Cliente { get; set; }
        public int Encargado { get; set; }
        [StringLength(50)]
        public string FechaIn { get; set; }
        public int IDusuario { get; set; }
        public DateTime fechaRegistroSE {get; set;}
    }
}

