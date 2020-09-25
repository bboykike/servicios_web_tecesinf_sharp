using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ListHistorial
    {
        public int IDservicio { get; set; }
        public int IDhistoria { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public int IDequipo { get; set; }
        public int IDusuario { get; set; }

    }
}