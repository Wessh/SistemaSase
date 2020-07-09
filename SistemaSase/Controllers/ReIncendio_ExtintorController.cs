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
    public class ReIncendio_ExtintorController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ReIncendio_Extintor
        public ActionResult Index()
        {
            var incendio_Extintor = db.Incendio_Extintor.Include(i => i.tblExtintor).Include(i => i.tblSisIncendio);
            return View(incendio_Extintor.ToList());
        }

        // GET: ReIncendio_Extintor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incendio_Extintor incendio_Extintor = db.Incendio_Extintor.Find(id);
            if (incendio_Extintor == null)
            {
                return HttpNotFound();
            }
            return View(incendio_Extintor);
        }

        // GET: ReIncendio_Extintor/Create
        public ActionResult Create()
        {
            ViewBag.IdExtintor = new SelectList(db.tblExtintor, "Id", "Nome");
            ViewBag.IdIncendio = new SelectList(db.tblSisIncendio, "Id", "Id");
            return View();
        }

        // POST: ReIncendio_Extintor/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdIncendio,IdExtintor")] Incendio_Extintor incendio_Extintor)
        {
            if (ModelState.IsValid)
            {
                db.Incendio_Extintor.Add(incendio_Extintor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdExtintor = new SelectList(db.tblExtintor, "Id", "Nome", incendio_Extintor.IdExtintor);
            ViewBag.IdIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", incendio_Extintor.IdIncendio);
            return View(incendio_Extintor);
        }

        // GET: ReIncendio_Extintor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incendio_Extintor incendio_Extintor = db.Incendio_Extintor.Find(id);
            if (incendio_Extintor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdExtintor = new SelectList(db.tblExtintor, "Id", "Nome", incendio_Extintor.IdExtintor);
            ViewBag.IdIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", incendio_Extintor.IdIncendio);
            return View(incendio_Extintor);
        }

        // POST: ReIncendio_Extintor/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdIncendio,IdExtintor")] Incendio_Extintor incendio_Extintor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incendio_Extintor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdExtintor = new SelectList(db.tblExtintor, "Id", "Nome", incendio_Extintor.IdExtintor);
            ViewBag.IdIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", incendio_Extintor.IdIncendio);
            return View(incendio_Extintor);
        }

        // GET: ReIncendio_Extintor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incendio_Extintor incendio_Extintor = db.Incendio_Extintor.Find(id);
            if (incendio_Extintor == null)
            {
                return HttpNotFound();
            }
            return View(incendio_Extintor);
        }

        // POST: ReIncendio_Extintor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incendio_Extintor incendio_Extintor = db.Incendio_Extintor.Find(id);
            db.Incendio_Extintor.Remove(incendio_Extintor);
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
