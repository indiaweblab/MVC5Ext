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
using Model;

namespace MVC5.WebApi
{
    public class CONFIG_TYPEController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/CONFIG_TYPE
        public IQueryable<CONFIG_TYPE> GetCONFIG_TYPE()
        {
            return db.CONFIG_TYPE;
        }

        // GET: api/CONFIG_TYPE/5
        [ResponseType(typeof(CONFIG_TYPE))]
        public async Task<IHttpActionResult> GetCONFIG_TYPE(int id)
        {
            CONFIG_TYPE cONFIG_TYPE = await db.CONFIG_TYPE.FindAsync(id);
            if (cONFIG_TYPE == null)
            {
                return NotFound();
            }

            return Ok(cONFIG_TYPE);
        }

        // PUT: api/CONFIG_TYPE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCONFIG_TYPE(int id, CONFIG_TYPE cONFIG_TYPE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cONFIG_TYPE.Id)
            {
                return BadRequest();
            }

            db.Entry(cONFIG_TYPE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONFIG_TYPEExists(id))
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

        // POST: api/CONFIG_TYPE
        [ResponseType(typeof(CONFIG_TYPE))]
        public async Task<IHttpActionResult> PostCONFIG_TYPE(CONFIG_TYPE cONFIG_TYPE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CONFIG_TYPE.Add(cONFIG_TYPE);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cONFIG_TYPE.Id }, cONFIG_TYPE);
        }

        // DELETE: api/CONFIG_TYPE/5
        [ResponseType(typeof(CONFIG_TYPE))]
        public async Task<IHttpActionResult> DeleteCONFIG_TYPE(int id)
        {
            CONFIG_TYPE cONFIG_TYPE = await db.CONFIG_TYPE.FindAsync(id);
            if (cONFIG_TYPE == null)
            {
                return NotFound();
            }

            db.CONFIG_TYPE.Remove(cONFIG_TYPE);
            await db.SaveChangesAsync();

            return Ok(cONFIG_TYPE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CONFIG_TYPEExists(int id)
        {
            return db.CONFIG_TYPE.Count(e => e.Id == id) > 0;
        }
    }
}