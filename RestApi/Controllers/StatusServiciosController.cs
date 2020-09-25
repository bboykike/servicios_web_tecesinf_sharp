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
    public class StatusServiciosController : ApiController
    {
        private db db = new db();

        // GET: api/StatusServicios
        public IQueryable<StatusServicio> GetStatusServicio()
        {
            return db.StatusServicio;
        }
        //Lista de los Usuarios
        [Route("api/GetStatus/{id}")]
        public IHttpActionResult GetStatusid(int id)
        {
            StatusServicio statusServicio = db.StatusServicio.FirstOrDefault(x => x.IDservicio==id);
            return Ok(statusServicio);
        }
        // GET: api/StatusServicios/5
        [ResponseType(typeof(StatusServicio))]
        public IHttpActionResult GetStatusServicio(int id)
        {
            StatusServicio statusServicio = db.StatusServicio.Find(id);
            if (statusServicio == null)
            {
                return NotFound();
            }

            return Ok(statusServicio);
        }

        // PUT: api/StatusServicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusServicio(int id, StatusServicio statusServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusServicio.IDstatus)
            {
                return BadRequest();
            }

            db.Entry(statusServicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusServicioExists(id))
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
        //Transaccion para actualizar e insertar historial
        [Route("api/ActualizarSt/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult putActualziarStat(ActualizarStatus AC)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    db.Entry(AC.status).State = EntityState.Modified;
                    db.SaveChanges();
                    //registramos el historial
                    var historial = db.Historial.Add(AC.historial);
                    db.SaveChanges();

                    db.SaveChanges();
                    transaction.Commit();
                    return Ok(true);
                }
                catch
                {
                    transaction.Rollback();
                    return Ok(false);
                }
            }
        }

        // POST: api/StatusServicios
        [ResponseType(typeof(StatusServicio))]
        public IHttpActionResult PostStatusServicio(StatusServicio statusServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusServicio.Add(statusServicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusServicio.IDstatus }, statusServicio);
        }

        // DELETE: api/StatusServicios/5
        [ResponseType(typeof(StatusServicio))]
        public IHttpActionResult DeleteStatusServicio(int id)
        {
            StatusServicio statusServicio = db.StatusServicio.Find(id);
            if (statusServicio == null)
            {
                return NotFound();
            }

            db.StatusServicio.Remove(statusServicio);
            db.SaveChanges();

            return Ok(statusServicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusServicioExists(int id)
        {
            return db.StatusServicio.Count(e => e.IDstatus == id) > 0;
        }
    }
}