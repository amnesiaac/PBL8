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
    public class ExerciciosController : Controller
    {
        private Bruno_prova1Context db = new Bruno_prova1Context();

        // GET: Exercicios
        public ActionResult Index()
        {
            var exercicios = db.Exercicios.Include(e => e.Aparelho);
            return View(exercicios.ToList());
        }

        // GET: Exercicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // GET: Exercicios/Create
        public ActionResult Create()
        {
            ViewBag.AparelhoId = new SelectList(db.Aparelhoes, "AparelhoId", "Nome");
            return View();
        }

        // POST: Exercicios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExercicioId,Nome,QuantidadeRepeticao,Tempo,PertenceTreino,AparelhoId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Exercicios.Add(exercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AparelhoId = new SelectList(db.Aparelhoes, "AparelhoId", "Nome", exercicio.AparelhoId);
            return View(exercicio);
        }

        // GET: Exercicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.AparelhoId = new SelectList(db.Aparelhoes, "AparelhoId", "Nome", exercicio.AparelhoId);
            return View(exercicio);
        }

        // POST: Exercicios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExercicioId,Nome,QuantidadeRepeticao,Tempo,PertenceTreino,AparelhoId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AparelhoId = new SelectList(db.Aparelhoes, "AparelhoId", "Nome", exercicio.AparelhoId);
            return View(exercicio);
        }

        // GET: Exercicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Exercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercicio exercicio = db.Exercicios.Find(id);
            db.Exercicios.Remove(exercicio);
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
