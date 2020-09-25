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
    public class StatusUsuariosController : ApiController
    {
        private db db = new db();

        // GET: api/StatusUsuarios
        public IQueryable<StatusUsuario> GetStatusUsuario()
        {
            return db.StatusUsuario;
        }

        // GET: api/StatusUsuarios/5
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult GetStatusUsuario(int id)
        {
            StatusUsuario statusUsuario = db.StatusUsuario.Find(id);
            if (statusUsuario == null)
            {
                return NotFound();
            }

            return Ok(statusUsuario);
        }

        // PUT: api/StatusUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusUsuario(int id, StatusUsuario statusUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusUsuario.IDstUsuario)
            {
                return BadRequest();
            }

            db.Entry(statusUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusUsuarioExists(id))
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

        // POST: api/StatusUsuarios
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult PostStatusUsuario(StatusUsuario statusUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusUsuario.Add(statusUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusUsuario.IDstUsuario }, statusUsuario);
        }

        // DELETE: api/StatusUsuarios/5
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult DeleteStatusUsuario(int id)
        {
            StatusUsuario statusUsuario = db.StatusUsuario.Find(id);
            if (statusUsuario == null)
            {
                return NotFound();
            }

            db.StatusUsuario.Remove(statusUsuario);
            db.SaveChanges();

            return Ok(statusUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusUsuarioExists(int id)
        {
            return db.StatusUsuario.Count(e => e.IDstUsuario == id) > 0;
        }
    }
}