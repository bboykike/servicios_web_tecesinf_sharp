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
    public class UsuariosController : ApiController
    {
        private db db = new db();

        // GET: api/Usuarios
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios.UserName);
        }
        ///Valida si el usuario esta registrado
        [Route("api/Login")]
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult Postauthentificate(Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                login.Pass = Encrypt.GetSHA256(login.Pass);
                var authentificate = db.Usuarios.FirstOrDefault(x => x.UserName == login.UserName);
                try
                {
                    if (authentificate.UserName == null)
                    {
                        return Ok(false);

                    }
                    else { 
                    if (authentificate.UserName == login.UserName && authentificate.Pass == login.Pass)
                    {
                        return Ok(authentificate.IDusuario);
                    }
                    else
                        return Ok(false);
                    }
                }
                catch (Exception ERR)
                {
                    return this.NotFound();
                }
            }
            catch
            {
                return this.NotFound();
            }
        }
        //Lista de los Usuarios
        [Route("api/GetUsuarios")]
        public List<Usuarios> GetEvent()
        {
            var ani = db.Usuarios.OrderBy(x => x.UserName);
            List<Usuarios> list = new List<Usuarios>();

            foreach (var item in ani)
            {
                var resp = new Usuarios()
                {
                    IDusuario=item.IDusuario,
                    UserName = item.UserName,
                    Pass=item.Pass,
                    IDrol= item.IDrol,
                    IDdetalle = item.IDdetalle
                };
                list.Add(resp);
            }
            return list;
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.IDusuario)
            {
                return BadRequest();
            }
            usuarios.Pass = Encrypt.GetSHA256(usuarios.Pass);
            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            usuarios.Pass = Encrypt.GetSHA256(usuarios.Pass);
            db.Usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.IDusuario }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.IDusuario == id) > 0;
        }
    }
}