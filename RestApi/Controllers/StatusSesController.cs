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
using RestApi.Models.Email;

namespace RestApi.Controllers
{
    public class StatusSesController : ApiController
    {
        private db db = new db();

        // GET: api/StatusSes
        public IQueryable<StatusSe> GetStatusSe()
        {
            return db.StatusSe;
        }

        // GET: api/StatusSes/5
        [ResponseType(typeof(StatusSe))]
        public IHttpActionResult GetStatusSe(int id)
        {
            StatusSe statusSe = db.StatusSe.Find(id);
            if (statusSe == null)
            {
                return NotFound();
            }

            return Ok(statusSe);
        }

        // PUT: api/StatusSes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusSe(int id, StatusSe statusSe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusSe.IDSe)
            {
                return BadRequest();
            }

            db.Entry(statusSe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusSeExists(id))
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

        //Transaccion para actualizar e insertar historial SIN EQUIPOS
        [Route("api/ActualizarStSE/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult putActualziarStat(ActualizarStatuSE AC)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    db.Entry(AC.status).State = EntityState.Modified;
                    db.SaveChanges();
                    //registramos el historial
                    var historial = db.HistorialSE.Add(AC.historial);
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

            // POST: api/StatusSes
            [ResponseType(typeof(StatusSe))]
        public IHttpActionResult PostStatusSe(StatusSe statusSe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusSe.Add(statusSe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusSe.IDSe }, statusSe);
        }

        // DELETE: api/StatusSes/5
        [ResponseType(typeof(StatusSe))]
        public IHttpActionResult DeleteStatusSe(int id)
        {
            StatusSe statusSe = db.StatusSe.Find(id);
            if (statusSe == null)
            {
                return NotFound();
            }

            db.StatusSe.Remove(statusSe);
            db.SaveChanges();

            return Ok(statusSe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusSeExists(int id)
        {
            return db.StatusSe.Count(e => e.IDSe == id) > 0;
        }
    }
}