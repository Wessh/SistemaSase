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
    public class tblTipoSegsController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: tblTipoSegs
        public ActionResult Index()
        {
            return View(db.tblTipoSeg.ToList());
        }

        // GET: tblTipoSegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoSeg tblTipoSeg = db.tblTipoSeg.Find(id);
            if (tblTipoSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoSeg);
        }

        // GET: tblTipoSegs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblTipoSegs/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vigilante,Porteiro,VigiFeirista,PortFeirista,VigSemedPort,VigSemed")] tblTipoSeg tblTipoSeg)
        {
            if (ModelState.IsValid)
            {
                db.tblTipoSeg.Add(tblTipoSeg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTipoSeg);
        }

        // GET: tblTipoSegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoSeg tblTipoSeg = db.tblTipoSeg.Find(id);
            if (tblTipoSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoSeg);
        }

        // POST: tblTipoSegs/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vigilante,Porteiro,VigiFeirista,PortFeirista,VigSemedPort,VigSemed")] tblTipoSeg tblTipoSeg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTipoSeg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTipoSeg);
        }

        // GET: tblTipoSegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoSeg tblTipoSeg = db.tblTipoSeg.Find(id);
            if (tblTipoSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoSeg);
        }

        // POST: tblTipoSegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTipoSeg tblTipoSeg = db.tblTipoSeg.Find(id);
            db.tblTipoSeg.Remove(tblTipoSeg);
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
