using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Web;
using Microsoft.AspNetCore.StaticFiles;

namespace HaiwellFuture.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Services.IProjectScadaView projectScadaView;

        public ProjectController(IHostingEnvironment hostingEnvironment, Services.IProjectScadaView projectScadaView)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.projectScadaView = projectScadaView;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            List<ViewModels.ProjectViewModel> lst = new List<ViewModels.ProjectViewModel>();
            foreach(IFormFile file in files)
            {
                string fileName = Path.Combine(this.hostingEnvironment.WebRootPath, $"Files/{file.FileName}");
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();
                    fs.Close();
                }
                this.projectScadaView.SetFile(fileName);

                ViewModels.ProjectViewModel projectView = this.projectScadaView.GetViewModel();
                lst.Add(projectView);
            }
            return this.View(lst);
        }
        [HttpGet]
        public IActionResult FileList()
        {
            List<FileInfo> lst = new List<FileInfo>();
            
            foreach(string fileName in Directory.GetFiles(Path.Combine(this.hostingEnvironment.WebRootPath, "Files")))
            {
                FileInfo fi = new FileInfo(fileName);
                lst.Add(fi);
            }
            return this.View(lst);
        }
        [HttpGet]
        public IActionResult GetFile(string name)
        {
            string fileName = Path.Combine(this.hostingEnvironment.WebRootPath, $"Files/{name}");
            if (System.IO.File.Exists(fileName))
            {
                byte[] bys = System.IO.File.ReadAllBytes(fileName);
                return this.File(bys, "application/x-msdownload", name);
            }
            return this.NotFound();
        }
        [HttpGet]
        public IActionResult FileDelete(string name)
        {
            string fileName = Path.Combine(this.hostingEnvironment.WebRootPath, $"Files/{name}");
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            return this.RedirectToAction("FileList");
        }
    }
}