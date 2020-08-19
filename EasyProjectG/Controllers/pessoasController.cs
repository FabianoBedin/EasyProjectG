using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyProjectG.Models;
using EasyProjectG.ViewModel;

namespace EasyProjectG.Controllers
{
    public class pessoasController : Controller
    {
        private DBModel db = new DBModel();

        // GET: pessoas
        public ActionResult Index()
        {
            var pessoa = db.pessoa.Include(p => p.entidade);
            return View(pessoa.ToList());
        }

        // GET: pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: pessoas/Create
        public ActionResult Create(int? id)
        {
            ViewBag.pessoa_entidadeId = new SelectList(db.entidade.Where(e =>e.entidadeId == id), "entidadeId", "entidadeRazaoSocial");

            return PartialView();
        }

        // POST: pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pessoaId,pessoaNome,pessoaLinkLattes,pessoaEspecialidade,pessoaFormacao,pessoaFoto,pessoa_entidadeId,pessoaEmail,pessoaFone")] pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("../entidades/Index");
            }

            ViewBag.pessoa_entidadeId = new SelectList(db.entidade, "entidadeId", "entidadeRazaoSocial", pessoa.pessoa_entidadeId);
            return PartialView(pessoa);
        }

        // GET: pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoa_entidadeId = new SelectList(db.entidade, "entidadeId", "entidadeRazaoSocial", pessoa.pessoa_entidadeId);
            return PartialView(pessoa);
        }

        // POST: pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pessoaId,pessoaNome,pessoaLinkLattes,pessoaEspecialidade,pessoaFormacao,pessoaFoto,pessoaEmail,pessoaFone,pessoa_entidadeId")] pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../entidades/Index");
            }
            ViewBag.pessoa_entidadeId = new SelectList(db.entidade, "entidadeId", "entidadeRazaoSocial", pessoa.pessoa_entidadeId);
            return PartialView(pessoa);
        }

        // GET: pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoa_entidadeId = new SelectList(db.entidade, "entidadeId", "entidadeRazaoSocial", pessoa.pessoa_entidadeId);
            return PartialView(pessoa);
        }

        // POST: pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoa pessoa = db.pessoa.Find(id);
            try
            {
                db.pessoa.Remove(pessoa);
                db.SaveChanges();
                return RedirectToAction("../entidades/Index");
            }
            catch
            {
                return RedirectToAction("../entidades/Index");
            }
        }

        public JsonResult listaPessoa(int id)
        {
            var lista1 = (from li in db.pessoa
                          orderby li.pessoaNome
                          where li.pessoa_entidadeId == id
                          select new pessoaViewModel
                          {
                              pessoaId = li.pessoaId,
                              pessoaFoto = li.pessoaFoto,
                              pessoaNome = li.pessoaNome,
                              pessoaEmail = li.pessoaEmail,
                              pessoaFone = li.pessoaFone,
                              pessoaEspecialidade = li.pessoaEspecialidade,
                              pessoaFormacao = li.pessoaFormacao
                          }).AsQueryable();

            var lista = lista1.ToList();

            //var json2 = JsonConvert.SerializeObject(lista.ToArray());

            return Json(lista, JsonRequestBehavior.AllowGet);

        }
        public JsonResult listaTime(int id)
        {
            var lista1 = (from t in db.projeto
                          join tp in db.projetoPessoa on (t.projetoId) equals tp.projetoPessoa_projetoId
                          join p in db.pessoa on (tp.projetoPessoa_pessoaId) equals p.pessoaId
                          join f in db.funcao on (tp.projetoPessoa_funcaoId) equals f.funcaoId
                          join e in db.entidade on (p.pessoa_entidadeId) equals e.entidadeId
                          orderby t.projetoNome, p.pessoaNome
                          where t.projetoId == id
                          select new projetoPessoaViewModel
                          {
                              entidadeSigla = e.entidadeSigla,
                              entidadeCor = e.entidadeCor,
                              funcaoDescricao = f.funcaoDescricao,
                              projetoPessoaQtdeSemana = tp.projetoPessoaQtdeSemana,
                              projetoPessoaCustoHora = tp.projetoPessoaCustoHora,
                              projetoPessoaQtdeHoraSemanal = tp.projetoPessoaQtdeHoraSemanal,
                              pessoaId = p.pessoaId,
                              pessoaFoto = p.pessoaFoto,
                              pessoaNome = p.pessoaNome,
                              pessoaEmail = p.pessoaEmail,
                              pessoaFone = p.pessoaFone,
                              pessoaEspecialidade = p.pessoaEspecialidade,
                              pessoaFormacao = p.pessoaFormacao
                          }).AsQueryable();

            var lista = lista1.ToList();

            //var json2 = JsonConvert.SerializeObject(lista.ToArray());

            return Json(lista, JsonRequestBehavior.AllowGet);

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
