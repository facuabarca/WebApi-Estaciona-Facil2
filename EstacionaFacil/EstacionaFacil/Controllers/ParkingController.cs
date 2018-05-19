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
//using EstacionaFacil.Model;

namespace EstacionaFacil.Controllers
{
    public class ParkingController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/Parking
        public IHttpActionResult GetParkings()
        {
            List<Parking> parkings = db.Parking.ToList();

            foreach (var item in parkings)
            {
                var calificacion = db.Calificacion_Parking.Where(x => x.Park_Id == item.Par_Id).ToList().FirstOrDefault();
                if (calificacion != null) {
                    item.Calificacion_Parking.Add(calificacion);
                }
                
            }
            return Ok(new ResponseList { HttpStatus = 200, Body = parkings });
        }



        // GET: api/Parking/5
        [HttpGet]
        public IHttpActionResult GetParking(long usuId)
        {
            var park = db.Parking.Where(x => x.Usu_Id == usuId).ToList();
            Parking parking;
            if (park.Count() == 0)
            {
                return Ok(new Response { HttpStatus = 204, Body = null });
            }
            else {
                parking = park[0];
            }
            return Ok(new Response { HttpStatus = 200, Body = parking });
        }

        // PUT: api/Parking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParking(Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (parking.Par_Id != parking.Par_Id)
            {
                return BadRequest();
            }

            db.Entry(parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingExists(parking.Par_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Parking park = db.Parking.Find(parking.Par_Id);

            return Ok(new Response { HttpStatus = 200, Body = park });
        }

        // POST: api/Parking
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> PostParking(Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new Response { HttpStatus = 400, Body = null });
            }

            db.Parking.Add(parking);
            await db.SaveChangesAsync();

            return Ok(new Response { HttpStatus = 200, Body = parking });
        }

        // DELETE: api/Parking/5
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> DeleteParking(long id)
        {
            Parking parking = await db.Parking.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
              
            Estacionamiento_Parking est = db.Estacionamiento_Parking.Where(x => x.Park_Id == id).ToList().FirstOrDefault();
            if (est != null)
            {
                db.Estacionamiento_Parking.Remove(est);
            }

            Calificacion_Parking cal = db.Calificacion_Parking.Where(x => x.Park_Id == id).ToList().FirstOrDefault();
            if (cal != null)
            {
                db.Calificacion_Parking.Remove(cal);
            }

            Opinion_Parking op = db.Opinion_Parking.Where(x => x.Par_Id == id).ToList().FirstOrDefault();
            if (op != null)
            {
                db.Opinion_Parking.Remove(op);
            }

            Reserva res = db.Reserva.Where(x => x.Park_Id == id).ToList().FirstOrDefault();
            if (res != null)
            {
                db.Reserva.Remove(res);
            }

            try
            {
                db.Parking.Remove(parking);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(new Response { HttpStatus = 200, Body = parking });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParkingExists(long id)
        {
            return db.Parking.Count(e => e.Par_Id == id) > 0;
        }
        public class Response
        {
            public int HttpStatus;
            public Parking Body;
        }
        public class ResponseList
        {
            public int HttpStatus;
            public List<Parking> Body;
        }
    }
}