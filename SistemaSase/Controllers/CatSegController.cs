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
    public class CatSegController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: CatSeg
        public ActionResult Index()
        {
            var tblCatSeg = db.tblCatSeg.Include(t => t.tblEquipamentosSeg);
            return View(tblCatSeg.ToList());
        }

        // GET: CatSeg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCatSeg tblCatSeg = db.tblCatSeg.Find(id);
            if (tblCatSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblCatSeg);
        }

        // GET: CatSeg/Create
        public ActionResult Create()
        {
            ViewBag.FkEquipamentos = new SelectList(db.tblEquipamentosSeg, "Id", "Id");
            return View();
        }

        // POST: CatSeg/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,FkEquipamentos")] tblCatSeg tblCatSeg)
        {
            if (ModelState.IsValid)
            {
                db.tblCatSeg.Add(tblCatSeg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkEquipamentos = new SelectList(db.tblEquipamentosSeg, "Id", "Id", tblCatSeg.FkEquipamentos);
            return View(tblCatSeg);
        }

        // GET: CatSeg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCatSeg tblCatSeg = db.tblCatSeg.Find(id);
            if (tblCatSeg == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkEquipamentos = new SelectList(db.tblEquipamentosSeg, "Id", "Id", tblCatSeg.FkEquipamentos);
            return View(tblCatSeg);
        }

        // POST: CatSeg/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,FkEquipamentos")] tblCatSeg tblCatSeg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCatSeg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkEquipamentos = new SelectList(db.tblEquipamentosSeg, "Id", "Id", tblCatSeg.FkEquipamentos);
            return View(tblCatSeg);
        }

        // GET: CatSeg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCatSeg tblCatSeg = db.tblCatSeg.Find(id);
            if (tblCatSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblCatSeg);
        }

        // POST: CatSeg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCatSeg tblCatSeg = db.tblCatSeg.Find(id);
            db.tblCatSeg.Remove(tblCatSeg);
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
