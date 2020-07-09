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
    public class OpGasController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: OpGas
        public ActionResult Index()
        {
            return View(db.tblOpGas.ToList());
        }

        // GET: OpGas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOpGas tblOpGas = db.tblOpGas.Find(id);
            if (tblOpGas == null)
            {
                return HttpNotFound();
            }
            return View(tblOpGas);
        }

        // GET: OpGas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpGas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EstFunc")] tblOpGas tblOpGas)
        {
            if (ModelState.IsValid)
            {
                db.tblOpGas.Add(tblOpGas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOpGas);
        }

        // GET: OpGas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOpGas tblOpGas = db.tblOpGas.Find(id);
            if (tblOpGas == null)
            {
                return HttpNotFound();
            }
            return View(tblOpGas);
        }

        // POST: OpGas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EstFunc")] tblOpGas tblOpGas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOpGas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOpGas);
        }

        // GET: OpGas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOpGas tblOpGas = db.tblOpGas.Find(id);
            if (tblOpGas == null)
            {
                return HttpNotFound();
            }
            return View(tblOpGas);
        }

        // POST: OpGas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOpGas tblOpGas = db.tblOpGas.Find(id);
            db.tblOpGas.Remove(tblOpGas);
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
