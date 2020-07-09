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
    public class OcoInternaController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: OcoInterna
        public ActionResult Index()
        {
            return View(db.tblOcoInternas.ToList());
        }

        // GET: OcoInterna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOcoInternas tblOcoInternas = db.tblOcoInternas.Find(id);
            if (tblOcoInternas == null)
            {
                return HttpNotFound();
            }
            return View(tblOcoInternas);
        }

        // GET: OcoInterna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OcoInterna/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Professores,Alunos,Gestores,Outros")] tblOcoInternas tblOcoInternas)
        {
            if (ModelState.IsValid)
            {
                db.tblOcoInternas.Add(tblOcoInternas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOcoInternas);
        }

        // GET: OcoInterna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOcoInternas tblOcoInternas = db.tblOcoInternas.Find(id);
            if (tblOcoInternas == null)
            {
                return HttpNotFound();
            }
            return View(tblOcoInternas);
        }

        // POST: OcoInterna/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Professores,Alunos,Gestores,Outros")] tblOcoInternas tblOcoInternas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOcoInternas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOcoInternas);
        }

        // GET: OcoInterna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOcoInternas tblOcoInternas = db.tblOcoInternas.Find(id);
            if (tblOcoInternas == null)
            {
                return HttpNotFound();
            }
            return View(tblOcoInternas);
        }

        // POST: OcoInterna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOcoInternas tblOcoInternas = db.tblOcoInternas.Find(id);
            db.tblOcoInternas.Remove(tblOcoInternas);
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
