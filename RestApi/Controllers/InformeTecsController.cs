using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class InformeTecsController : ApiController
    {
        private db db = new db();

        // GET: api/InformeTecs
        public IQueryable<InformeTec> GetInformeTec()
        {
            return db.InformeTec;
        }

        // GET: api/InformeTecs/5
        [ResponseType(typeof(InformeTec))]
        public IHttpActionResult GetInformeTec(int id)
        {
            InformeTec informeTec = db.InformeTec.Find(id);
            if (informeTec == null)
            {
                return NotFound();
            }

            return Ok(informeTec);
        }
        //Recuperas la lista de los informes del servicio
        [Route("api/BuscarInformes/{id}")]
        public List<InformeTec> GetEvent(int id)
        {
            var ani = db.InformeTec.OrderBy(x => x.IDservicio == id);
            List<InformeTec> list = new List<InformeTec>();

            foreach (var item in ani)
            {
                var resp = new InformeTec()
                {
                    IDinforme = item.IDinforme,
                    Comentario=item.Comentario,
                    Fecha=item.Fecha,
                    IDservicio = item.IDservicio

                };
                list.Add(resp);
            }
            return list;
        }


        // PUT: api/InformeTecs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInformeTec(int id, InformeTec informeTec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informeTec.IDinforme)
            {
                return BadRequest();
            }

            db.Entry(informeTec).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeTecExists(id))
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

        // POST: api/InformeTecs
        [ResponseType(typeof(bool))]
        public IHttpActionResult PostInformeTec(InformeTec informeTec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InformeTec.Add(informeTec);
            db.SaveChanges();

            return Ok(true);
        }

        // DELETE: api/InformeTecs/5
        [ResponseType(typeof(InformeTec))]
        public IHttpActionResult DeleteInformeTec(int id)
        {
            InformeTec informeTec = db.InformeTec.Find(id);
            if (informeTec == null)
            {
                return NotFound();
            }

            db.InformeTec.Remove(informeTec);
            db.SaveChanges();

            return Ok(informeTec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformeTecExists(int id)
        {
            return db.InformeTec.Count(e => e.IDinforme == id) > 0;
        }
    }
}