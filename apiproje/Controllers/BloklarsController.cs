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
    public class BloklarsController : ApiController
    {
        private appprojeEntities db = new appprojeEntities();

        // GET: api/Bloklars
        public IQueryable<Bloklar> GetBloklars()
        {
            return db.Bloklars;
        }

        // GET: api/Bloklars/5
        [ResponseType(typeof(Bloklar))]
        public async Task<IHttpActionResult> GetBloklar(int id)
        {
            Bloklar bloklar = await db.Bloklars.FindAsync(id);
            if (bloklar == null)
            {
                return NotFound();
            }

            return Ok(bloklar);
        }

        // PUT: api/Bloklars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBloklar(int id, Bloklar bloklar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloklar.BlokNo)
            {
                return BadRequest();
            }

            db.Entry(bloklar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloklarExists(id))
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

        // POST: api/Bloklars
        [ResponseType(typeof(Bloklar))]
        public async Task<IHttpActionResult> PostBloklar(Bloklar bloklar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bloklars.Add(bloklar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bloklar.BlokNo }, bloklar);
        }

        // DELETE: api/Bloklars/5
        [ResponseType(typeof(Bloklar))]
        public async Task<IHttpActionResult> DeleteBloklar(int id)
        {
            Bloklar bloklar = await db.Bloklars.FindAsync(id);
            if (bloklar == null)
            {
                return NotFound();
            }

            db.Bloklars.Remove(bloklar);
            await db.SaveChangesAsync();

            return Ok(bloklar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloklarExists(int id)
        {
            return db.Bloklars.Count(e => e.BlokNo == id) > 0;
        }
    }
}