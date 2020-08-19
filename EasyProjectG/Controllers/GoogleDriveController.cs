using EasyProjectG.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EasyProjectG.Controllers
{
    public class GoogleDriveController : Controller
    {
        [HttpGet]
        public ActionResult GetGoogleDriveFiles()
        {
            return PartialView(GoogleDriveFilesRepository.GetDriveFiles());
        }

        [HttpPost]
        public string DeleteFile(GoogleDriveFiles file)
        {
            GoogleDriveFilesRepository.DeleteFile(file);
            return "Deletado";
        }
         
        [HttpPost]
        public string UploadFile(HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUpload(file);
            return "Upado";
        }

        public JsonResult listaAnexosGD(int? id)
        {
            var lista = GoogleDriveFilesRepository.GetDriveFiles();

            //FileInfo[] arquivos = diretorio.GetFiles();

            var result = JsonConvert.SerializeObject(lista.ToArray());

            JavaScriptSerializer jsa = new JavaScriptSerializer();
            object obj = jsa.Deserialize(result, typeof(object));

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public void DownloadFile(string id)
        {
            string FilePath = GoogleDriveFilesRepository.DownloadGoogleFile(id);
            

            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
            Response.WriteFile(System.Web.HttpContext.Current.Server.MapPath("~/GoogleDriveFiles/" + Path.GetFileName(FilePath)));
            Response.End();
            Response.Flush();
        }


        [HttpPost]
        public ContentResult UploadFilesGD(int? id)
        {
            var r = new List<UploadFilesResult>();

            string[] extensoesValidas = new string[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG", ".pdf", ".PDF", ".DOC", ".doc", ".xls", ".XLS", ".ppt", ".PPT", ".avi", ".AVI" };

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;

                if (hpf.ContentLength == 0)
                    continue;

                UploadFile(hpf);

                r.Add(new UploadFilesResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
        }
    }
}