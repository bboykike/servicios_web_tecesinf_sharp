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
    public class HistorialSEsController : ApiController
    {
        private db db = new db();

        // GET: api/HistorialSEs
        public IQueryable<HistorialSE> GetHistorialSE()
        {
            return db.HistorialSE;
        }

        // GET: api/HistorialSEs/5
        [ResponseType(typeof(HistorialSE))]
        public IHttpActionResult GetHistorialSE(int id)
        {
            HistorialSE historialSE = db.HistorialSE.Find(id);
            if (historialSE == null)
            {
                return NotFound();
            }

            return Ok(historialSE);
        }

        [Route("api/ListaHistSE/{id}")]
        public List<ListaHistorialSE> GetLista(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.ServiciosSE
                            join historial in ctx.HistorialSE on servicios.IDServiceSE equals historial.IDServiceSE
                            where servicios.IDServiceSE == id
                            select new ListaHistorialSE
                            {
                                IDServiceSE = servicios.IDServiceSE,
                                IDhistorialSe = historial.IDhistorialSe,
                                Fecha = historial.Fecha,
                                Comentario = historial.Comentario,
                                IDusuario = historial.IDusuario
                            };
                return query.ToList();
            }
        }

        // PUT: api/HistorialSEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorialSE(int id, HistorialSE historialSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historialSE.IDhistorialSe)
            {
                return BadRequest();
            }

            db.Entry(historialSE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialSEExists(id))
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

        // POST: api/HistorialSEs
        [ResponseType(typeof(HistorialSE))]
        public IHttpActionResult PostHistorialSE(HistorialSE historialSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialSE.Add(historialSE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historialSE.IDhistorialSe }, historialSE);
        }

        // DELETE: api/HistorialSEs/5
        [ResponseType(typeof(HistorialSE))]
        public IHttpActionResult DeleteHistorialSE(int id)
        {
            HistorialSE historialSE = db.HistorialSE.Find(id);
            if (historialSE == null)
            {
                return NotFound();
            }

            db.HistorialSE.Remove(historialSE);
            db.SaveChanges();

            return Ok(historialSE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialSEExists(int id)
        {
            return db.HistorialSE.Count(e => e.IDhistorialSe == id) > 0;
        }
    }
}