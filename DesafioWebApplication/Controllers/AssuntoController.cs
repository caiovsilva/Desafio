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
    public class AssuntoController : ApiController
    {
        private ContextApi db = new ContextApi();

        // GET: api/Assunto
        public IQueryable<AssuntoEntity> GetAssuntoEntities()
        {
            return db.AssuntoEntities;
        }

        // GET: api/Assunto/5
        [ResponseType(typeof(AssuntoEntity))]
        public IHttpActionResult GetAssuntoEntity(int id)
        {
            AssuntoEntity assuntoEntity = db.AssuntoEntities.Find(id);
            if (assuntoEntity == null)
            {
                return NotFound();
            }

            return Ok(assuntoEntity);
        }

        // PUT: api/Assunto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssuntoEntity(int id, AssuntoEntity assuntoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assuntoEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(assuntoEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuntoEntityExists(id))
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

        // POST: api/Assunto
        [ResponseType(typeof(AssuntoEntity))]
        public IHttpActionResult PostAssuntoEntity(AssuntoEntity assuntoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssuntoEntities.Add(assuntoEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assuntoEntity.Id }, assuntoEntity);
        }

        // DELETE: api/Assunto/5
        [ResponseType(typeof(AssuntoEntity))]
        public IHttpActionResult DeleteAssuntoEntity(int id)
        {
            AssuntoEntity assuntoEntity = db.AssuntoEntities.Find(id);
            if (assuntoEntity == null)
            {
                return NotFound();
            }

            db.AssuntoEntities.Remove(assuntoEntity);
            db.SaveChanges();

            return Ok(assuntoEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssuntoEntityExists(int id)
        {
            return db.AssuntoEntities.Count(e => e.Id == id) > 0;
        }
    }
}