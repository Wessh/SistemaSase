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
    public class ArredoresUebController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ArredoresUeb
        public ActionResult Index()
        {
            return View(db.tblArredoresUeb.ToList());
        }

        // GET: ArredoresUeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArredoresUeb tblArredoresUeb = db.tblArredoresUeb.Find(id);
            if (tblArredoresUeb == null)
            {
                return HttpNotFound();
            }
            return View(tblArredoresUeb);
        }

        // GET: ArredoresUeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArredoresUeb/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bares,CasaFesta,Drogas,Outros")] tblArredoresUeb tblArredoresUeb)
        {
            if (ModelState.IsValid)
            {
                db.tblArredoresUeb.Add(tblArredoresUeb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblArredoresUeb);
        }

        // GET: ArredoresUeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArredoresUeb tblArredoresUeb = db.tblArredoresUeb.Find(id);
            if (tblArredoresUeb == null)
            {
                return HttpNotFound();
            }
            return View(tblArredoresUeb);
        }

        // POST: ArredoresUeb/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bares,CasaFesta,Drogas,Outros")] tblArredoresUeb tblArredoresUeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblArredoresUeb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblArredoresUeb);
        }

        // GET: ArredoresUeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArredoresUeb tblArredoresUeb = db.tblArredoresUeb.Find(id);
            if (tblArredoresUeb == null)
            {
                return HttpNotFound();
            }
            return View(tblArredoresUeb);
        }

        // POST: ArredoresUeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArredoresUeb tblArredoresUeb = db.tblArredoresUeb.Find(id);
            db.tblArredoresUeb.Remove(tblArredoresUeb);
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
