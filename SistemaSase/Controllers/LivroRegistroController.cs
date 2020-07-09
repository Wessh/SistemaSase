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
    public class LivroRegistroController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: LivroRegistro
        public ActionResult Index()
        {
            return View(db.tblLivroRegistro.ToList());
        }

        // GET: LivroRegistro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivroRegistro tblLivroRegistro = db.tblLivroRegistro.Find(id);
            if (tblLivroRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivroRegistro);
        }

        // GET: LivroRegistro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LivroRegistro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LivroOcorrecia,RegistroDiarios")] tblLivroRegistro tblLivroRegistro)
        {
            if (ModelState.IsValid)
            {
                db.tblLivroRegistro.Add(tblLivroRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLivroRegistro);
        }

        // GET: LivroRegistro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivroRegistro tblLivroRegistro = db.tblLivroRegistro.Find(id);
            if (tblLivroRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivroRegistro);
        }

        // POST: LivroRegistro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LivroOcorrecia,RegistroDiarios")] tblLivroRegistro tblLivroRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLivroRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLivroRegistro);
        }

        // GET: LivroRegistro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivroRegistro tblLivroRegistro = db.tblLivroRegistro.Find(id);
            if (tblLivroRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivroRegistro);
        }

        // POST: LivroRegistro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLivroRegistro tblLivroRegistro = db.tblLivroRegistro.Find(id);
            db.tblLivroRegistro.Remove(tblLivroRegistro);
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
