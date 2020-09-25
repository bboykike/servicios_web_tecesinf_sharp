using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using Antlr.Runtime.Misc;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class ClientesController : ApiController
    {
        private db db = new db();

        // GET: api/Clientes
        public IQueryable<Clientes> GetCliente()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult GetCliente(int id)
        {
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        //Recuperas una lista que contiene listas separadas de todos lo clientes y todas las sucursales
        //Un JSON que te devuele una lista de 2 objetos
        [Route("api/ListaClientes")]
        public RecuperarClientes GetList()
        {
            var ani = db.Clientes;
            var anis = db.Sucursales;
            List<Clientes> list = new List<Clientes>();
            List<Sucursales> lista = new List<Sucursales>();
            var listas = new RecuperarClientes();

            foreach (var item in ani)
            {
                var resp = new Clientes()
                {
                    IDcliente = item.IDcliente,
                    RFC = item.RFC,
                    Cliente = item.Cliente,
                    Contacto = item.Contacto,
                    Telefono = item.Telefono,
                    Celular = item.Celular,
                    Estado = item.Estado,
                    Ciudad = item.Ciudad,
                    Direccion = item.Direccion,
                    Observaciones = item.Observaciones,
                    Email = item.Email,
                    FechaReg = item.FechaReg

                };
                list.Add(resp);
            }
            foreach (var item in anis)
            {
                var resp = new Sucursales()
                {
                    IDsucursal=item.IDsucursal,
                    Nombre= item.Nombre,
                    Direccion=item.Direccion,
                    IDcliente=item.IDcliente
                };
                lista.Add(resp);
            }
            listas.clients = list;
            listas.sucursals = lista;
            return listas;
        }


        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Clientes cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.IDcliente)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult PostCliente(Clientes cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.IDcliente }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        // transaccion para registro de cliente, sucursal y agregacion de estado de cliente
        [Route("api/RegistroCliente")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult RegistroCliente(RegistrarCliente RClient)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                   
                    // registrar ciente
                    var Client = db.Clientes.Add(RClient.client);
                    db.SaveChanges();
                    //Asignamos el ID a la sucursal
                    RClient.sucursals.IDcliente = Client.IDcliente;
                    //Asignamos el ID al status
                    RClient.stClient.IDcliente = Client.IDcliente;
                    //Registamos stutus
                    var Status = db.StCliente.Add(RClient.stClient);
                    db.SaveChanges();
                    // Registro de sucursal
                    db.Sucursales.Add(RClient.sucursals);


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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.IDcliente == id) > 0;
        }
    }
}