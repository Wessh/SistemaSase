using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaSase.Models;

namespace SistemaSase.Controllers
{
    public class IluminacaoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Iluminacao
        public ActionResult Index()
        {
            return View(db.tblIluminacao.ToList());
        }

        // GET: Iluminacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluminacao tblIluminacao = db.tblIluminacao.Find(id);
            if (tblIluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tblIluminacao);
        }

        // GET: Iluminacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iluminacao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] tblIluminacao tblIluminacao)
        {
            if (ModelState.IsValid)
            {
                db.tblIluminacao.Add(tblIluminacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblIluminacao);
        }

        // GET: Iluminacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluminacao tblIluminacao = db.tblIluminacao.Find(id);
            if (tblIluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tblIluminacao);
        }

        // POST: Iluminacao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] tblIluminacao tblIluminacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIluminacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblIluminacao);
        }

        // GET: Iluminacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluminacao tblIluminacao = db.tblIluminacao.Find(id);
            if (tblIluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tblIluminacao);
        }

        // POST: Iluminacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIluminacao tblIluminacao = db.tblIluminacao.Find(id);
            db.tblIluminacao.Remove(tblIluminacao);
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
