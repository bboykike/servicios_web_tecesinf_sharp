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
    public class AccesoriosController : ApiController
    {
        private db db = new db();

        // GET: api/Accesorios
        public IQueryable<Accesorios> GetAccesorios()
        {
            return db.Accesorios;
        }

        // GET: api/Accesorios/5
        [ResponseType(typeof(Accesorios))]
        public IHttpActionResult GetAccesorios(int id)
        {
            Accesorios accesorios = db.Accesorios.Find(id);
            if (accesorios == null)
            {
                return NotFound();
            }

            return Ok(accesorios);
        }
        //Lista de los Equipos por ID de sucursales
        [Route("api/GetAccesorios/{id}")]
        public List<Accesorios> GetEvent(int id)
        {
            var ani = db.Accesorios.OrderBy(x => x.Nombre).Where(x => x.IDequipo == id);
            List<Accesorios> list = new List<Accesorios>();
            foreach (var item in ani)
            {
                var resp = new Accesorios()
                {
                    IDaccesorio = item.IDequipo,
                    Nombre = item.Nombre,
                    Marca = item.Marca,
                    NoSerie = item.NoSerie,
                    IDequipo = item.IDequipo
                };
                list.Add(resp);
            }
            return list;
        }
        // PUT: api/Accesorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccesorios(int id, Accesorios accesorios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accesorios.IDaccesorio)
            {
                return BadRequest();
            }

            db.Entry(accesorios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoriosExists(id))
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

        // POST: api/Accesorios
        [ResponseType(typeof(Accesorios))]
        public IHttpActionResult PostAccesorios(Accesorios accesorios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accesorios.Add(accesorios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accesorios.IDaccesorio }, accesorios);
        }

        // DELETE: api/Accesorios/5
        [ResponseType(typeof(Accesorios))]
        public IHttpActionResult DeleteAccesorios(int id)
        {
            Accesorios accesorios = db.Accesorios.Find(id);
            if (accesorios == null)
            {
                return NotFound();
            }

            db.Accesorios.Remove(accesorios);
            db.SaveChanges();

            return Ok(accesorios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccesoriosExists(int id)
        {
            return db.Accesorios.Count(e => e.IDaccesorio == id) > 0;
        }
    }
}