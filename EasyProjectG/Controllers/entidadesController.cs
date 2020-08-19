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
using Newtonsoft.Json;

namespace EasyProjectG.Controllers
{
    public class entidadesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: entidades
        public ActionResult Index()
        {
            var entidade = db.entidade.Include(e => e.nucleo).Include(e => e.tipo);
            return View(entidade.ToList());
        }

        // GET: entidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidade entidade = db.entidade.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            return View(entidade);
        }

        // GET: entidades/Create
        public ActionResult Create()
        {
            ViewBag.entidade_nucleoId = new SelectList(db.nucleo, "nucleoId", "nucleoNome", 8);
            ViewBag.entidade_tipoId = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 7), "tipoId", "tipoNome");
            ViewBag.customColors = (from t in db.tipo
                                    where t.tipoGrupo_tipoId == 86
                                    select new tipoViewModel
                                    {
                                        tipoNome = t.tipoNome,
                                        tipoDescricao = t.tipoDescricao
                                    }).AsEnumerable().ToList();
            ViewBag.entidadeCor = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 86), "tipoNome", "tipoNome");
            return PartialView();
        }

        // POST: entidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "entidadeId,entidadeRazaoSocial,entidadeSigla,entidadeFone,entidadeSite,entidadeFacebook,entidadeWhatsapp,entidade_nucleoId,entidade_tipoId,entidadeLogradouro,entidadeCEP,entidadeBairro,entidadeCidade,entidadePais,entidadeEstado,entidadeCor")] entidade entidade)
        {
            if (ModelState.IsValid)
            {
                db.entidade.Add(entidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entidade_nucleoId = new SelectList(db.nucleo, "nucleoId", "nucleoNome", entidade.entidade_nucleoId);
            ViewBag.entidade_tipoId = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 7), "tipoId", "tipoNome", entidade.entidade_tipoId);
            ViewBag.customColors = (from t in db.tipo
                                    where t.tipoGrupo_tipoId == 86
                                    select new tipoViewModel
                                    {
                                        tipoNome = t.tipoNome,
                                        tipoDescricao = t.tipoDescricao
                                    }).AsEnumerable().ToList();
            ViewBag.entidadeCor = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 86), "tipoNome", "tipoNome", entidade.entidadeCor);
            return PartialView(entidade);
        }

        // GET: entidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidade entidade = db.entidade.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.entidade_nucleoId = new SelectList(db.nucleo, "nucleoId", "nucleoNome", entidade.entidade_nucleoId);
            ViewBag.entidade_tipoId = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 7), "tipoId", "tipoNome", entidade.entidade_tipoId);
            ViewBag.customColors = (from t in db.tipo
                                    where t.tipoGrupo_tipoId == 86
                                    select new tipoViewModel
                                    {
                                        tipoNome = t.tipoNome,
                                        tipoDescricao = t.tipoDescricao
                                    }).AsEnumerable().ToList();
            ViewBag.entidadeCor  =  new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 86), "tipoNome", "tipoNome", entidade.entidadeCor);

            return PartialView(entidade);
        }

        // POST: entidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "entidadeId,entidadeRazaoSocial,entidadeSigla,entidadeFone,entidadeEndereco,entidadeSite,entidadeFacebook,entidadeWhatsapp,entidadeLogradouro,entidadeBairro,entidadeCidade,entidadePais,entidadeEstado,entidadeCor,entidadeCEP,entidade_nucleoId,entidade_tipoId")] entidade entidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entidade_nucleoId = new SelectList(db.nucleo, "nucleoId", "nucleoNome", entidade.entidade_nucleoId);
            ViewBag.entidade_tipoId = new SelectList(db.tipo, "tipoId", "tipoNome", entidade.entidade_tipoId);
            return View(entidade);
        }


        // GET: entidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidade entidade = db.entidade.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            return View(entidade);
        }

        // POST: entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entidade entidade = db.entidade.Find(id);
            db.entidade.Remove(entidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult listaEntidade()
        {
           var lista1 = (from e in db.entidade
                              orderby e.entidadeSigla
                              select new entidadeViewModel
                              {
                                  entidadeId = e.entidadeId,
                                  entidadeRazaoSocial = e.entidadeRazaoSocial,
                                  entidadeSigla = e.entidadeSigla,
                                  entidadeSite = e.entidadeSite,
                                  entidadeWhatsapp = e.entidadeWhatsapp,
                                  entidadeCidade = e.entidadeCidade,
                                  entidadeCor = e.entidadeCor,
                                  entidadeLogradouro = e.entidadeLogradouro,
                                  entidadeBairro = e.entidadeBairro,
                                  entidadePais = e.entidadePais,
                                  entidadeCEP = e.entidadeCEP,
                                  entidadeLetra = e.entidadeSigla.Substring(0,1)
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
