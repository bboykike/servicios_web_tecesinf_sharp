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
    public class ImagenesSEsController : ApiController
    {
        private dbarchivero db = new dbarchivero();

        // GET: api/ImagenesSE
        public IQueryable<ImagenesSE> GetImagenesSE()
        {
            return db.ImagenesSE;
        }

        // GET: api/ImagenesSE/5
        [ResponseType(typeof(ImagenesSE))]
        public IHttpActionResult GetImagenesSE(int id)
        {
            ImagenesSE imagenesSE = db.ImagenesSE.Find(id);
            if (imagenesSE == null)
            {
                return NotFound();
            }

            return Ok(imagenesSE);
        }

        // PUT: api/ImagenesSE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagenesSE(int id, ImagenesSE imagenesSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagenesSE.IDimagenes)
            {
                return BadRequest();
            }

            db.Entry(imagenesSE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenesSEExists(id))
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

        // POST: api/ImagenesSE
        [ResponseType(typeof(ImagenesSE))]
        public IHttpActionResult PostImagenesSE(ImagenesSE imagenesSE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImagenesSE.Add(imagenesSE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagenesSE.IDimagenes }, imagenesSE);
        }

        // DELETE: api/ImagenesSE/5
        [ResponseType(typeof(ImagenesSE))]
        public IHttpActionResult DeleteImagenesSE(int id)
        {
            ImagenesSE imagenesSE = db.ImagenesSE.Find(id);
            if (imagenesSE == null)
            {
                return NotFound();
            }

            db.ImagenesSE.Remove(imagenesSE);
            db.SaveChanges();

            return Ok(imagenesSE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagenesSEExists(int id)
        {
            return db.ImagenesSE.Count(e => e.IDimagenes == id) > 0;
        }
    }
}