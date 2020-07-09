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
    public class TransitoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Transito
        public ActionResult Index()
        {
            return View(db.tblTransito.ToList());
        }

        // GET: Transito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransito tblTransito = db.tblTransito.Find(id);
            if (tblTransito == null)
            {
                return HttpNotFound();
            }
            return View(tblTransito);
        }

        // GET: Transito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transito/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FaixaPedestre,Semaforo,Agente")] tblTransito tblTransito)
        {
            if (ModelState.IsValid)
            {
                db.tblTransito.Add(tblTransito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTransito);
        }

        // GET: Transito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransito tblTransito = db.tblTransito.Find(id);
            if (tblTransito == null)
            {
                return HttpNotFound();
            }
            return View(tblTransito);
        }

        // POST: Transito/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FaixaPedestre,Semaforo,Agente")] tblTransito tblTransito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTransito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTransito);
        }

        // GET: Transito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTransito tblTransito = db.tblTransito.Find(id);
            if (tblTransito == null)
            {
                return HttpNotFound();
            }
            return View(tblTransito);
        }

        // POST: Transito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTransito tblTransito = db.tblTransito.Find(id);
            db.tblTransito.Remove(tblTransito);
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
