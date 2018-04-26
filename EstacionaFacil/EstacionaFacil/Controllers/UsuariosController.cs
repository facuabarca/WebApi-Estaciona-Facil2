using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using EstacionaFacil.Models;

namespace EstacionaFacil.Controllers
{
    public class UsuariosController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }


        // GET: api/Usuarios/5
        [HttpGet]
        public IHttpActionResult  Login(string username, string password)
        {
            var usuario = db.Usuario.Where( x => x.Usu_Email.Contains(username) && x.Usu_Contrasena.Contains(password)).ToList();
            Usuario usu = new Usuario() ;
            if (usuario.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                usu = usuario[0];
            }
           
            return Ok(usu);
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(long id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            
            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(long id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Usu_Id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Usuario.Add(usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuario.Usu_Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(long id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(long id)
        {
            return db.Usuario.Count(e => e.Usu_Id == id) > 0;
        }
    }
}