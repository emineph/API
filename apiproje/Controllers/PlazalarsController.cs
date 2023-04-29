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
using apiproje.Models;

namespace apiproje.Controllers
{
    public class PlazalarsController : ApiController
    {
        private appprojeEntities db = new appprojeEntities();

        // GET: api/Plazalars
        public IQueryable<Plazalar> GetPlazalars()
        {
            return db.Plazalars;
        }

        // GET: api/Plazalars/5
        [ResponseType(typeof(Plazalar))]
        public async Task<IHttpActionResult> GetPlazalar(int id)
        {
            Plazalar plazalar = await db.Plazalars.FindAsync(id);
            if (plazalar == null)
            {
                return NotFound();
            }

            return Ok(plazalar);
        }

        // PUT: api/Plazalars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlazalar(int id, Plazalar plazalar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plazalar.PlazaNo)
            {
                return BadRequest();
            }

            db.Entry(plazalar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlazalarExists(id))
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

        // POST: api/Plazalars
        [ResponseType(typeof(Plazalar))]
        public async Task<IHttpActionResult> PostPlazalar(Plazalar plazalar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plazalars.Add(plazalar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plazalar.PlazaNo }, plazalar);
        }

        // DELETE: api/Plazalars/5
        [ResponseType(typeof(Plazalar))]
        public async Task<IHttpActionResult> DeletePlazalar(int id)
        {
            Plazalar plazalar = await db.Plazalars.FindAsync(id);
            if (plazalar == null)
            {
                return NotFound();
            }

            db.Plazalars.Remove(plazalar);
            await db.SaveChangesAsync();

            return Ok(plazalar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlazalarExists(int id)
        {
            return db.Plazalars.Count(e => e.PlazaNo == id) > 0;
        }
    }
}