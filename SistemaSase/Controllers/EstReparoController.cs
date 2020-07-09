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
    public class EstReparoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: EstReparo
        public ActionResult Index()
        {
            return View(db.tblEstReparo.ToList());
        }

        // GET: EstReparo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstReparo tblEstReparo = db.tblEstReparo.Find(id);
            if (tblEstReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblEstReparo);
        }

        // GET: EstReparo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstReparo/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] tblEstReparo tblEstReparo)
        {
            if (ModelState.IsValid)
            {
                db.tblEstReparo.Add(tblEstReparo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEstReparo);
        }

        // GET: EstReparo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstReparo tblEstReparo = db.tblEstReparo.Find(id);
            if (tblEstReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblEstReparo);
        }

        // POST: EstReparo/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] tblEstReparo tblEstReparo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEstReparo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEstReparo);
        }

        // GET: EstReparo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstReparo tblEstReparo = db.tblEstReparo.Find(id);
            if (tblEstReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblEstReparo);
        }

        // POST: EstReparo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEstReparo tblEstReparo = db.tblEstReparo.Find(id);
            db.tblEstReparo.Remove(tblEstReparo);
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
