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
    public class RegistroController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Registro
        public ActionResult Index()
        {
            return View(db.tblRegistro.ToList());
        }

        // GET: Registro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistro tblRegistro = db.tblRegistro.Find(id);
            if (tblRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistro);
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Matricula,Senha")] tblRegistro tblRegistro)
        {
            if (ModelState.IsValid)
            {
                db.tblRegistro.Add(tblRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRegistro);
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistro tblRegistro = db.tblRegistro.Find(id);
            if (tblRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistro);
        }

        // POST: Registro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Matricula,Senha")] tblRegistro tblRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRegistro);
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistro tblRegistro = db.tblRegistro.Find(id);
            if (tblRegistro == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRegistro tblRegistro = db.tblRegistro.Find(id);
            db.tblRegistro.Remove(tblRegistro);
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
