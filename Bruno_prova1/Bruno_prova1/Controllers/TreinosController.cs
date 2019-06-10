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
    public class TreinosController : Controller
    {
        private Bruno_prova1Context db = new Bruno_prova1Context();

        // GET: Treinos
        public ActionResult Index()
        {
            var treinoes = db.Treinoes.Include(t => t.Exercicio);
            return View(treinoes.ToList());
        }

        // GET: Treinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }
        //GET: Treinos/Historico
        public ActionResult Historico()
        {
            var treinoes = db.Treinoes.Include(t => t.Exercicio);
            return View(treinoes.ToList());
        }

        // GET: Treinos/Create
        public ActionResult Create()
        {
            ViewBag.ExercicioId = new SelectList(db.Exercicios.Where(a => a.PertenceTreino == false), "ExercicioId", "Nome");
            return View();
        }

        // POST: Treinos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreinoId,Nome,NumeroVezesTreino,TempoMaximo,ExercicioId")] Treino treino, List<int>ExercicioId)
        {
            if (ModelState.IsValid)
            {
                foreach (int exercicio in ExercicioId)
                {
                    Exercicio exercicio1 = db.Exercicios.Find(exercicio);
                    exercicio1.PertenceTreino = true;
                    treino.TempoMaximo += exercicio1.Tempo;
                }
                db.Treinoes.Add(treino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExercicioId = new SelectList(db.Exercicios, "ExercicioId", "Nome", treino.ExercicioId);
            return View(treino);
        }

        // GET: Treinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExercicioId = new SelectList(db.Exercicios, "ExercicioId", "Nome", treino.ExercicioId);
            return View(treino);
        }

        // POST: Treinos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreinoId,Nome,NumeroVezesTreino,TempoMaximo,ExercicioId")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExercicioId = new SelectList(db.Exercicios, "ExercicioId", "Nome", treino.ExercicioId);
            return View(treino);
        }

        // GET: Treinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // POST: Treinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treino treino = db.Treinoes.Find(id);
            db.Treinoes.Remove(treino);
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
