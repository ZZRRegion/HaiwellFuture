using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HaiwellFuture.Services;

namespace HaiwellFuture.Controllers
{
    public class HomeController:Controller
    {
        private readonly IRequestIPRecord requestIPRecord;

        public HomeController(IRequestIPRecord requestIPRecord)
        {
            this.requestIPRecord = requestIPRecord;
        }
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Login()
        {
            return this.View();
        }
        public IActionResult Register()
        {
            return this.View();
        }
        public async Task<IActionResult> Ip()
        {
            HashSet<string> hash = await this.requestIPRecord.GetAllIp();
            return this.View(hash);
        }
    }
}
