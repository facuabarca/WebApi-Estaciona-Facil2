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
        public IHttpActionResult Login(string username, string password)
        {
            var usuario = db.Usuario.Where( x => x.Usu_Email.Contains(username) && x.Usu_Contrasena.Contains(password)).ToList();
            Usuario usu = new Usuario() ;
            var response = new Response();
            if (usuario.Count() == 0)
            {
                return Ok(new Response { HttpStatus = 401, Body = null });
            }
            else
            {
                usu = usuario[0];
            }
            return Ok(new Response { HttpStatus = 200, Body = usu });
        }

        // GET: api/Usuarios/5

        [HttpGet]
        public IHttpActionResult GetUsuario(long id)
        {
            Usuario usuario =  db.Usuario.Find(id);
            if (usuario == null)
            {
                return Ok(new Response { HttpStatus = 202, Body = null });
            }

            return Ok(new Response { HttpStatus = 200, Body = usuario });
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        public async Task<IHttpActionResult> PutUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuario.Usu_Id != usuario.Usu_Id)
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
                if (!UsuarioExists(usuario.Usu_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Usuario user = db.Usuario.Find(usuario.Usu_Id);

            return Ok(new Response { HttpStatus = 200, Body = user });
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

        public class Response
        {
            public int HttpStatus;
            public Usuario Body;
        }
    }
}