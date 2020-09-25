using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class Agenda
    {
        [Key]
        public int IDagenda { get; set; }
        public string Evento { get; set; }
        [StringLength(50)]
        public string Fecha { get; set; }
        public int IDusuario { get; set; }
    }
}