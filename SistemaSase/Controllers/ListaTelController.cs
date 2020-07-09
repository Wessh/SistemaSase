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
    public class ListaTelController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ListaTel
        public ActionResult Index()
        {
            return View(db.tblListaTel.ToList());
        }

        // GET: ListaTel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaTel tblListaTel = db.tblListaTel.Find(id);
            if (tblListaTel == null)
            {
                return HttpNotFound();
            }
            return View(tblListaTel);
        }

        // GET: ListaTel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaTel/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Policia,Ronda,Guarda,Bombeiro,Conselho,Samu,SaseSemed")] tblListaTel tblListaTel)
        {
            if (ModelState.IsValid)
            {
                db.tblListaTel.Add(tblListaTel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblListaTel);
        }

        // GET: ListaTel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaTel tblListaTel = db.tblListaTel.Find(id);
            if (tblListaTel == null)
            {
                return HttpNotFound();
            }
            return View(tblListaTel);
        }

        // POST: ListaTel/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Policia,Ronda,Guarda,Bombeiro,Conselho,Samu,SaseSemed")] tblListaTel tblListaTel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblListaTel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblListaTel);
        }

        // GET: ListaTel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaTel tblListaTel = db.tblListaTel.Find(id);
            if (tblListaTel == null)
            {
                return HttpNotFound();
            }
            return View(tblListaTel);
        }

        // POST: ListaTel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblListaTel tblListaTel = db.tblListaTel.Find(id);
            db.tblListaTel.Remove(tblListaTel);
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
