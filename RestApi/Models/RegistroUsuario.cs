using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class RegistroUsuario
    {
        public Usuarios usuarios { get; set; }
        public DetallesUs detalles { get; set; }
        public StatusUsuario status { get; set; }
    }
}