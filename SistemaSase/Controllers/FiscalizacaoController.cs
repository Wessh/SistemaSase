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
    public class FiscalizacaoController : Controller
    {
        private SistemaSaseEntities db = new SistemaSaseEntities();

        // GET: Fiscalizacao
        public ActionResult Index()
        {
            var tblFiscalizacao = db.tblFiscalizacao.Include(t => t.tblAcessibilidade).Include(t => t.tblArredoresUeb).Include(t => t.tblCatSeg).Include(t => t.tblEstFisica).Include(t => t.tblEstReparo).Include(t => t.tblRegistro).Include(t => t.tblUeb).Include(t => t.tblGasCozinha).Include(t => t.tblIluminacao).Include(t => t.tblListaTel).Include(t => t.tblLivroRegistro).Include(t => t.tblOcoInternas).Include(t => t.tblPanicoIncendio).Include(t => t.tblProjViolencia).Include(t => t.tblSisHidraSaniRep).Include(t => t.tblSisIncendio).Include(t => t.tblTransito);
            return View(tblFiscalizacao.ToList());
        }

        // GET: Fiscalizacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFiscalizacao tblFiscalizacao = db.tblFiscalizacao.Find(id);
            if (tblFiscalizacao == null)
            {
                return HttpNotFound();
            }
            return View(tblFiscalizacao);
        }

        // GET: Fiscalizacao/Create
        public ActionResult Create()
        {
            ViewBag.FkAcessibilidade = new SelectList(db.tblAcessibilidade, "Id", "Id");
            ViewBag.FkArredoresUeb = new SelectList(db.tblArredoresUeb, "Id", "Outros");
            ViewBag.FkCatSeg = new SelectList(db.tblCatSeg, "Id", "Nome");
            ViewBag.FkEstFisica = new SelectList(db.tblEstFisica, "Id", "Id");
            ViewBag.FkEstReparo = new SelectList(db.tblEstReparo, "Id", "Id");
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome");
            ViewBag.FkUeb = new SelectList(db.tblUeb, "Id", "Nome");
            ViewBag.FkGasCozinha = new SelectList(db.tblGasCozinha, "Id", "Nome");
            ViewBag.FkIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome");
            ViewBag.FkListaTel = new SelectList(db.tblListaTel, "Id", "Id");
            ViewBag.FkLivroRegistro = new SelectList(db.tblLivroRegistro, "Id", "Id");
            ViewBag.FkOcoInternas = new SelectList(db.tblOcoInternas, "id", "Outros");
            ViewBag.FkPanicoIncendio = new SelectList(db.tblPanicoIncendio, "Id", "Id");
            ViewBag.FkProjViolencia = new SelectList(db.tblProjViolencia, "Id", "Id");
            ViewBag.FkSisHidraSaniRep = new SelectList(db.tblSisHidraSaniRep, "Id", "Id");
            ViewBag.FkSisIncendio = new SelectList(db.tblSisIncendio, "Id", "Id");
            ViewBag.FkTransito = new SelectList(db.tblTransito, "Id", "Id");
            return View();
        }

        // POST: Fiscalizacao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FkUeb,FkRegistro,FkLivroRegistro,FkCatSeg,FkEstFisica,FkIluminacao,FkSisHidraSaniRep,FkSisIncendio,FkGasCozinha,FkPanicoIncendio,FkTransito,FkAcessibilidade,FkArredoresUeb,FkProjViolencia,FkListaTel,FkOcoInternas,FkEstReparo")] tblFiscalizacao tblFiscalizacao)
        {
            if (ModelState.IsValid)
            {
                db.tblFiscalizacao.Add(tblFiscalizacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkAcessibilidade = new SelectList(db.tblAcessibilidade, "Id", "Id", tblFiscalizacao.FkAcessibilidade);
            ViewBag.FkArredoresUeb = new SelectList(db.tblArredoresUeb, "Id", "Outros", tblFiscalizacao.FkArredoresUeb);
            ViewBag.FkCatSeg = new SelectList(db.tblCatSeg, "Id", "Nome", tblFiscalizacao.FkCatSeg);
            ViewBag.FkEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", tblFiscalizacao.FkEstFisica);
            ViewBag.FkEstReparo = new SelectList(db.tblEstReparo, "Id", "Id", tblFiscalizacao.FkEstReparo);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblFiscalizacao.FkRegistro);
            ViewBag.FkUeb = new SelectList(db.tblUeb, "Id", "Nome", tblFiscalizacao.FkUeb);
            ViewBag.FkGasCozinha = new SelectList(db.tblGasCozinha, "Id", "Nome", tblFiscalizacao.FkGasCozinha);
            ViewBag.FkIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", tblFiscalizacao.FkIluminacao);
            ViewBag.FkListaTel = new SelectList(db.tblListaTel, "Id", "Id", tblFiscalizacao.FkListaTel);
            ViewBag.FkLivroRegistro = new SelectList(db.tblLivroRegistro, "Id", "Id", tblFiscalizacao.FkLivroRegistro);
            ViewBag.FkOcoInternas = new SelectList(db.tblOcoInternas, "id", "Outros", tblFiscalizacao.FkOcoInternas);
            ViewBag.FkPanicoIncendio = new SelectList(db.tblPanicoIncendio, "Id", "Id", tblFiscalizacao.FkPanicoIncendio);
            ViewBag.FkProjViolencia = new SelectList(db.tblProjViolencia, "Id", "Id", tblFiscalizacao.FkProjViolencia);
            ViewBag.FkSisHidraSaniRep = new SelectList(db.tblSisHidraSaniRep, "Id", "Id", tblFiscalizacao.FkSisHidraSaniRep);
            ViewBag.FkSisIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", tblFiscalizacao.FkSisIncendio);
            ViewBag.FkTransito = new SelectList(db.tblTransito, "Id", "Id", tblFiscalizacao.FkTransito);
            return View(tblFiscalizacao);
        }

        // GET: Fiscalizacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFiscalizacao tblFiscalizacao = db.tblFiscalizacao.Find(id);
            if (tblFiscalizacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkAcessibilidade = new SelectList(db.tblAcessibilidade, "Id", "Id", tblFiscalizacao.FkAcessibilidade);
            ViewBag.FkArredoresUeb = new SelectList(db.tblArredoresUeb, "Id", "Outros", tblFiscalizacao.FkArredoresUeb);
            ViewBag.FkCatSeg = new SelectList(db.tblCatSeg, "Id", "Nome", tblFiscalizacao.FkCatSeg);
            ViewBag.FkEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", tblFiscalizacao.FkEstFisica);
            ViewBag.FkEstReparo = new SelectList(db.tblEstReparo, "Id", "Id", tblFiscalizacao.FkEstReparo);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblFiscalizacao.FkRegistro);
            ViewBag.FkUeb = new SelectList(db.tblUeb, "Id", "Nome", tblFiscalizacao.FkUeb);
            ViewBag.FkGasCozinha = new SelectList(db.tblGasCozinha, "Id", "Nome", tblFiscalizacao.FkGasCozinha);
            ViewBag.FkIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", tblFiscalizacao.FkIluminacao);
            ViewBag.FkListaTel = new SelectList(db.tblListaTel, "Id", "Id", tblFiscalizacao.FkListaTel);
            ViewBag.FkLivroRegistro = new SelectList(db.tblLivroRegistro, "Id", "Id", tblFiscalizacao.FkLivroRegistro);
            ViewBag.FkOcoInternas = new SelectList(db.tblOcoInternas, "id", "Outros", tblFiscalizacao.FkOcoInternas);
            ViewBag.FkPanicoIncendio = new SelectList(db.tblPanicoIncendio, "Id", "Id", tblFiscalizacao.FkPanicoIncendio);
            ViewBag.FkProjViolencia = new SelectList(db.tblProjViolencia, "Id", "Id", tblFiscalizacao.FkProjViolencia);
            ViewBag.FkSisHidraSaniRep = new SelectList(db.tblSisHidraSaniRep, "Id", "Id", tblFiscalizacao.FkSisHidraSaniRep);
            ViewBag.FkSisIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", tblFiscalizacao.FkSisIncendio);
            ViewBag.FkTransito = new SelectList(db.tblTransito, "Id", "Id", tblFiscalizacao.FkTransito);
            return View(tblFiscalizacao);
        }

        // POST: Fiscalizacao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FkUeb,FkRegistro,FkLivroRegistro,FkCatSeg,FkEstFisica,FkIluminacao,FkSisHidraSaniRep,FkSisIncendio,FkGasCozinha,FkPanicoIncendio,FkTransito,FkAcessibilidade,FkArredoresUeb,FkProjViolencia,FkListaTel,FkOcoInternas,FkEstReparo")] tblFiscalizacao tblFiscalizacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFiscalizacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkAcessibilidade = new SelectList(db.tblAcessibilidade, "Id", "Id", tblFiscalizacao.FkAcessibilidade);
            ViewBag.FkArredoresUeb = new SelectList(db.tblArredoresUeb, "Id", "Outros", tblFiscalizacao.FkArredoresUeb);
            ViewBag.FkCatSeg = new SelectList(db.tblCatSeg, "Id", "Nome", tblFiscalizacao.FkCatSeg);
            ViewBag.FkEstFisica = new SelectList(db.tblEstFisica, "Id", "Id", tblFiscalizacao.FkEstFisica);
            ViewBag.FkEstReparo = new SelectList(db.tblEstReparo, "Id", "Id", tblFiscalizacao.FkEstReparo);
            ViewBag.FkRegistro = new SelectList(db.tblRegistro, "Id", "Nome", tblFiscalizacao.FkRegistro);
            ViewBag.FkUeb = new SelectList(db.tblUeb, "Id", "Nome", tblFiscalizacao.FkUeb);
            ViewBag.FkGasCozinha = new SelectList(db.tblGasCozinha, "Id", "Nome", tblFiscalizacao.FkGasCozinha);
            ViewBag.FkIluminacao = new SelectList(db.tblIluminacao, "Id", "Nome", tblFiscalizacao.FkIluminacao);
            ViewBag.FkListaTel = new SelectList(db.tblListaTel, "Id", "Id", tblFiscalizacao.FkListaTel);
            ViewBag.FkLivroRegistro = new SelectList(db.tblLivroRegistro, "Id", "Id", tblFiscalizacao.FkLivroRegistro);
            ViewBag.FkOcoInternas = new SelectList(db.tblOcoInternas, "id", "Outros", tblFiscalizacao.FkOcoInternas);
            ViewBag.FkPanicoIncendio = new SelectList(db.tblPanicoIncendio, "Id", "Id", tblFiscalizacao.FkPanicoIncendio);
            ViewBag.FkProjViolencia = new SelectList(db.tblProjViolencia, "Id", "Id", tblFiscalizacao.FkProjViolencia);
            ViewBag.FkSisHidraSaniRep = new SelectList(db.tblSisHidraSaniRep, "Id", "Id", tblFiscalizacao.FkSisHidraSaniRep);
            ViewBag.FkSisIncendio = new SelectList(db.tblSisIncendio, "Id", "Id", tblFiscalizacao.FkSisIncendio);
            ViewBag.FkTransito = new SelectList(db.tblTransito, "Id", "Id", tblFiscalizacao.FkTransito);
            return View(tblFiscalizacao);
        }

        // GET: Fiscalizacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFiscalizacao tblFiscalizacao = db.tblFiscalizacao.Find(id);
            if (tblFiscalizacao == null)
            {
                return HttpNotFound();
            }
            return View(tblFiscalizacao);
        }

        // POST: Fiscalizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFiscalizacao tblFiscalizacao = db.tblFiscalizacao.Find(id);
            db.tblFiscalizacao.Remove(tblFiscalizacao);
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
