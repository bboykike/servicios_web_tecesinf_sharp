using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ActualizarStatus
    {
        public StatusServicio status { get; set; }
        public Historial historial { get; set; }
    }
}