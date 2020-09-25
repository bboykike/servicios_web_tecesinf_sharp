using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ListaHistorialSE
    {
        public int IDServiceSE { get; set; }
        public int IDhistorialSe { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public int IDusuario { get; set; }
    }
}