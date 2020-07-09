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
    public class SisIncendioController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: SisIncendio
        public ActionResult Index()
        {
            return View(db.tblSisIncendio.ToList());
        }

        // GET: SisIncendio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisIncendio tblSisIncendio = db.tblSisIncendio.Find(id);
            if (tblSisIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblSisIncendio);
        }

        // GET: SisIncendio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SisIncendio/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Certificacao,Extintor")] tblSisIncendio tblSisIncendio)
        {
            if (ModelState.IsValid)
            {
                db.tblSisIncendio.Add(tblSisIncendio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSisIncendio);
        }

        // GET: SisIncendio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisIncendio tblSisIncendio = db.tblSisIncendio.Find(id);
            if (tblSisIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblSisIncendio);
        }

        // POST: SisIncendio/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Certificacao,Extintor")] tblSisIncendio tblSisIncendio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSisIncendio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSisIncendio);
        }

        // GET: SisIncendio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisIncendio tblSisIncendio = db.tblSisIncendio.Find(id);
            if (tblSisIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblSisIncendio);
        }

        // POST: SisIncendio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSisIncendio tblSisIncendio = db.tblSisIncendio.Find(id);
            db.tblSisIncendio.Remove(tblSisIncendio);
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
