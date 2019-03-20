using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HaiwellFuture.Services;
using HaiwellFuture.ViewModels;

namespace HaiwellFuture.Controllers
{
    /// <summary>
    /// HMI在线查看
    /// </summary>
    public class HMISearchController:Controller
    {
        private readonly IHMISearch hMISearch;

        public HMISearchController(IHMISearch hMISearch)
        {
            this.hMISearch = hMISearch;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string ip)
        {
            List<HMISearchViewModel> lst = await this.hMISearch.GetOnlineAsync();
            if (!string.IsNullOrEmpty(ip))
            {
                lst = lst.Where(item => item.ip.Contains(ip)).ToList();
            }
            return this.View(lst);
        }
        [HttpPost]
        public async Task<IActionResult> GetHMI(string ip)
        {
            List<HMISearchViewModel> lst = await this.hMISearch.GetOnlineAsync();
            if (!string.IsNullOrEmpty(ip))
            {
                lst = lst.Where(item => item.ip.Contains(ip)).ToList();
            }
            return this.Json(lst);
        }
    }
}
