namespace RestApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        [Key]
        public int IDhistoria { get; set; }

        public string Comentario { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public int IDservicio { get; set; }
        public int IDusuario { get; set; }

        //public virtual Equipos Equipos { get; set; }

        //public virtual Servicios Servicios { get; set; }
    }
}
