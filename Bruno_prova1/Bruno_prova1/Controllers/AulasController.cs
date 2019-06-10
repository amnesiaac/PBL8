using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bruno_prova1.Models;

namespace Bruno_prova1.Controllers
{
    public class AulasController : Controller
    {
        private Bruno_prova1Context db = new Bruno_prova1Context();

        // GET: Aulas
        public ActionResult Index()
        {
            var aulas = db.Aulas.Include(a => a.Treino);
            return View(aulas.ToList());
        }

        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // GET: Aulas/Create
        public ActionResult Create()
        {
            ViewBag.TreinoId = new SelectList(db.Treinoes, "TreinoId", "Nome");
            return View();
        }

        // POST: Aulas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AulaId,Data,TreinoId")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                Treino treino = db.Treinoes.Find(aula.TreinoId);
                aula.Treino = treino;
                treino.NumeroVezesTreino += 1;
                db.Entry(treino).State = EntityState.Modified;
                db.Aulas.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TreinoId = new SelectList(db.Treinoes, "TreinoId", "Nome", aula.TreinoId);
            return View(aula);
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            ViewBag.TreinoId = new SelectList(db.Treinoes, "TreinoId", "Nome", aula.TreinoId);
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AulaId,Data,TreinoId")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TreinoId = new SelectList(db.Treinoes, "TreinoId", "Nome", aula.TreinoId);
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aula = db.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = db.Aulas.Find(id);
            db.Aulas.Remove(aula);
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
