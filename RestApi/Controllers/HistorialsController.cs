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
    public class HistorialsController : ApiController
    {
        private db db = new db();

        // GET: api/Historials
        public IQueryable<Historial> GetHistorial()
        {
            return db.Historial;
        }

        // GET: api/Historials/5
        [ResponseType(typeof(Historial))]
        public IHttpActionResult GetHistorial(int id)
        {
            Historial historial = db.Historial.Find(id);
            if (historial == null)
            {
                return NotFound();
            }

            return Ok(historial);
        }

        // PUT: api/Historials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorial(int id, Historial historial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historial.IDhistoria)
            {
                return BadRequest();
            }

            db.Entry(historial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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
        [Route("api/ListaHistorial/{id}")]
        public List<ListHistorial> GetLista(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join historial in ctx.Historial on servicios.IDservicio equals historial.IDservicio
                            where servicios.IDservicio == id
                            select new ListHistorial
                            {
                                IDservicio = servicios.IDservicio,
                                IDhistoria=historial.IDhistoria,
                                IDequipo=servicios.IDequipo,
                                Fecha=historial.Fecha,
                                Comentario=historial.Comentario,
                                IDusuario=historial.IDusuario
                            };
                return query.ToList();
            }
        }
        // POST: api/Historials
        [ResponseType(typeof(Historial))]
        public IHttpActionResult PostHistorial(Historial historial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historial.Add(historial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historial.IDhistoria }, historial);
        }
        //Recuperas la lista de los informes del servicio
        
        // DELETE: api/Historials/5
        [ResponseType(typeof(Historial))]
        public IHttpActionResult DeleteHistorial(int id)
        {
            Historial historial = db.Historial.Find(id);
            if (historial == null)
            {
                return NotFound();
            }

            db.Historial.Remove(historial);
            db.SaveChanges();

            return Ok(historial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialExists(int id)
        {
            return db.Historial.Count(e => e.IDhistoria == id) > 0;
        }
    }
}