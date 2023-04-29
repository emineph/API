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
    public class PersonellersController : ApiController
    {
        private appprojeEntities db = new appprojeEntities();

        // GET: api/Personellers
        public IQueryable<Personeller> GetPersonellers()
        {
            return db.Personellers;
        }

        // GET: api/Personellers/5
        [ResponseType(typeof(Personeller))]
        public async Task<IHttpActionResult> GetPersoneller(int id)
        {
            Personeller personeller = await db.Personellers.FindAsync(id);
            if (personeller == null)
            {
                return NotFound();
            }

            return Ok(personeller);
        }

        // PUT: api/Personellers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersoneller(int id, Personeller personeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personeller.PersonelNo)
            {
                return BadRequest();
            }

            db.Entry(personeller).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonellerExists(id))
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

        // POST: api/Personellers
        [ResponseType(typeof(Personeller))]
        public async Task<IHttpActionResult> PostPersoneller(Personeller personeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personellers.Add(personeller);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personeller.PersonelNo }, personeller);
        }

        // DELETE: api/Personellers/5
        [ResponseType(typeof(Personeller))]
        public async Task<IHttpActionResult> DeletePersoneller(int id)
        {
            Personeller personeller = await db.Personellers.FindAsync(id);
            if (personeller == null)
            {
                return NotFound();
            }

            db.Personellers.Remove(personeller);
            await db.SaveChangesAsync();

            return Ok(personeller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonellerExists(int id)
        {
            return db.Personellers.Count(e => e.PersonelNo == id) > 0;
        }
    }
}