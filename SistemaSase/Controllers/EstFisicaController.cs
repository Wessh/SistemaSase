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
    public class EstFisicaController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: EstFisica
        public ActionResult Index()
        {
            return View(db.tblEstFisica.ToList());
        }

        // GET: EstFisica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstFisica tblEstFisica = db.tblEstFisica.Find(id);
            if (tblEstFisica == null)
            {
                return HttpNotFound();
            }
            return View(tblEstFisica);
        }

        // GET: EstFisica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstFisica/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Estacionamento,ControleVeiculos,PortaoEletronico,EstaRetrito,ParaRaios")] tblEstFisica tblEstFisica)
        {
            if (ModelState.IsValid)
            {
                db.tblEstFisica.Add(tblEstFisica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEstFisica);
        }

        // GET: EstFisica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstFisica tblEstFisica = db.tblEstFisica.Find(id);
            if (tblEstFisica == null)
            {
                return HttpNotFound();
            }
            return View(tblEstFisica);
        }

        // POST: EstFisica/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Estacionamento,ControleVeiculos,PortaoEletronico,EstaRetrito,ParaRaios")] tblEstFisica tblEstFisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEstFisica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEstFisica);
        }

        // GET: EstFisica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstFisica tblEstFisica = db.tblEstFisica.Find(id);
            if (tblEstFisica == null)
            {
                return HttpNotFound();
            }
            return View(tblEstFisica);
        }

        // POST: EstFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEstFisica tblEstFisica = db.tblEstFisica.Find(id);
            db.tblEstFisica.Remove(tblEstFisica);
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
