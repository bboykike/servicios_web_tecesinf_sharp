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
    public class DetallesUsController : ApiController
    {
        private db db = new db();

        // GET: api/DetallesUs
        public IQueryable<DetallesUs> GetDetallesUs()
        {
            return db.DetallesUs;
        }

        // GET: api/DetallesUs/5
        [ResponseType(typeof(DetallesUs))]
        public IHttpActionResult GetDetallesUs(int id)
        {
            DetallesUs detallesUs = db.DetallesUs.Find(id);
            if (detallesUs == null)
            {
                return NotFound();
            }

            return Ok(detallesUs);
        }

        //Lista de los Equipos por ID de sucursales
        [Route("api/GetEmpleados")]
        public List<DetallesUs> GetEvent()
        {
            var ani = db.DetallesUs.OrderBy(x => x.Nombre);
            List<DetallesUs> list = new List<DetallesUs>();

            foreach (var item in ani)
            {
                var resp = new DetallesUs()
                {
                    IDdetalle=item.IDdetalle,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Area= item.Area,
                    Direccion=item.Direccion,
                    FotoUsuario=item.FotoUsuario
                };
                list.Add(resp);
            }
            return list;
        }

        // PUT: api/DetallesUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetallesUs(int id, DetallesUs detallesUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallesUs.IDdetalle)
            {
                return BadRequest();
            }

            db.Entry(detallesUs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesUsExists(id))
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

        // POST: api/DetallesUs
        [ResponseType(typeof(DetallesUs))]
        public IHttpActionResult PostDetallesUs(DetallesUs detallesUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallesUs.Add(detallesUs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detallesUs.IDdetalle }, detallesUs);
        }

        [Route("api/RegistroUsuario")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult RegistroCliente(RegistroUsuario RUsuario)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    // registrar detalleusuario
                    var Detalle = db.DetallesUs.Add(RUsuario.detalles);
                    db.SaveChanges();
                    //Damos el ID del detalle
                    RUsuario.status.IDdetalle = Detalle.IDdetalle;
                    //registramos el status
                    var statusUs = db.StatusUsuario.Add(RUsuario.status);
                    db.SaveChanges();

                    //damos el ID del detalle a Usuarios
                    RUsuario.usuarios.IDdetalle = Detalle.IDdetalle;
                    RUsuario.usuarios.Pass = Encrypt.GetSHA256(RUsuario.usuarios.Pass);
                    //registramos usuarios

                    var Usuarios = db.Usuarios.Add(RUsuario.usuarios);
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

        // DELETE: api/DetallesUs/5
        [ResponseType(typeof(DetallesUs))]
        public IHttpActionResult DeleteDetallesUs(int id)
        {
            DetallesUs detallesUs = db.DetallesUs.Find(id);
            if (detallesUs == null)
            {
                return NotFound();
            }

            db.DetallesUs.Remove(detallesUs);
            db.SaveChanges();

            return Ok(detallesUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallesUsExists(int id)
        {
            return db.DetallesUs.Count(e => e.IDdetalle == id) > 0;
        }
    }
}