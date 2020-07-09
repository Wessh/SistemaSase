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
    public class GasCozinhaController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: GasCozinha
        public ActionResult Index()
        {
            return View(db.tblGasCozinha.ToList());
        }

        // GET: GasCozinha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGasCozinha tblGasCozinha = db.tblGasCozinha.Find(id);
            if (tblGasCozinha == null)
            {
                return HttpNotFound();
            }
            return View(tblGasCozinha);
        }

        // GET: GasCozinha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasCozinha/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Funcionando")] tblGasCozinha tblGasCozinha)
        {
            if (ModelState.IsValid)
            {
                db.tblGasCozinha.Add(tblGasCozinha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGasCozinha);
        }

        // GET: GasCozinha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGasCozinha tblGasCozinha = db.tblGasCozinha.Find(id);
            if (tblGasCozinha == null)
            {
                return HttpNotFound();
            }
            return View(tblGasCozinha);
        }

        // POST: GasCozinha/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Funcionando")] tblGasCozinha tblGasCozinha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGasCozinha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGasCozinha);
        }

        // GET: GasCozinha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGasCozinha tblGasCozinha = db.tblGasCozinha.Find(id);
            if (tblGasCozinha == null)
            {
                return HttpNotFound();
            }
            return View(tblGasCozinha);
        }

        // POST: GasCozinha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGasCozinha tblGasCozinha = db.tblGasCozinha.Find(id);
            db.tblGasCozinha.Remove(tblGasCozinha);
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
