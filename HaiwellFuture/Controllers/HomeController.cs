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
            HashSet<IpRecord> hash = await this.requestIPRecord.GetAllIp();
            return this.View(hash);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.requestIPRecord.Remove(id);
            return this.RedirectToAction("Ip", "Home");
        }
    }
}
