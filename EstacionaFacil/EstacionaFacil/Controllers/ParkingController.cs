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
    public class ParkingController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/Parking
        public IQueryable<Parking> GetParkings()
        {
            return db.Parking;
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

            db.Parking.Remove(parking);
            await db.SaveChangesAsync();

            return Ok(parking);
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
    }
}