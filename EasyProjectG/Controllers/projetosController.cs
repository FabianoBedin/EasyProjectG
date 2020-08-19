using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EasyProjectG.Models;
using EasyProjectG.ViewModel;
using Newtonsoft.Json;

namespace EasyProjectG.Controllers
{
    public class projetosController : Controller
    {
        private DBModel db = new DBModel();

        public class anexo
        {
            public string anexoNome { get; set; }
            public string anexoTipo { get; set; }
            public DateTime? anexoDataCriacao { get; set; }
            public string anexoUsuario { get; set; }
            public DateTime? anexoDataAlteracao { get; set; }
            public long anexoTamanho { get; set; }
        }
        List<anexo> anexos = new List<anexo>();

        // GET: projetos
        public ActionResult Index()
        {
            var projeto = db.projeto.Include(p => p.pessoa).Include(p => p.tipo).Include(p => p.entidade);
            return View(projeto.ToList());
        }

        // GET: projetos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projeto projeto = db.projeto.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // GET: projetos/Create
        public ActionResult Create()
        {
            ViewBag.projetoResp_pessoaId = new SelectList(db.pessoa, "pessoaId", "pessoaNome");
            ViewBag.projeto_tipoId = new SelectList(db.tipo, "tipoId", "tipoNome");
            return PartialView();
        }

        // POST: projetos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projetoId,projeto_tipoId,projeto_statusTipoId,projetoNome,projetoObjetivo,projetoData,projetoDataIni,projetoDataFim,projetoSemestre,projetoResp_pessoaId,projetoContaCusto,projetoContaIntegracao,projetoCompartilhado,projeto_usuarioId,projetoDataAtualizado,projetoTitulo,projetoPasta,projetoVinculo_projetoId,projetoMonitoramento,projetoResultadoPrevisto,projetoTaxas,projeto_setorId,projeto_entidadeId")] projeto projeto)
        {
            if (ModelState.IsValid)
            {
                db.projeto.Add(projeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projetoResp_pessoaId = new SelectList(db.pessoa, "pessoaId", "pessoaNome", projeto.projetoResp_pessoaId);
            ViewBag.projeto_tipoId = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 15), "tipoId", "tipoNome", projeto.projeto_tipoId);
            ViewBag.projeto_statusTipoId = new SelectList(db.tipo.Where(t => t.tipoGrupo_tipoId == 5), "tipoId", "tipoNome", projeto.projeto_tipoId);
            return View(projeto);
        }

        // GET: projetos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projeto projeto = db.projeto.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            ViewBag.projetoResp_pessoaId = new SelectList(db.pessoa, "pessoaId", "pessoaNome", projeto.projetoResp_pessoaId);
            ViewBag.projeto_tipoId = new SelectList(db.tipo, "tipoId", "tipoNome", projeto.projeto_tipoId);
            return View(projeto);
        }

