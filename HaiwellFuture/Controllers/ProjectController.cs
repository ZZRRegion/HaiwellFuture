using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace HaiwellFuture.Controllers
{
    public class ProjectController : Controller
    {
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
        public IActionResult Upload(FormCollection form)
        {
            return this.View();
        }
    }
}