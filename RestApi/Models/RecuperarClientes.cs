using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class RecuperarClientes
    {
       public List<Clientes> clients { get; set; }
       public List<Sucursales> sucursals { get; set; }
    }
}