        // POST: projetos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projetoId,projeto_tipoId,projetoNome,projetoObjetivo,projetoData,projetoDataIni,projetoDataFim,projetoSemestre,projetoResp_pessoaId,projetoContaCusto,projetoContaIntegracao,projetoCompartilhado,projeto_usuarioId,projetoDataAtualizado,projetoTitulo,projetoPasta,projetoVinculo_projetoId,projetoMonitoramento,projetoResultadoPrevisto,projetoTaxas,projeto_setorId,projeto_entidadeId")] projeto projeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projetoResp_pessoaId = new SelectList(db.pessoa, "pessoaId", "pessoaNome", projeto.projetoResp_pessoaId);
            ViewBag.projeto_tipoId = new SelectList(db.tipo, "tipoId", "tipoNome", projeto.projeto_tipoId);
            return View(projeto);
        }

        // GET: projetos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projeto projeto = db.projeto.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // POST: projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projeto projeto = db.projeto.Find(id);
            db.projeto.Remove(projeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult listaProjeto()
        {
            var lista1 = (from l in db.projeto
                          orderby l.projetoDataIni descending
                          select new projetoViewModel
                          {
                              projetoId = l.projetoId,
                              projetoNome = l.projetoNome,
                              projetoData = l.projetoData.ToString(),
                              projetoDataIni = l.projetoDataIni.ToString(),
                              projetoDataFim = l.projetoDataFim.ToString(),
                              projetoResponsavel = l.pessoa.pessoaNome,
                              projetoDataAtualizado = l.projetoDataAtualizado.ToString(),
                              projetoCor = l.projetoCor,
                              projetoLetra = l.projetoNome.Substring(0, 1),
                              projetoGestora = l.entidade.entidadeSigla,
                              projetoObjetivo = l.projetoObjetivo
                          }).AsQueryable();

            var lista = lista1.ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public JsonResult listaProjeto2(int id)
        {
            var lista0 = (from p in db.projeto
                          join pe in db.projetoEntidade on p.projetoId equals pe.projetoEntidade_projetoId
                          join e in db.entidade on pe.projetoEntidade_entidadeId equals e.entidadeId
                          where e.entidadeId == id
                          orderby p.projetoDataIni descending
                          select new
                          {
                              projetoId = p.projetoId,
                              projetoNome = p.projetoNome,
                              projetoData = p.projetoData.ToString(),
                              projetoDataIni = p.projetoDataIni.ToString(),
                              projetoDataFim = p.projetoDataFim.ToString(),
                              projetoResponsavel = p.pessoa.pessoaNome,
                              projetoDataAtualizado = p.projetoDataAtualizado.ToString(),
                              projetoCor = p.projetoCor,
                              projetoLetra = p.projetoNome.Substring(0, 1),
                              projetoGestora = p.entidade.entidadeSigla,
                              projetoEntidades = (from pe in db.projetoEntidade
                                                  join e in db.entidade on pe.projetoEntidade_entidadeId equals e.entidadeId
                                                  where pe.projetoEntidade_projetoId == p.projetoId
                                                  select e.entidadeSigla)
                          });

            var lista1 = lista0.AsEnumerable()
         .Select(x => new projetoViewModel
         {
             projetoId = x.projetoId,
             projetoNome = x.projetoNome,
             projetoData = x.projetoData,
             projetoDataIni = x.projetoDataIni,
             projetoDataFim = x.projetoDataFim,
             projetoResponsavel = x.projetoResponsavel,
             projetoDataAtualizado = x.projetoDataAtualizado,
             projetoCor = x.projetoCor,
             projetoLetra = x.projetoNome,
             projetoGestora = x.projetoGestora,
             projetoEntidades = string.Join(", ", x.projetoEntidades)
         }).AsQueryable();

            var lista = lista1.ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public JsonResult listaAnexos(int? id)
        {
            var path = "~/_AnexosProjetos/" + id;

            string fullpath = Server.MapPath("~/_AnexosProjetos/" + id + "/");

            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            DirectoryInfo diretorio = new DirectoryInfo(Server.MapPath(path));

            System.IO.FileInfo[] fileNames = diretorio.GetFiles("*.*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                anexos.Add(new anexo()
                {
                    anexoNome = fi.Name,
                    anexoTipo = fi.Extension,
                    anexoTamanho = fi.Length,
                    anexoDataAlteracao = fi.LastAccessTime,
                    anexoDataCriacao = fi.CreationTime
                });
            };

            //FileInfo[] arquivos = diretorio.GetFiles();

            var result = JsonConvert.SerializeObject(anexos.ToArray());

            JavaScriptSerializer jsa = new JavaScriptSerializer();
            object obj = jsa.Deserialize(result, typeof(object));

            return Json(obj, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FileUpload()
        {
            string path = "";
            //string path2 = "";
            string[] extensoesValidas = new string[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG", ".pdf", ".PDF", ".DOC", ".doc", ".xls", ".XLS", ".ppt", ".PPT" };
            string extensao = "";
            int arquivosSalvos = 0;

            path = Server.MapPath("~/Projetos/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase arquivo = Request.Files[i];

                if (arquivo != null && arquivo.ContentLength > 0)
                {
                    try
                    {
                        extensao = Path.GetExtension(arquivo.FileName);

                        if (!extensoesValidas.Contains(extensao))
                        {
                            new HttpException(string.Format("Extensão de arquivo *.{0} não suportada", extensao));
                        }
                        else
                        {
                            var nomeArquivo = Path.GetFileName(arquivo.FileName); //+ DateTime.Now.ToString("yyyyMMddHHmmss");

                            path = Path.Combine(path, nomeArquivo + Path.GetExtension(arquivo.FileName));

                            //path2 = Path.Combine(path, nomeArquivo + "@2x" + Path.GetExtension(file.FileName));

                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }

                            arquivo.SaveAs(path);

                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERRO: " + ex.Message.ToString();
                    }
                }
            }
            ViewData["Message"] = String.Format("{0} arquivo(s) salvo(s) com sucesso.",
     arquivosSalvos);
            return View("projetos/Index");
        }

        private string ManipulaArquivo(HttpPostedFileBase file, int projetoId)
        {
            string path = "";
            //string path2 = "";
            string[] extensoesValidas = new string[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG", ".pdf", ".PDF", ".DOC", ".doc", ".xls", ".XLS", ".ppt", ".PPT" };
            string extensao = "";

            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    extensao = Path.GetExtension(file.FileName);

                    if (!extensoesValidas.Contains(extensao))
                    {
                        new HttpException(string.Format("Extensão de arquivo *.{0} não suportada", extensao));
                    }
                    else
                    {
                        path = Server.MapPath("~/Projetos/" + projetoId + "/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        var nomeArquivo = Path.GetFileName(file.FileName); //+ DateTime.Now.ToString("yyyyMMddHHmmss");

                        path = Path.Combine(path, nomeArquivo + Path.GetExtension(file.FileName));

                        //path2 = Path.Combine(path, nomeArquivo + "@2x" + Path.GetExtension(file.FileName));

                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }

                        file.SaveAs(path);

                        //WebImage wbImage = new WebImage(path);
                        //wbImage.Resize(640, 640);
                        //wbImage.FileName = path;
                        //wbImage.Write();
                        //wbImage.Save(path);

                        //wbImage.Resize(320, 320);
                        //wbImage.FileName = path2;
                        //wbImage.Write();
                        //wbImage.Save(path2);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERRO: " + ex.Message.ToString();


                }
            }

            return path;
        }



        public ActionResult UploadAnexosGD(int? id)
        {
            ViewBag.projetoId = id;
            return PartialView();
        }




        public ActionResult UploadAnexos(int? id)
        {
            ViewBag.projetoId = id;
            return PartialView();
        }
        [HttpPost]
        public ContentResult UploadFiles(int? id)
        {
            var r = new List<UploadFilesResult>();

            string path = Server.MapPath("~/_AnexosProjetos/" + id + "/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] extensoesValidas = new string[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG", ".pdf", ".PDF", ".DOC", ".doc", ".xls", ".XLS", ".ppt", ".PPT" };

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(path, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new UploadFilesResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
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

