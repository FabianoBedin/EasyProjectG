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
    public class tipos2Controller : Controller
    {
        private DBModel db = new DBModel();

        // GET: tipos
        public ActionResult Index()
        {
           var listaTipo1 = (from t in db.tipo
                                        join tg in db.tipo on t.tipoGrupo_tipoId equals tg.tipoId
                                        orderby tg.tipoNome, t.tipoNome
                             select new tipoViewModel
                                        {
                                            tipoId = t.tipoId,
                                            tipoDescricao = t.tipoDescricao,
                                            tipoGrupo = tg.tipoNome,
                                            tipoNome = t.tipoNome,
                                            tipoGrupo_tipoId = t.tipoGrupo_tipoId
                             }).AsEnumerable().ToList();

            var listaTipo = db.tipo.ToList();


            return View(listaTipo1);
            //return View(db.tipo.ToList());
        }

        // GET: tipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo tipo = db.tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: tipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoId,tipoNome,tipoGrupo_tipoId,tipoDescricao")] tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.tipo.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        // GET: tipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo tipo = db.tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipo);
        }

        // POST: tipos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoId,tipoNome,tipoGrupo_tipoId,tipoDescricao")] tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

        // GET: tipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo tipo = db.tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipo);
        }

        // POST: tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo tipo = db.tipo.Find(id);
            db.tipo.Remove(tipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult listaTipo()
        {
            var listaTipo1 = (from t in db.tipo
                              join tg in db.tipo on t.tipoGrupo_tipoId equals tg.tipoId
                              orderby tg.tipoNome, t.tipoNome
                              select new tipoViewModel
                              {
                                  tipoId = t.tipoId,
                                  tipoDescricao = t.tipoDescricao,
                                  tipoGrupo = tg.tipoNome,
                                  tipoNome = t.tipoNome,
                                  tipoGrupo_tipoId = t.tipoGrupo_tipoId
                              }).AsQueryable();

            var listaTipo = listaTipo1.ToList();

            var json2 = JsonConvert.SerializeObject(listaTipo.ToArray());

            return Json(listaTipo, JsonRequestBehavior.AllowGet);

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
