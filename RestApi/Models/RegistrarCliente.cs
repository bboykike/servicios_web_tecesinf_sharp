using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class RegistrarCliente
    {
        public Clientes client { get; set; }

        public Sucursales sucursals { get; set; }

        public StCliente stClient { get; set; }
    }
}