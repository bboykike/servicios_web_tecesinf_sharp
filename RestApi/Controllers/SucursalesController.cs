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
    public class SucursalesController : ApiController
    {
        private db db = new db();

        // GET: api/Sucursales
        public IQueryable<Sucursales> GetSucursales()
        {
            return db.Sucursales;
        }

        // GET: api/Sucursales/5
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult GetSucursales(int id)
        {

            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return Ok(sucursales);
        }
        //Lista de las sucursales por ID de usuario
        [Route("api/GetSucursales/{id}")]
        public List<Sucursales> GetEvent(int id)
        {
            var ani = db.Sucursales.OrderBy(x => x.Nombre).Where(x => x.IDcliente == id);
            List<Sucursales> list = new List<Sucursales>();

            foreach (var item in ani)
            {
                var resp = new Sucursales()
                {
                    IDsucursal = item.IDsucursal,
                    Nombre = item.Nombre,
                    Direccion = item.Direccion,
                    IDcliente = item.IDcliente
                };
                list.Add(resp);
            }
            return list;
        }


        // PUT: api/Sucursales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursales(int id, Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursales.IDsucursal)
            {
                return BadRequest();
            }

            db.Entry(sucursales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalesExists(id))
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

        // POST: api/Sucursales
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult PostSucursales(Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursales.Add(sucursales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursales.IDsucursal }, sucursales);
        }

        // DELETE: api/Sucursales/5
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult DeleteSucursales(int id)
        {
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            db.Sucursales.Remove(sucursales);
            db.SaveChanges();

            return Ok(sucursales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalesExists(int id)
        {
            return db.Sucursales.Count(e => e.IDsucursal == id) > 0;
        }
    }
}