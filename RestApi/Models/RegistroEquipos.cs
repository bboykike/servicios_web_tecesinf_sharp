using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class RegistroEquipos
    {
        public Equipos equipos { get; set; }
        public StatusEquipo status { get; set; }
    }
}