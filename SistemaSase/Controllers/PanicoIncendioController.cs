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
    public class PanicoIncendioController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: PanicoIncendio
        public ActionResult Index()
        {
            return View(db.tblPanicoIncendio.ToList());
        }

        // GET: PanicoIncendio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPanicoIncendio tblPanicoIncendio = db.tblPanicoIncendio.Find(id);
            if (tblPanicoIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblPanicoIncendio);
        }

        // GET: PanicoIncendio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanicoIncendio/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Treinamento,Sinalizacao")] tblPanicoIncendio tblPanicoIncendio)
        {
            if (ModelState.IsValid)
            {
                db.tblPanicoIncendio.Add(tblPanicoIncendio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPanicoIncendio);
        }

        // GET: PanicoIncendio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPanicoIncendio tblPanicoIncendio = db.tblPanicoIncendio.Find(id);
            if (tblPanicoIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblPanicoIncendio);
        }

        // POST: PanicoIncendio/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Treinamento,Sinalizacao")] tblPanicoIncendio tblPanicoIncendio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPanicoIncendio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPanicoIncendio);
        }

        // GET: PanicoIncendio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPanicoIncendio tblPanicoIncendio = db.tblPanicoIncendio.Find(id);
            if (tblPanicoIncendio == null)
            {
                return HttpNotFound();
            }
            return View(tblPanicoIncendio);
        }

        // POST: PanicoIncendio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPanicoIncendio tblPanicoIncendio = db.tblPanicoIncendio.Find(id);
            db.tblPanicoIncendio.Remove(tblPanicoIncendio);
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
