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
    public class ExtintorController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Extintor
        public ActionResult Index()
        {
            return View(db.tblExtintor.ToList());
        }

        // GET: Extintor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExtintor tblExtintor = db.tblExtintor.Find(id);
            if (tblExtintor == null)
            {
                return HttpNotFound();
            }
            return View(tblExtintor);
        }

        // GET: Extintor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extintor/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Validade")] tblExtintor tblExtintor)
        {
            if (ModelState.IsValid)
            {
                db.tblExtintor.Add(tblExtintor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblExtintor);
        }

        // GET: Extintor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExtintor tblExtintor = db.tblExtintor.Find(id);
            if (tblExtintor == null)
            {
                return HttpNotFound();
            }
            return View(tblExtintor);
        }

        // POST: Extintor/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Validade")] tblExtintor tblExtintor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblExtintor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblExtintor);
        }

        // GET: Extintor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExtintor tblExtintor = db.tblExtintor.Find(id);
            if (tblExtintor == null)
            {
                return HttpNotFound();
            }
            return View(tblExtintor);
        }

        // POST: Extintor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExtintor tblExtintor = db.tblExtintor.Find(id);
            db.tblExtintor.Remove(tblExtintor);
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
