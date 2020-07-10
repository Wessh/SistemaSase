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
    public class AcessibilidadeController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Acessibilidade
        public ActionResult Index()
        {
            return View(db.tblAcessibilidade.ToList());
        }

        // GET: Acessibilidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcessibilidade tblAcessibilidade = db.tblAcessibilidade.Find(id);
            if (tblAcessibilidade == null)
            {
                return HttpNotFound();
            }
            return View(tblAcessibilidade);
        }

        // GET: Acessibilidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acessibilidade/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RampaInterna,RampaExterna,BanheiroPdePnc")] tblAcessibilidade tblAcessibilidade)
        {
            if (ModelState.IsValid)
            {
                db.tblAcessibilidade.Add(tblAcessibilidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAcessibilidade);
        }

        // GET: Acessibilidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcessibilidade tblAcessibilidade = db.tblAcessibilidade.Find(id);
            if (tblAcessibilidade == null)
            {
                return HttpNotFound();
            }
            return View(tblAcessibilidade);
        }

        // POST: Acessibilidade/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RampaInterna,RampaExterna,BanheiroPdePnc")] tblAcessibilidade tblAcessibilidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAcessibilidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAcessibilidade);
        }

        // GET: Acessibilidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcessibilidade tblAcessibilidade = db.tblAcessibilidade.Find(id);
            if (tblAcessibilidade == null)
            {
                return HttpNotFound();
            }
            return View(tblAcessibilidade);
        }

        // POST: Acessibilidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAcessibilidade tblAcessibilidade = db.tblAcessibilidade.Find(id);
            db.tblAcessibilidade.Remove(tblAcessibilidade);
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
