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
using RestApi.Models.DBarchivero;

namespace RestApi.Controllers.ControllersArchivero
{
    public class ImagenesController : ApiController
    {
        private dbarchivero db = new dbarchivero();

        // GET: api/Imagenes
        public IQueryable<Imagenes> GetImagenes()
        {
            return db.Imagenes;
        }

        // GET: api/Imagenes/5
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult GetImagenes(int id)
        {
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return NotFound();
            }

            return Ok(imagenes);
        }

        // PUT: api/Imagenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagenes(int id, Imagenes imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagenes.IDimagenes)
            {
                return BadRequest();
            }

            db.Entry(imagenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenesExists(id))
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

        // POST: api/Imagenes
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult PostImagenes(Imagenes imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Imagenes.Add(imagenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagenes.IDimagenes }, imagenes);
        }

        // DELETE: api/Imagenes/5
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult DeleteImagenes(int id)
        {
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return NotFound();
            }

            db.Imagenes.Remove(imagenes);
            db.SaveChanges();

            return Ok(imagenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagenesExists(int id)
        {
            return db.Imagenes.Count(e => e.IDimagenes == id) > 0;
        }
    }
}