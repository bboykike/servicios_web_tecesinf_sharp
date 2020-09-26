using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RestApi.Models
{
    public partial class historico_correoSE
    {
        public int id_historico_correo { get; set; }
        public int IDServiceSE { get; set; }
        public int IDcliente { get; set; }
        public int IDhistorialSe { get; set; }
        public int IDusuario { get; set; }

    }
}