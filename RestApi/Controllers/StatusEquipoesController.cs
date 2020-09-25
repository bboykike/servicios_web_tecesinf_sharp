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
    public class StatusEquipoesController : ApiController
    {
        private db db = new db();

        // GET: api/StatusEquipoes
        public IQueryable<StatusEquipo> GetStatusEquipo()
        {
            return db.StatusEquipo;
        }

        // GET: api/StatusEquipoes/5
        [ResponseType(typeof(StatusEquipo))]
        public IHttpActionResult GetStatusEquipo(int id)
        {
            StatusEquipo statusEquipo = db.StatusEquipo.Find(id);
            if (statusEquipo == null)
            {
                return NotFound();
            }

            return Ok(statusEquipo);
        }

        // PUT: api/StatusEquipoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusEquipo(int id, StatusEquipo statusEquipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusEquipo.IDstEquipo)
            {
                return BadRequest();
            }

            db.Entry(statusEquipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEquipoExists(id))
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


        // POST: api/StatusEquipoes
        [ResponseType(typeof(StatusEquipo))]
        public IHttpActionResult PostStatusEquipo(StatusEquipo statusEquipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusEquipo.Add(statusEquipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusEquipo.IDstEquipo }, statusEquipo);
        }

        // DELETE: api/StatusEquipoes/5
        [ResponseType(typeof(StatusEquipo))]
        public IHttpActionResult DeleteStatusEquipo(int id)
        {
            StatusEquipo statusEquipo = db.StatusEquipo.Find(id);
            if (statusEquipo == null)
            {
                return NotFound();
            }

            db.StatusEquipo.Remove(statusEquipo);
            db.SaveChanges();

            return Ok(statusEquipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusEquipoExists(int id)
        {
            return db.StatusEquipo.Count(e => e.IDstEquipo == id) > 0;
        }
    }
}