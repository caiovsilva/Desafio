using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DesafioWebApplication.Models;
using DesafioWebApplication.Models.Entidades;

namespace DesafioWebApplication.Controllers
{
    public class ComunicadoController : ApiController
    {
        private ContextApi db = new ContextApi();

        // GET: api/Comunicado
        public IQueryable<ComunicadoEntity> GetComunicadoEntities()
        {
            return db.ComunicadoEntities;
        }

        // GET: api/Comunicado/5
        [ResponseType(typeof(ComunicadoEntity))]
        public IHttpActionResult GetComunicadoEntity(int id)
        {
            ComunicadoEntity comunicadoEntity = db.ComunicadoEntities.Find(id);
            if (comunicadoEntity == null)
            {
                return NotFound();
            }

            return Ok(comunicadoEntity);
        }

        // PUT: api/Comunicado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComunicadoEntity(int id, ComunicadoEntity comunicadoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comunicadoEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(comunicadoEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunicadoEntityExists(id))
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

        // POST: api/Comunicado
        [ResponseType(typeof(ComunicadoEntity))]
        public IHttpActionResult PostComunicadoEntity(ComunicadoEntity comunicadoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comunicadoEntity.DataHoraEnvio = DateTime.Now;
            db.ComunicadoEntities.Add(comunicadoEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comunicadoEntity.Id }, comunicadoEntity);
        }

        // DELETE: api/Comunicado/5
        [ResponseType(typeof(ComunicadoEntity))]
        public IHttpActionResult DeleteComunicadoEntity(int id)
        {
            ComunicadoEntity comunicadoEntity = db.ComunicadoEntities.Find(id);
            if (comunicadoEntity == null)
            {
                return NotFound();
            }

            db.ComunicadoEntities.Remove(comunicadoEntity);
            db.SaveChanges();

            return Ok(comunicadoEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComunicadoEntityExists(int id)
        {
            return db.ComunicadoEntities.Count(e => e.Id == id) > 0;
        }
    }
}