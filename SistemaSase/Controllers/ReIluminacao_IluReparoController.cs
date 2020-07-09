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
    public class ReIluminacao_IluReparoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: ReIluminacao_IluReparo
        public ActionResult Index()
        {
            var iluminacao_IluReparo = db.Iluminacao_IluReparo.Include(i => i.tblIluminacao).Include(i => i.tblIluReparo);
            return View(iluminacao_IluReparo.ToList());
        }

        // GET: ReIluminacao_IluReparo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iluminacao_IluReparo iluminacao_IluReparo = db.Iluminacao_IluReparo.Find(id);
            if (iluminacao_IluReparo == null)
            {
                return HttpNotFound();
            }
            return View(iluminacao_IluReparo);
        }

        // GET: ReIluminacao_IluReparo/Create
        public ActionResult Create()
        {
            ViewBag.IdIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome");
            ViewBag.IdIluReparo = new SelectList(db.tblIluReparo, "Id", "Id");
            return View();
        }

        // POST: ReIluminacao_IluReparo/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdIluminacao,IdIluReparo")] Iluminacao_IluReparo iluminacao_IluReparo)
        {
            if (ModelState.IsValid)
            {
                db.Iluminacao_IluReparo.Add(iluminacao_IluReparo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", iluminacao_IluReparo.IdIluminacao);
            ViewBag.IdIluReparo = new SelectList(db.tblIluReparo, "Id", "Id", iluminacao_IluReparo.IdIluReparo);
            return View(iluminacao_IluReparo);
        }

        // GET: ReIluminacao_IluReparo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iluminacao_IluReparo iluminacao_IluReparo = db.Iluminacao_IluReparo.Find(id);
            if (iluminacao_IluReparo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", iluminacao_IluReparo.IdIluminacao);
            ViewBag.IdIluReparo = new SelectList(db.tblIluReparo, "Id", "Id", iluminacao_IluReparo.IdIluReparo);
            return View(iluminacao_IluReparo);
        }

        // POST: ReIluminacao_IluReparo/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdIluminacao,IdIluReparo")] Iluminacao_IluReparo iluminacao_IluReparo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iluminacao_IluReparo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", iluminacao_IluReparo.IdIluminacao);
            ViewBag.IdIluReparo = new SelectList(db.tblIluReparo, "Id", "Id", iluminacao_IluReparo.IdIluReparo);
            return View(iluminacao_IluReparo);
        }

        // GET: ReIluminacao_IluReparo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iluminacao_IluReparo iluminacao_IluReparo = db.Iluminacao_IluReparo.Find(id);
            if (iluminacao_IluReparo == null)
            {
                return HttpNotFound();
            }
            return View(iluminacao_IluReparo);
        }

        // POST: ReIluminacao_IluReparo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iluminacao_IluReparo iluminacao_IluReparo = db.Iluminacao_IluReparo.Find(id);
            db.Iluminacao_IluReparo.Remove(iluminacao_IluReparo);
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
