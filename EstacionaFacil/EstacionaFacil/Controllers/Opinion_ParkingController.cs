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
    public class Opinion_ParkingController : ApiController
    {
        private EstacionaFacilModel db = new EstacionaFacilModel();

        // GET: api/Opinion_Parking
        public IHttpActionResult GetOpinion_Parking()
        {
            List<Opinion_Parking_Model> listOpiniones = new List<Opinion_Parking_Model>();
            var opinionesParking = db.Opinion_Parking.ToList();
            foreach (var item in opinionesParking)
            {
                Opinion_Parking_Model model = new Opinion_Parking_Model();
                model.Opi_Id = item.Opi_Id;
                model.Par_Id = item.Par_Id;
                model.Usu_Id = item.Usu_Id;
                model.Opi_Opinion = item.Opi_Opinion;
                listOpiniones.Add(model);
            }
            return Ok(new ResponseList { HttpStatus = 200, Body = listOpiniones });
        }

        // GET: api/Opinion_Parking/5
        [ResponseType(typeof(Opinion_Parking))]
        public async Task<IHttpActionResult> GetOpinion_Parking(long id)
        {
            Opinion_Parking opinion_Parking = await db.Opinion_Parking.FindAsync(id);
            if (opinion_Parking == null)
            {
                return NotFound();
            }

            return Ok(opinion_Parking);
        }

        // PUT: api/Opinion_Parking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOpinion_Parking(long id, Opinion_Parking opinion_Parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opinion_Parking.Opi_Id)
            {
                return BadRequest();
            }

            db.Entry(opinion_Parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Opinion_ParkingExists(id))
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

        // POST: api/Opinion_Parking
        [ResponseType(typeof(Opinion_Parking))]
        public async Task<IHttpActionResult> PostOpinion_Parking(Opinion_Parking opinion_Parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Opinion_Parking.Add(opinion_Parking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = opinion_Parking.Opi_Id }, opinion_Parking);
        }

        // DELETE: api/Opinion_Parking/5
        [ResponseType(typeof(Opinion_Parking))]
        public async Task<IHttpActionResult> DeleteOpinion_Parking(long id)
        {
            Opinion_Parking opinion_Parking = await db.Opinion_Parking.FindAsync(id);
            if (opinion_Parking == null)
            {
                return NotFound();
            }

            db.Opinion_Parking.Remove(opinion_Parking);
            await db.SaveChangesAsync();

            return Ok(opinion_Parking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Opinion_ParkingExists(long id)
        {
            return db.Opinion_Parking.Count(e => e.Opi_Id == id) > 0;
        }
    }
    public class ResponseOpinion
    {
        public int HttpStatus;
        public Opinion_Parking_Model Body;
    }
    public class ResponseList
    {
        public int HttpStatus;
        public List<Opinion_Parking_Model> Body;
    }
}