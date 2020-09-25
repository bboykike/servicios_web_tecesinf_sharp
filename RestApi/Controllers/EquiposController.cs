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
    public class EquiposController : ApiController
    {
        private db db = new db();

        // GET: api/Equipos
        public IQueryable<Equipos> GetEquipos()
        {
            return db.Equipos;
        }

        // GET: api/Equipos/5
        [ResponseType(typeof(Equipos))]
        public IHttpActionResult GetEquipos(int id)
        {
            Equipos equipos = db.Equipos.Find(id);
            if (equipos == null)
            {
                return NotFound();
            }

            return Ok(equipos);
        }
        //Lista de los Equipos por ID de sucursales
        [Route("api/GetEquipos/{id}")]
        public List<Equipos> GetEvent(int id)
        {
            var ani = db.Equipos.OrderBy(x => x.Marca).Where(x => x.IDsucursal == id);
            List<Equipos> list = new List<Equipos>();

            foreach (var item in ani)
            {
                var resp = new Equipos()
                {
                    IDequipo = item.IDequipo,
                    TipoEquipo = item.TipoEquipo,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    NoSerie = item.NoSerie,
                    IDsucursal = item.IDsucursal
                };
                list.Add(resp);
            }
            return list;
        }

        // PUT: api/Equipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipos(int id, Equipos equipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipos.IDequipo)
            {
                return BadRequest();
            }

            db.Entry(equipos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquiposExists(id))
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

        // POST: api/Equipos
        [ResponseType(typeof(Equipos))]
        public IHttpActionResult PostEquipos(Equipos equipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipos.Add(equipos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipos.IDequipo }, equipos);
        }

        //Transaccion para registrar equipos
        [Route("api/RegistroEquipo")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult RegistroCliente(RegistroEquipos REquipos)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    // registrar Equipo
                    var Equipos = db.Equipos.Add(REquipos.equipos);
                    db.SaveChanges();
                    //Damos el ID del status
                    REquipos.status.IDequipo = Equipos.IDequipo;
                    //registramos el status
                    var statusEq = db.StatusEquipo.Add(REquipos.status);
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
        // DELETE: api/Equipos/5
        [ResponseType(typeof(Equipos))]
        public IHttpActionResult DeleteEquipos(int id)
        {
            Equipos equipos = db.Equipos.Find(id);
            if (equipos == null)
            {
                return NotFound();
            }

            db.Equipos.Remove(equipos);
            db.SaveChanges();

            return Ok(equipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquiposExists(int id)
        {
            return db.Equipos.Count(e => e.IDequipo == id) > 0;
        }
    }
}