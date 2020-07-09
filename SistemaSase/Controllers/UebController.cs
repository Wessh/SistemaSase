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
    public class UebController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Ueb
        public ActionResult Index()
        {
            var tblUeb = db.tblUeb.Include(t => t.tblGestor).Include(t => t.tblRegistro);
            return View(tblUeb.ToList());
        }

        // GET: Ueb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUeb tblUeb = db.tblUeb.Find(id);
            if (tblUeb == null)
            {
                return HttpNotFound();
            }
            return View(tblUeb);
        }

        // GET: Ueb/Create
        public ActionResult Create()
        {
            ViewBag.FKGestor = new SelectList(db.tblGestor, "Id", "Nome");
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome");
            return View();
        }

        // POST: Ueb/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,Nucleo,FKGestor,Contato,Contato2,DataHora,FkRegistro")] tblUeb tblUeb)
        {
            if (ModelState.IsValid)
            {
                db.tblUeb.Add(tblUeb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKGestor = new SelectList(db.tblGestor, "Id", "Nome", tblUeb.FKGestor);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblUeb.FkRegistro);
            return View(tblUeb);
        }

        // GET: Ueb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUeb tblUeb = db.tblUeb.Find(id);
            if (tblUeb == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKGestor = new SelectList(db.tblGestor, "Id", "Nome", tblUeb.FKGestor);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblUeb.FkRegistro);
            return View(tblUeb);
        }

        // POST: Ueb/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,Nucleo,FKGestor,Contato,Contato2,DataHora,FkRegistro")] tblUeb tblUeb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUeb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKGestor = new SelectList(db.tblGestor, "Id", "Nome", tblUeb.FKGestor);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblUeb.FkRegistro);
            return View(tblUeb);
        }

        // GET: Ueb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUeb tblUeb = db.tblUeb.Find(id);
            if (tblUeb == null)
            {
                return HttpNotFound();
            }
            return View(tblUeb);
        }

        // POST: Ueb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUeb tblUeb = db.tblUeb.Find(id);
            db.tblUeb.Remove(tblUeb);
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
