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
    public class IluReparoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: IluReparo
        public ActionResult Index()
        {
            return View(db.tblIluReparo.ToList());
        }

        // GET: IluReparo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluReparo tblIluReparo = db.tblIluReparo.Find(id);
            if (tblIluReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblIluReparo);
        }

        // GET: IluReparo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IluReparo/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fiacao,CaixaForca,Interruptores,Tomadas,ArCon,Ventilador,Geladeira,Frezzer,Bebedouro")] tblIluReparo tblIluReparo)
        {
            if (ModelState.IsValid)
            {
                db.tblIluReparo.Add(tblIluReparo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblIluReparo);
        }

        // GET: IluReparo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluReparo tblIluReparo = db.tblIluReparo.Find(id);
            if (tblIluReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblIluReparo);
        }

        // POST: IluReparo/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fiacao,CaixaForca,Interruptores,Tomadas,ArCon,Ventilador,Geladeira,Frezzer,Bebedouro")] tblIluReparo tblIluReparo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIluReparo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblIluReparo);
        }

        // GET: IluReparo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIluReparo tblIluReparo = db.tblIluReparo.Find(id);
            if (tblIluReparo == null)
            {
                return HttpNotFound();
            }
            return View(tblIluReparo);
        }

        // POST: IluReparo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIluReparo tblIluReparo = db.tblIluReparo.Find(id);
            db.tblIluReparo.Remove(tblIluReparo);
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
