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
    public class StClientesController : ApiController
    {
        private db db = new db();

        // GET: api/StClientes
        public IQueryable<StCliente> GetStCliente()
        {
            return db.StCliente;
        }

        // GET: api/StClientes/5
        [ResponseType(typeof(StCliente))]
        public IHttpActionResult GetStCliente(int id)
        {
            StCliente stCliente = db.StCliente.Find(id);
            if (stCliente == null)
            {
                return NotFound();
            }

            return Ok(stCliente);
        }

        // PUT: api/StClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStCliente(int id, StCliente stCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stCliente.IDstCliente)
            {
                return BadRequest();
            }

            db.Entry(stCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StClienteExists(id))
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

        // POST: api/StClientes
        [ResponseType(typeof(StCliente))]
        public IHttpActionResult PostStCliente(StCliente stCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StCliente.Add(stCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stCliente.IDstCliente }, stCliente);
        }

        // DELETE: api/StClientes/5
        [ResponseType(typeof(StCliente))]
        public IHttpActionResult DeleteStCliente(int id)
        {
            StCliente stCliente = db.StCliente.Find(id);
            if (stCliente == null)
            {
                return NotFound();
            }

            db.StCliente.Remove(stCliente);
            db.SaveChanges();

            return Ok(stCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StClienteExists(int id)
        {
            return db.StCliente.Count(e => e.IDstCliente == id) > 0;
        }
    }
}