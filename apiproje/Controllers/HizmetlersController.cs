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
    public class HizmetlersController : ApiController
    {
        private appprojeEntities db = new appprojeEntities();

        // GET: api/Hizmetlers
        public IQueryable<Hizmetler> GetHizmetlers()
        {
            return db.Hizmetlers;
        }

        // GET: api/Hizmetlers/5
        [ResponseType(typeof(Hizmetler))]
        public async Task<IHttpActionResult> GetHizmetler(int id)
        {
            Hizmetler hizmetler = await db.Hizmetlers.FindAsync(id);
            if (hizmetler == null)
            {
                return NotFound();
            }

            return Ok(hizmetler);
        }

        // PUT: api/Hizmetlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHizmetler(int id, Hizmetler hizmetler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hizmetler.HizmetNo)
            {
                return BadRequest();
            }

            db.Entry(hizmetler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HizmetlerExists(id))
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

        // POST: api/Hizmetlers
        [ResponseType(typeof(Hizmetler))]
        public async Task<IHttpActionResult> PostHizmetler(Hizmetler hizmetler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hizmetlers.Add(hizmetler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hizmetler.HizmetNo }, hizmetler);
        }

        // DELETE: api/Hizmetlers/5
        [ResponseType(typeof(Hizmetler))]
        public async Task<IHttpActionResult> DeleteHizmetler(int id)
        {
            Hizmetler hizmetler = await db.Hizmetlers.FindAsync(id);
            if (hizmetler == null)
            {
                return NotFound();
            }

            db.Hizmetlers.Remove(hizmetler);
            await db.SaveChangesAsync();

            return Ok(hizmetler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HizmetlerExists(int id)
        {
            return db.Hizmetlers.Count(e => e.HizmetNo == id) > 0;
        }
    }
}