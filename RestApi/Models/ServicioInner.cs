using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ServicioInner
    {
        public int IDservicio { get; set; }
        public string Tipo { get; set; }

        public string FechaIn { get; set; }

        public string Problema { get; set; }

        public int IDusuario { get; set; }
        public int IDcliente { get; set; }
        public int IDstatus { get; set; }
        public string Status { get; set; }
        public string Comentario { get; set; }
        public int IDequipo { get; set; }
    }
}