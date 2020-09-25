using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class RegistroServicios
    {
        public Servicios services { get; set; }
        public Historial history { get; set; }

        public StatusServicio status { get; set; }
    }
}