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
using EstacionaFacil.Model;

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
        public IHttpActionResult GetCalificacion_Parking(long usuId, long park_id)
        {
            var calificacion_parking = db.Calificacion_Parking.Where(x => x.Usu_Id == usuId && x.Park_Id == park_id).ToList().FirstOrDefault();
            if (calificacion_parking == null)
            {
                return Ok(new Response { HttpStatus = 204, Body = null });
            }
            else
            {
                Calificacion_Parking_Model cal = new Calificacion_Parking_Model();
                cal.Cal_Id = calificacion_parking.Cal_Id;
                cal.Cal_Calificacion = calificacion_parking.Cal_Calificacion;
                cal.Park_Id = calificacion_parking.Park_Id;
                cal.Usu_Id = calificacion_parking.Usu_Id;
                return Ok(new ResponseGet { HttpStatus = 200, Body = cal });
            }
        }

        // PUT: api/Calificacion_Parking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalificacion_Parking(Calificacion_Parking calificacion_Parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(calificacion_Parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Calificacion_ParkingExists(calificacion_Parking.Cal_Id))
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

        public class ResponseGet
        {
            public int HttpStatus;
            public Calificacion_Parking_Model Body;
        }
    }


}