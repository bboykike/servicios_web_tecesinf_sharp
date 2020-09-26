using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using Antlr.Runtime.Misc;
using RestApi.Models;
//Controlador de historico de correo

namespace RestApi.Controllers
{
    public class historico_correoSEController : ApiController
    {
        private db db = new db();

        // GET: api/historico_correoSE
        public IQueryable<historico_correoSE> Gethistorico_correoSE()
        {
            return db.historico_correoSEs;
        }


        // POST: api/historico_correoSE
        [ResponseType(typeof(historico_correoSE))]
        public IHttpActionResult PostCliente(historico_correoSE historico_CorreoSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.historico_correoSEs.Add(historico_CorreoSE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historico_CorreoSE.id_historico_correo }, historico_CorreoSE);
        }
    }
}
