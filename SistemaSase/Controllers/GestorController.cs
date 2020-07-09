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
    public class GestorController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Gestor
        public ActionResult Index()
        {
            return View(db.tblGestor.ToList());
        }

        // GET: Gestor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGestor tblGestor = db.tblGestor.Find(id);
            if (tblGestor == null)
            {
                return HttpNotFound();
            }
            return View(tblGestor);
        }

        // GET: Gestor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gestor/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Documento")] tblGestor tblGestor)
        {
            if (ModelState.IsValid)
            {
                db.tblGestor.Add(tblGestor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGestor);
        }

        // GET: Gestor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGestor tblGestor = db.tblGestor.Find(id);
            if (tblGestor == null)
            {
                return HttpNotFound();
            }
            return View(tblGestor);
        }

        // POST: Gestor/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Documento")] tblGestor tblGestor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGestor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGestor);
        }

        // GET: Gestor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGestor tblGestor = db.tblGestor.Find(id);
            if (tblGestor == null)
            {
                return HttpNotFound();
            }
            return View(tblGestor);
        }

        // POST: Gestor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGestor tblGestor = db.tblGestor.Find(id);
            db.tblGestor.Remove(tblGestor);
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
