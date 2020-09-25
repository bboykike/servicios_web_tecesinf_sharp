using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ServiceSE
    {
        public ServiciosSE servicio { get; set; }
        public HistorialSE historial { get; set; } 
        public StatusSe status { get; set; }
    }
}