using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiAparelhos.Models;

namespace ApiAparelhos.Controllers
{
    public class AparelhoesController : Controller
    {
        private ApiAparelhosContext db = new ApiAparelhosContext();

        // GET: Aparelhoes
        public ActionResult Index()
        {
            return View(db.Aparelhoes.ToList());
        }

        // GET: Aparelhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        // GET: Aparelhoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aparelhoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AparelhoId,Nome,Link,MusculoTrabalhado")] Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                db.Aparelhoes.Add(aparelho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aparelho);
        }

        // GET: Aparelhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        // POST: Aparelhoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AparelhoId,Nome,Link,MusculoTrabalhado")] Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aparelho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aparelho);
        }

        // GET: Aparelhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        // POST: Aparelhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aparelho aparelho = db.Aparelhoes.Find(id);
            db.Aparelhoes.Remove(aparelho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
