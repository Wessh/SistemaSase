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
    public class SisHidraSaniRepController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: SisHidraSaniRep
        public ActionResult Index()
        {
            return View(db.tblSisHidraSaniRep.ToList());
        }

        // GET: SisHidraSaniRep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisHidraSaniRep tblSisHidraSaniRep = db.tblSisHidraSaniRep.Find(id);
            if (tblSisHidraSaniRep == null)
            {
                return HttpNotFound();
            }
            return View(tblSisHidraSaniRep);
        }

        // GET: SisHidraSaniRep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SisHidraSaniRep/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Banheiros,Fossa,Cisterna,CaixaAgua")] tblSisHidraSaniRep tblSisHidraSaniRep)
        {
            if (ModelState.IsValid)
            {
                db.tblSisHidraSaniRep.Add(tblSisHidraSaniRep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSisHidraSaniRep);
        }

        // GET: SisHidraSaniRep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisHidraSaniRep tblSisHidraSaniRep = db.tblSisHidraSaniRep.Find(id);
            if (tblSisHidraSaniRep == null)
            {
                return HttpNotFound();
            }
            return View(tblSisHidraSaniRep);
        }

        // POST: SisHidraSaniRep/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Banheiros,Fossa,Cisterna,CaixaAgua")] tblSisHidraSaniRep tblSisHidraSaniRep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSisHidraSaniRep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSisHidraSaniRep);
        }

        // GET: SisHidraSaniRep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSisHidraSaniRep tblSisHidraSaniRep = db.tblSisHidraSaniRep.Find(id);
            if (tblSisHidraSaniRep == null)
            {
                return HttpNotFound();
            }
            return View(tblSisHidraSaniRep);
        }

        // POST: SisHidraSaniRep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSisHidraSaniRep tblSisHidraSaniRep = db.tblSisHidraSaniRep.Find(id);
            db.tblSisHidraSaniRep.Remove(tblSisHidraSaniRep);
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
