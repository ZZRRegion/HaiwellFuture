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
        /// <summary>
        /// 访问IP查看
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Ip()
        {
            ViewModels.IpViewModel ipViewModel = new ViewModels.IpViewModel();
            ipViewModel.HashIp = await this.requestIPRecord.GetAllIp();
            List<string> lstIp = ipViewModel.HashIp.Select(item => item.Ip).ToList();
            List<int> lstCount = ipViewModel.HashIp.Select(item => item.Count).ToList();
            ipViewModel.xAxis = Newtonsoft.Json.JsonConvert.SerializeObject(lstIp);
            ipViewModel.xAxis = ipViewModel.xAxis?.Replace("\"", "\'");
            ipViewModel.series = Newtonsoft.Json.JsonConvert.SerializeObject(lstCount);
            ipViewModel.series = ipViewModel.series?.Replace("\"", "\'");
            return this.View(ipViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.requestIPRecord.Remove(id);
            return this.RedirectToAction("Ip", "Home");
        }
    }
}
