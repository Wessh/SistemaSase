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
    public class ReEstFisica_EstReparoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ReEstFisica_EstReparo
        public ActionResult Index()
        {
            var estFisica_EstReparo = db.EstFisica_EstReparo.Include(e => e.tblEstFisica).Include(e => e.tblEstReparo);
            return View(estFisica_EstReparo.ToList());
        }

        // GET: ReEstFisica_EstReparo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstFisica_EstReparo estFisica_EstReparo = db.EstFisica_EstReparo.Find(id);
            if (estFisica_EstReparo == null)
            {
                return HttpNotFound();
            }
            return View(estFisica_EstReparo);
        }

        // GET: ReEstFisica_EstReparo/Create
        public ActionResult Create()
        {
            ViewBag.IdEstFisica = new SelectList(db.tblEstFisica, "Id", "Id");
            ViewBag.IdEstReparo = new SelectList(db.tblEstReparo, "Id", "Nome");
            return View();
        }

        // POST: ReEstFisica_EstReparo/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEstFisica,IdEstReparo")] EstFisica_EstReparo estFisica_EstReparo)
        {
            if (ModelState.IsValid)
            {
                db.EstFisica_EstReparo.Add(estFisica_EstReparo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", estFisica_EstReparo.IdEstFisica);
            ViewBag.IdEstReparo = new SelectList(db.tblEstReparo, "Id", "Nome", estFisica_EstReparo.IdEstReparo);
            return View(estFisica_EstReparo);
        }

        // GET: ReEstFisica_EstReparo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstFisica_EstReparo estFisica_EstReparo = db.EstFisica_EstReparo.Find(id);
            if (estFisica_EstReparo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", estFisica_EstReparo.IdEstFisica);
            ViewBag.IdEstReparo = new SelectList(db.tblEstReparo, "Id", "Nome", estFisica_EstReparo.IdEstReparo);
            return View(estFisica_EstReparo);
        }

        // POST: ReEstFisica_EstReparo/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEstFisica,IdEstReparo")] EstFisica_EstReparo estFisica_EstReparo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estFisica_EstReparo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", estFisica_EstReparo.IdEstFisica);
            ViewBag.IdEstReparo = new SelectList(db.tblEstReparo, "Id", "Nome", estFisica_EstReparo.IdEstReparo);
            return View(estFisica_EstReparo);
        }

        // GET: ReEstFisica_EstReparo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstFisica_EstReparo estFisica_EstReparo = db.EstFisica_EstReparo.Find(id);
            if (estFisica_EstReparo == null)
            {
                return HttpNotFound();
            }
            return View(estFisica_EstReparo);
        }

        // POST: ReEstFisica_EstReparo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstFisica_EstReparo estFisica_EstReparo = db.EstFisica_EstReparo.Find(id);
            db.EstFisica_EstReparo.Remove(estFisica_EstReparo);
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
