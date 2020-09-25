using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class Inner
    {
        public int IDServiceSE { get; set; }
        public string Tipo { get; set; }

        public string FechaIn { get; set; }

        public string Problema { get; set; }
        public string Cliente { get; set; }

        public string Email { get; set; }
        public int  IDusuario { get; set; }
        public int IDcliente { get; set; }
        public int IDstatus { get; set; }
        public string Status { get; set; }

    }
}