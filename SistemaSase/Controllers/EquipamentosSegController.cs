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
    public class EquipamentosSegController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: EquipamentosSeg
        public ActionResult Index()
        {
            return View(db.tblEquipamentosSeg.ToList());
        }

        // GET: EquipamentosSeg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamentosSeg tblEquipamentosSeg = db.tblEquipamentosSeg.Find(id);
            if (tblEquipamentosSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamentosSeg);
        }

        // GET: EquipamentosSeg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipamentosSeg/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fardamento,Apito,CapaChuva,Colete,Tonfa,Lanterna,Cracha,Quepe,Revolver,Radio")] tblEquipamentosSeg tblEquipamentosSeg)
        {
            if (ModelState.IsValid)
            {
                db.tblEquipamentosSeg.Add(tblEquipamentosSeg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEquipamentosSeg);
        }

        // GET: EquipamentosSeg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamentosSeg tblEquipamentosSeg = db.tblEquipamentosSeg.Find(id);
            if (tblEquipamentosSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamentosSeg);
        }

        // POST: EquipamentosSeg/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fardamento,Apito,CapaChuva,Colete,Tonfa,Lanterna,Cracha,Quepe,Revolver,Radio")] tblEquipamentosSeg tblEquipamentosSeg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEquipamentosSeg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEquipamentosSeg);
        }

        // GET: EquipamentosSeg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEquipamentosSeg tblEquipamentosSeg = db.tblEquipamentosSeg.Find(id);
            if (tblEquipamentosSeg == null)
            {
                return HttpNotFound();
            }
            return View(tblEquipamentosSeg);
        }

        // POST: EquipamentosSeg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEquipamentosSeg tblEquipamentosSeg = db.tblEquipamentosSeg.Find(id);
            db.tblEquipamentosSeg.Remove(tblEquipamentosSeg);
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
