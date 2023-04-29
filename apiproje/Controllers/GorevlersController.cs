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
    public class GorevlersController : ApiController
    {
        private appprojeEntities db = new appprojeEntities();

        // GET: api/Gorevlers
        public IQueryable<Gorevler> GetGorevlers()
        {
            return db.Gorevlers;
        }

        // GET: api/Gorevlers/5
        [ResponseType(typeof(Gorevler))]
        public async Task<IHttpActionResult> GetGorevler(int id)
        {
            Gorevler gorevler = await db.Gorevlers.FindAsync(id);
            if (gorevler == null)
            {
                return NotFound();
            }

            return Ok(gorevler);
        }

        // PUT: api/Gorevlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGorevler(int id, Gorevler gorevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gorevler.GorevNo)
            {
                return BadRequest();
            }

            db.Entry(gorevler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GorevlerExists(id))
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

        // POST: api/Gorevlers
        [ResponseType(typeof(Gorevler))]
        public async Task<IHttpActionResult> PostGorevler(Gorevler gorevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gorevlers.Add(gorevler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gorevler.GorevNo }, gorevler);
        }

        // DELETE: api/Gorevlers/5
        [ResponseType(typeof(Gorevler))]
        public async Task<IHttpActionResult> DeleteGorevler(int id)
        {
            Gorevler gorevler = await db.Gorevlers.FindAsync(id);
            if (gorevler == null)
            {
                return NotFound();
            }

            db.Gorevlers.Remove(gorevler);
            await db.SaveChangesAsync();

            return Ok(gorevler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GorevlerExists(int id)
        {
            return db.Gorevlers.Count(e => e.GorevNo == id) > 0;
        }
    }
}