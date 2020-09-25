using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class InformeTecSEsController : ApiController
    {
        private db db = new db();

        // GET: api/InformeTecSEs
        public IQueryable<InformeTecSE> GetInformeTecSE()
        {
            return db.InformeTecSE;
        }

        // GET: api/InformeTecSEs/5
        [ResponseType(typeof(InformeTecSE))]
        public IHttpActionResult GetInformeTecSE(int id)
        {
            InformeTecSE informeTecSE = db.InformeTecSE.Find(id);
            if (informeTecSE == null)
            {
                return NotFound();
            }

            return Ok(informeTecSE);
        }
        //Recuperas la lista de los informes del servicio
        [Route("api/BuscarInformeSE/{id}")]
        public List<InformeTecSE> GetEvent(int id)
        {
            var ani = db.InformeTecSE.OrderBy(x => x.IDServiceSE == id);
            List<InformeTecSE> list = new List<InformeTecSE>();

            foreach (var item in ani)
            {
                var resp = new InformeTecSE()
                {
                    IDinforme = item.IDinforme,
                    Comentario = item.Comentario,
                    Fecha = item.Fecha,
                    IDServiceSE = item.IDServiceSE

                };
                list.Add(resp);
            }
            return list;
        }
        // PUT: api/InformeTecSEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInformeTecSE(int id, InformeTecSE informeTecSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informeTecSE.IDinforme)
            {
                return BadRequest();
            }

            db.Entry(informeTecSE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeTecSEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InformeTecSEs
        [ResponseType(typeof(InformeTecSE))]
        public IHttpActionResult PostInformeTecSE(InformeTecSE informeTecSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InformeTecSE.Add(informeTecSE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = informeTecSE.IDinforme }, informeTecSE);
        }

        // DELETE: api/InformeTecSEs/5
        [ResponseType(typeof(InformeTecSE))]
        public IHttpActionResult DeleteInformeTecSE(int id)
        {
            InformeTecSE informeTecSE = db.InformeTecSE.Find(id);
            if (informeTecSE == null)
            {
                return NotFound();
            }

            db.InformeTecSE.Remove(informeTecSE);
            db.SaveChanges();

            return Ok(informeTecSE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformeTecSEExists(int id)
        {
            return db.InformeTecSE.Count(e => e.IDinforme == id) > 0;
        }
    }
}