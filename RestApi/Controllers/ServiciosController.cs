using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Description;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class ServiciosController : ApiController
    {
        private db db = new db();

        // GET: api/Servicios
        public IQueryable<Servicios> GetServicios()
        {
            return db.Servicios;
        }


        // GET: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult GetServicios(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return NotFound();
            }

            return Ok(servicios);
        }
        //Recuperas detalles el servicio completo segun sea su ID-Este 
        //es para ver todos los detalles segun el ID del servicio
        [Route("api/DetalleServicio/{id}")]
        public List<ServicioInner> GetDeatalle(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join status in ctx.StatusServicio on servicios.IDservicio equals status.IDservicio
                            join historial in ctx.Historial on servicios.IDservicio equals historial.IDservicio
                            where servicios.IDservicio==id
                            select new ServicioInner
                            {
                                IDservicio = servicios.IDservicio,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                Problema = servicios.Problema,
                                IDusuario = servicios.IDusuario,
                                IDcliente = servicios.IDcliente,
                                IDstatus = status.IDstatus,
                                Status = status.NombreStatus,
                                Comentario=historial.Comentario,
                                IDequipo=servicios.IDequipo
                            };
                return query.ToList();
            }
        }

        //Recuperas la lista personal  de todos los servicios con el ID del encargado(Usuario)
        [Route("api/ServiciosLista/{id}")]
        public List<InnerEquipo> GetLista(int id)
        {
            //Se tiene que instanciar de esta forma porque c# solo asi reconoce correctamente los InnerJoin
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join status in ctx.StatusServicio on servicios.IDservicio equals status.IDservicio
                            join cliente in ctx.Clientes on servicios.IDcliente equals cliente.IDcliente
                            where servicios.Encargado == id 
                            select new InnerEquipo
                            {
                                IDservicio = servicios.IDservicio,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                IDstatus= status.IDstatus,
                                Status=status.NombreStatus,
                                Cliente= cliente.Cliente,
                                IDequipo=servicios.IDequipo,
                                Problema = servicios.Problema,
                                IDusuario = servicios.IDusuario,
                                IDcliente = servicios.IDcliente,
                                Email = cliente.Email
                            };               
                return query.ToList();
            }
        }

        //Recuperas la lista personal  de los servicios sin usuarios asigandos para atender
        [Route("api/ServiciosSinUsuario")]
        public List<InnerEquipo> GetIniciados()
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join status in ctx.StatusServicio on servicios.IDservicio equals status.IDservicio
                            where servicios.Encargado == null
                            select new InnerEquipo
                            {
                                IDservicio = servicios.IDservicio,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                Problema = servicios.Problema,
                                IDusuario = servicios.IDusuario,
                                IDcliente = servicios.IDcliente,
                                IDstatus = status.IDstatus,
                                Status = status.NombreStatus
                            };
                return query.ToList();
            }
        }

        //Recuperas la lista personal de los servicios Pendientes
        [Route("api/GetPendientes/{id}")]
        public List<InnerEquipo> GetPendientes(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join status in ctx.StatusServicio on servicios.IDservicio equals status.IDservicio
                            where servicios.Encargado == id
                            where status.NombreStatus == "En Seguimiento"
                            select new InnerEquipo
                            {
                                IDservicio = servicios.IDservicio,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                Problema = servicios.Problema,
                                IDusuario=servicios.IDusuario,
                                IDcliente=servicios.IDcliente,
                                IDstatus=status.IDstatus,
                                Status = status.NombreStatus
                            };
                return query.ToList();
            }
        }
        //Recuperas la lista personal  de los servicios Finalizados
        [Route("api/GetFinalizado/{id}")]
        public List<InnerEquipo> GetFinalizado(int id)
        {
            using (var ctx = new db())
            {
                var query = from servicios in ctx.Servicios
                            join status in ctx.StatusServicio on servicios.IDservicio equals status.IDservicio
                            where servicios.Encargado == id
                            where status.NombreStatus == "Finalizado"
                            select new InnerEquipo
                            {
                                IDservicio = servicios.IDservicio,
                                Tipo = servicios.Tipo,
                                FechaIn = servicios.FechaIn,
                                Problema = servicios.Problema,
                                IDusuario = servicios.IDusuario,
                                IDcliente = servicios.IDcliente,
                                IDstatus = status.IDstatus,
                                Status = status.NombreStatus
                            };
                return query.ToList();
            }
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicios(int id, Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios.IDservicio)
            {
                return BadRequest();
            }

            db.Entry(servicios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
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
        [Route("api/ActualizarS/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult putActualziarServicio(actualizacion AC)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    db.Entry(AC.servicio).State = EntityState.Modified;
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

        // POST: api/Servicios
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult PostServicios(Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicios.IDservicio }, servicios);
        }

        // transaccion para registro del servicio con equipo
        [Route("api/RegistroServicio")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult RegistroServicio(RegistroServicios RServices)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    // registrar servicio
                    var servicio = db.Servicios.Add(RServices.services);
                    db.SaveChanges();
                    //Asignamos el ID de servicio al historial
                    RServices.history.IDservicio = servicio.IDservicio;
                    //Recuperamos el ID para asignarlo al status
                    RServices.status.IDservicio = servicio.IDservicio;
                    //Registramos el servicio
                    var status = db.StatusServicio.Add(RServices.status);
                    db.SaveChanges();

                    //Registramos el historial
                    var Historia = db.Historial.Add(RServices.history);
                    db.SaveChanges();

                    db.SaveChanges();
                    transaction.Commit();
                    return Ok(servicio.IDservicio);
                }
                catch
                {
                    transaction.Rollback();
                    return Ok(false);
                }
            }
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult DeleteServicios(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicios);
            db.SaveChanges();

            return Ok(servicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosExists(int id)
        {
            return db.Servicios.Count(e => e.IDservicio == id) > 0;
        }
    }
}