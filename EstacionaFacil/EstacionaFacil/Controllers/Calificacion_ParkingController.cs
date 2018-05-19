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
using EstacionaFacil.Models;

namespace EstacionaFacil.Controllers
{
    public class Calificacion_ParkingController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/Calificacion_Parking
        public IQueryable<Calificacion_Parking> GetCalificacion_Parking()
        {
            return db.Calificacion_Parking;
        }

        // GET: api/Calificacion_Parking/5
       [HttpGet]
        public IHttpActionResult GetCalificacion_Parking(long usuId)
        {
            var calificacion_parking = db.Calificacion_Parking.Where(x => x.Usu_Id == usuId).ToList().FirstOrDefault();
            if (calificacion_parking == null)
            {
                return Ok(new Response { HttpStatus = 204, Body = null });
            }
            else
            {
                return Ok(new Response { HttpStatus = 200, Body = calificacion_parking });
            }
        }

        // PUT: api/Calificacion_Parking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalificacion_Parking(long id, Calificacion_Parking calificacion_Parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificacion_Parking.Cal_Id)
            {
                return BadRequest();
            }

            db.Entry(calificacion_Parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Calificacion_ParkingExists(id))
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

        // POST: api/Calificacion_Parking
        [ResponseType(typeof(Calificacion_Parking))]
        public async Task<IHttpActionResult> PostCalificacion_Parking(Calificacion_Parking calificacion_Parking)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new Response { HttpStatus = 400, Body = null });
            }

            db.Calificacion_Parking.Add(calificacion_Parking);
            await db.SaveChangesAsync();

            return Ok(new Response { HttpStatus = 200, Body = calificacion_Parking });
        }

        // DELETE: api/Calificacion_Parking/5
        [ResponseType(typeof(Calificacion_Parking))]
        public async Task<IHttpActionResult> DeleteCalificacion_Parking(long id)
        {
            Calificacion_Parking calificacion_Parking = await db.Calificacion_Parking.FindAsync(id);
            if (calificacion_Parking == null)
            {
                return NotFound();
            }

            db.Calificacion_Parking.Remove(calificacion_Parking);
            await db.SaveChangesAsync();

            return Ok(calificacion_Parking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Calificacion_ParkingExists(long id)
        {
            return db.Calificacion_Parking.Count(e => e.Cal_Id == id) > 0;
        }

        public class Response
        {
            public int HttpStatus;
            public Calificacion_Parking Body;
        }
    }


}