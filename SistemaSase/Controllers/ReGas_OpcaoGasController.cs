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
    public class ReGas_OpcaoGasController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ReGas_OpcaoGas
        public ActionResult Index()
        {
            var gas_OpcaoGas = db.Gas_OpcaoGas.Include(g => g.tblGasCozinha).Include(g => g.tblOpGas);
            return View(gas_OpcaoGas.ToList());
        }

        // GET: ReGas_OpcaoGas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gas_OpcaoGas gas_OpcaoGas = db.Gas_OpcaoGas.Find(id);
            if (gas_OpcaoGas == null)
            {
                return HttpNotFound();
            }
            return View(gas_OpcaoGas);
        }

        // GET: ReGas_OpcaoGas/Create
        public ActionResult Create()
        {
            ViewBag.IdGas = new SelectList(db.tblGasCozinha, "Id", "Nome");
            ViewBag.IdOpGas = new SelectList(db.tblOpGas, "Id", "Id");
            return View();
        }

        // POST: ReGas_OpcaoGas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdGas,IdOpGas")] Gas_OpcaoGas gas_OpcaoGas)
        {
            if (ModelState.IsValid)
            {
                db.Gas_OpcaoGas.Add(gas_OpcaoGas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGas = new SelectList(db.tblGasCozinha, "Id", "Nome", gas_OpcaoGas.IdGas);
            ViewBag.IdOpGas = new SelectList(db.tblOpGas, "Id", "Id", gas_OpcaoGas.IdOpGas);
            return View(gas_OpcaoGas);
        }

        // GET: ReGas_OpcaoGas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gas_OpcaoGas gas_OpcaoGas = db.Gas_OpcaoGas.Find(id);
            if (gas_OpcaoGas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGas = new SelectList(db.tblGasCozinha, "Id", "Nome", gas_OpcaoGas.IdGas);
            ViewBag.IdOpGas = new SelectList(db.tblOpGas, "Id", "Id", gas_OpcaoGas.IdOpGas);
            return View(gas_OpcaoGas);
        }

        // POST: ReGas_OpcaoGas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdGas,IdOpGas")] Gas_OpcaoGas gas_OpcaoGas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gas_OpcaoGas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGas = new SelectList(db.tblGasCozinha, "Id", "Nome", gas_OpcaoGas.IdGas);
            ViewBag.IdOpGas = new SelectList(db.tblOpGas, "Id", "Id", gas_OpcaoGas.IdOpGas);
            return View(gas_OpcaoGas);
        }

        // GET: ReGas_OpcaoGas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gas_OpcaoGas gas_OpcaoGas = db.Gas_OpcaoGas.Find(id);
            if (gas_OpcaoGas == null)
            {
                return HttpNotFound();
            }
            return View(gas_OpcaoGas);
        }

        // POST: ReGas_OpcaoGas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gas_OpcaoGas gas_OpcaoGas = db.Gas_OpcaoGas.Find(id);
            db.Gas_OpcaoGas.Remove(gas_OpcaoGas);
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
