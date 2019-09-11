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
    public class UsuarioController : ApiController
    {
        private ContextApi db = new ContextApi();

        // GET: api/Usuario
        public IQueryable<UsuarioEntity> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(UsuarioEntity))]
        public IHttpActionResult GetUsuarioEntity(int id)
        {
            UsuarioEntity usuarioEntity = db.Usuarios.Find(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return Ok(usuarioEntity);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarioEntity(int id, UsuarioEntity usuarioEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(usuarioEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEntityExists(id))
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

        // POST: api/Usuario
        [ResponseType(typeof(UsuarioEntity))]
        public IHttpActionResult PostUsuarioEntity(UsuarioEntity usuarioEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarioEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarioEntity.Id }, usuarioEntity);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(UsuarioEntity))]
        public IHttpActionResult DeleteUsuarioEntity(int id)
        {
            UsuarioEntity usuarioEntity = db.Usuarios.Find(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarioEntity);
            db.SaveChanges();

            return Ok(usuarioEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioEntityExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}