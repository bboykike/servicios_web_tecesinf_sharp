using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class ServiciosSEsController : ApiController
    {
        private db db = new db();

        // GET: api/ServiciosSEs
        public IQueryable<ServiciosSE> GetServiciosSE()
        {
            return db.ServiciosSE;
        }

        // GET: api/ServiciosSEs/5
        [ResponseType(typeof(ServiciosSE))]
        public IHttpActionResult GetServiciosSE(int id)
        {
            ServiciosSE serviciosSE = db.ServiciosSE.Find(id);
            if (serviciosSE == null)
            {
                return NotFound();
            }

            return Ok(serviciosSE);
        }
        //Recuperas la lista personal  de todos los servicios sin equipo con el ID del encargado(Usuario)
        [Route("api/ServicioListSE/{id}")]
        public List<Inner> GetLista(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.ServiciosSE
                            join status in ctx.StatusSe on servicios.IDServiceSE equals status.IDServiceSE
                            join clientes in ctx.Clientes on servicios.Cliente equals clientes.IDcliente
                            where servicios.IDusuario == id
                            select new Inner
                            {
                                IDServiceSE = servicios.IDServiceSE,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                Problema = servicios.Problema,
                                Cliente = clientes.Cliente,
                                IDusuario = servicios.IDusuario,
                                IDcliente = servicios.Cliente,
                                IDstatus = status.IDSe,
                                Status = status.Status,
                                Email = clientes.Email
                            };
                return query.ToList();
            }
        }
        // PUT: api/ServiciosSEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiciosSE(int id, ServiciosSE serviciosSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviciosSE.IDServiceSE)
            {
                return BadRequest();
            }

            db.Entry(serviciosSE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosSEExists(id))
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

        // POST: api/ServiciosSEs
        [ResponseType(typeof(ServiciosSE))]
        public IHttpActionResult PostServiciosSE(ServiciosSE serviciosSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosSE.Add(serviciosSE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviciosSE.IDServiceSE }, serviciosSE);
        }

        //Transaccion para actualizar el servicio e insertar historial
        [Route("api/ActualizarSE/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult putActualziarServicio(ActualizarSE AC)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    db.Entry(AC.servicios).State = EntityState.Modified;
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
        // transaccion para registro del servicio con equipo
        [Route("api/RegistroSE")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult RegistroServicio(ServiceSE RServices)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction()) 
            {
                try
                {
                    //DateTime date = new DateTime();
                    //date = RServices.historial.Fecha;
                    //string formatted = date.ToString("dd/M/yyyy");
                    //RServices.historial.Fecha = Convert.ToDateTime(formatted);

                    // registrar ciente
                    var servicio = db.ServiciosSE.Add(RServices.servicio);
                    db.SaveChanges();
                    //Asignamos el ID de servicio al historial
                    RServices.historial.IDServiceSE = servicio.IDServiceSE;

                    //Recuperamos el ID para asignarlo al status
                    RServices.status.IDServiceSE = servicio.IDServiceSE;
                    //Registramos el servicio
                    var status = db.StatusSe.Add(RServices.status);
                    db.SaveChanges();

                    //Registramos el historial
                    var Historia = db.HistorialSE.Add(RServices.historial);
                    db.SaveChanges();

                    db.SaveChanges();
                    transaction.Commit();
                    return Ok(servicio.IDServiceSE);
                }
                catch
                {
                    transaction.Rollback();
                    return Ok(false);
                }
            }
        }


        // DELETE: api/ServiciosSEs/5
        [ResponseType(typeof(ServiciosSE))]
        public IHttpActionResult DeleteServiciosSE(int id)
        {
            ServiciosSE serviciosSE = db.ServiciosSE.Find(id);
            if (serviciosSE == null)
            {
                return NotFound();
            }

            db.ServiciosSE.Remove(serviciosSE);
            db.SaveChanges();

            return Ok(serviciosSE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosSEExists(int id)
        {
            return db.ServiciosSE.Count(e => e.IDServiceSE == id) > 0;
        }
    }
}