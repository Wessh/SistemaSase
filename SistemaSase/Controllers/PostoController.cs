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
    public class PostoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: tblQntPosto
        public ActionResult Index()
        {
            return View(db.tblQntPosto.ToList());
        }

        // GET: tblQntPosto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQntPosto tblQntPosto = db.tblQntPosto.Find(id);
            if (tblQntPosto == null)
            {
                return HttpNotFound();
            }
            return View(tblQntPosto);
        }

        // GET: tblQntPosto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblQntPosto/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostVigilante,PostPorteiro,PostVigia")] tblQntPosto tblQntPosto)
        {
            if (ModelState.IsValid)
            {
                db.tblQntPosto.Add(tblQntPosto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblQntPosto);
        }

        // GET: tblQntPosto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQntPosto tblQntPosto = db.tblQntPosto.Find(id);
            if (tblQntPosto == null)
            {
                return HttpNotFound();
            }
            return View(tblQntPosto);
        }

        // POST: tblQntPosto/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostVigilante,PostPorteiro,PostVigia")] tblQntPosto tblQntPosto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblQntPosto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblQntPosto);
        }

        // GET: tblQntPosto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQntPosto tblQntPosto = db.tblQntPosto.Find(id);
            if (tblQntPosto == null)
            {
                return HttpNotFound();
            }
            return View(tblQntPosto);
        }

        // POST: tblQntPosto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblQntPosto tblQntPosto = db.tblQntPosto.Find(id);
            db.tblQntPosto.Remove(tblQntPosto);
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
