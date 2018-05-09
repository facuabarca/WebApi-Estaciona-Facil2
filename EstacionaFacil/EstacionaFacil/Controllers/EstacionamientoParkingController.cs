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
    public class EstacionamientoParkingController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/EstacionamientoParking
        public IQueryable<Estacionamiento_Parking> GetEstacionamiento_Parking()
        {
            return db.Estacionamiento_Parking;
        }

        // GET: api/EstacionamientoParking/5
        [HttpGet]
        public IHttpActionResult GetEstacionamiento_Parking(long id)
        {
            var estParknig = db.Estacionamiento_Parking.Where(x => x.Park_Id == id).ToList();
            Estacionamiento_Parking _EstParking;
            if (estParknig.Count() == 0)
            {
                return Ok(new Response { HttpStatus = 204, Body = null });
            }
            else {
                _EstParking = estParknig[0];
            }
            return Ok(new Response { HttpStatus = 200, Body = _EstParking });
        }

        // PUT: api/EstacionamientoParking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstacionamiento_Parking(Estacionamiento_Parking estacionamiento_Parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (estacionamiento_Parking.Est_Id != estacionamiento_Parking.Est_Id)
            {
                return BadRequest();
            }

            db.Entry(estacionamiento_Parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Estacionamiento_ParkingExists(estacionamiento_Parking.Est_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Estacionamiento_Parking est = db.Estacionamiento_Parking.Find(estacionamiento_Parking.Est_Id);

            return Ok(new Response { HttpStatus = 200, Body = est });
        }

        // POST: api/EstacionamientoParking
        [ResponseType(typeof(Estacionamiento_Parking))]
        public async Task<IHttpActionResult> PostEstacionamiento_Parking(Estacionamiento_Parking estacionamiento_Parking)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new Response { HttpStatus = 400, Body = null });
            }

            db.Estacionamiento_Parking.Add(estacionamiento_Parking);
            await db.SaveChangesAsync();

            return Ok(new Response { HttpStatus = 200, Body = estacionamiento_Parking });
        }

        // DELETE: api/EstacionamientoParking/5
        [ResponseType(typeof(Estacionamiento_Parking))]
        public async Task<IHttpActionResult> DeleteEstacionamiento_Parking(long id)
        {
            Estacionamiento_Parking estacionamiento_Parking = await db.Estacionamiento_Parking.FindAsync(id);
            if (estacionamiento_Parking == null)
            {
                return NotFound();
            }

            db.Estacionamiento_Parking.Remove(estacionamiento_Parking);
            await db.SaveChangesAsync();

            return Ok(estacionamiento_Parking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Estacionamiento_ParkingExists(long id)
        {
            return db.Estacionamiento_Parking.Count(e => e.Est_Id == id) > 0;
        }
    }
    public class Response
    {
        public int HttpStatus;
        public Estacionamiento_Parking Body;
    }
}