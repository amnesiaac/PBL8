using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using ApiAparelhos.Models;
using Newtonsoft.Json.Linq;

namespace ApiAparelhos.Controllers
{
    public class AparelhosController : ApiController
    {
        private ApiAparelhosContext db = new ApiAparelhosContext();

        // GET: api/Aparelhos
        public HttpResponseMessage GetAparelhoes()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return
                new HttpResponseMessage()
                {
                    Content = new StringContent(JArray.FromObject(db.Aparelhoes).ToString(),
                    Encoding.UTF8, "application/json")

                };
        }
        // GET: api/Aparelhos/5
        [ResponseType(typeof(Aparelho))]
        public IHttpActionResult GetAparelho(int id)
        {
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return NotFound();
            }

            return Ok(aparelho);
        }

        // PUT: api/Aparelhos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAparelho(int id, Aparelho aparelho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aparelho.AparelhoId)
            {
                return BadRequest();
            }

            db.Entry(aparelho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AparelhoExists(id))
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

        // POST: api/Aparelhos
        [ResponseType(typeof(Aparelho))]
        public IHttpActionResult PostAparelho(Aparelho aparelho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aparelhoes.Add(aparelho);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aparelho.AparelhoId }, aparelho);
        }

        // DELETE: api/Aparelhos/5
        [ResponseType(typeof(Aparelho))]
        public IHttpActionResult DeleteAparelho(int id)
        {
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return NotFound();
            }

            db.Aparelhoes.Remove(aparelho);
            db.SaveChanges();

            return Ok(aparelho);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AparelhoExists(int id)
        {
            return db.Aparelhoes.Count(e => e.AparelhoId == id) > 0;
        }
    }
}