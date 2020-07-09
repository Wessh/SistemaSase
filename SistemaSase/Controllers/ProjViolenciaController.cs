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
    public class ProjViolenciaController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ProjViolencia
        public ActionResult Index()
        {
            return View(db.tblProjViolencia.ToList());
        }

        // GET: ProjViolencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProjViolencia tblProjViolencia = db.tblProjViolencia.Find(id);
            if (tblProjViolencia == null)
            {
                return HttpNotFound();
            }
            return View(tblProjViolencia);
        }

        // GET: ProjViolencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjViolencia/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Escola,Parceria")] tblProjViolencia tblProjViolencia)
        {
            if (ModelState.IsValid)
            {
                db.tblProjViolencia.Add(tblProjViolencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblProjViolencia);
        }

        // GET: ProjViolencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProjViolencia tblProjViolencia = db.tblProjViolencia.Find(id);
            if (tblProjViolencia == null)
            {
                return HttpNotFound();
            }
            return View(tblProjViolencia);
        }

        // POST: ProjViolencia/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Escola,Parceria")] tblProjViolencia tblProjViolencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProjViolencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblProjViolencia);
        }

        // GET: ProjViolencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProjViolencia tblProjViolencia = db.tblProjViolencia.Find(id);
            if (tblProjViolencia == null)
            {
                return HttpNotFound();
            }
            return View(tblProjViolencia);
        }

        // POST: ProjViolencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProjViolencia tblProjViolencia = db.tblProjViolencia.Find(id);
            db.tblProjViolencia.Remove(tblProjViolencia);
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
