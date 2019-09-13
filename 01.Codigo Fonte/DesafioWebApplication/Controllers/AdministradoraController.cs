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
    public class AdministradoraController : ApiController
    {
        private ContextApi db = new ContextApi();

        // GET: api/Administradora
        public IQueryable<AdministradoraEntity> GetAdministradoraEntities()
        {
            return db.AdministradoraEntities;
        }

        // GET: api/Administradora/5
        [ResponseType(typeof(AdministradoraEntity))]
        public IHttpActionResult GetAdministradoraEntity(int id)
        {
            AdministradoraEntity administradoraEntity = db.AdministradoraEntities.Find(id);
            if (administradoraEntity == null)
            {
                return NotFound();
            }

            return Ok(administradoraEntity);
        }

        // PUT: api/Administradora/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministradoraEntity(int id, AdministradoraEntity administradoraEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradoraEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(administradoraEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradoraEntityExists(id))
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

        // POST: api/Administradora
        [ResponseType(typeof(AdministradoraEntity))]
        public IHttpActionResult PostAdministradoraEntity(AdministradoraEntity administradoraEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdministradoraEntities.Add(administradoraEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradoraEntity.Id }, administradoraEntity);
        }

        // DELETE: api/Administradora/5
        [ResponseType(typeof(AdministradoraEntity))]
        public IHttpActionResult DeleteAdministradoraEntity(int id)
        {
            AdministradoraEntity administradoraEntity = db.AdministradoraEntities.Find(id);
            if (administradoraEntity == null)
            {
                return NotFound();
            }

            db.AdministradoraEntities.Remove(administradoraEntity);
            db.SaveChanges();

            return Ok(administradoraEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradoraEntityExists(int id)
        {
            return db.AdministradoraEntities.Count(e => e.Id == id) > 0;
        }
    }
}