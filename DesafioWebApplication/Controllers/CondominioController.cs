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
    public class CondominioController : ApiController
    {
        private ContextApi db = new ContextApi();

        // GET: api/Condominio
        public IQueryable<CondominioEntity> GetCondominios()
        {
            return db.Condominios;
        }

        // GET: api/Condominio/5
        [ResponseType(typeof(CondominioEntity))]
        public IHttpActionResult GetCondominioEntity(int id)
        {
            CondominioEntity condominioEntity = db.Condominios.Find(id);
            if (condominioEntity == null)
            {
                return NotFound();
            }

            return Ok(condominioEntity);
        }

        // PUT: api/Condominio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCondominioEntity(int id, CondominioEntity condominioEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condominioEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(condominioEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioEntityExists(id))
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

        // POST: api/Condominio
        [ResponseType(typeof(CondominioEntity))]
        public IHttpActionResult PostCondominioEntity(CondominioEntity condominioEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Condominios.Add(condominioEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condominioEntity.Id }, condominioEntity);
        }

        // DELETE: api/Condominio/5
        [ResponseType(typeof(CondominioEntity))]
        public IHttpActionResult DeleteCondominioEntity(int id)
        {
            CondominioEntity condominioEntity = db.Condominios.Find(id);
            if (condominioEntity == null)
            {
                return NotFound();
            }

            db.Condominios.Remove(condominioEntity);
            db.SaveChanges();

            return Ok(condominioEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondominioEntityExists(int id)
        {
            return db.Condominios.Count(e => e.Id == id) > 0;
        }
    }
}