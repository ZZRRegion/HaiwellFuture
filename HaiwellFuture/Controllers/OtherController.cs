using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HaiwellFuture.Controllers
{
    public class OtherController:Controller
    {
        private readonly Services.IServerTime serverTime;

        public OtherController(Services.IServerTime serverTime)
        {
            this.serverTime = serverTime;
        }
        public IActionResult Index()
        {
            return this.NoContent();
        }
        [HttpGet]
        public IActionResult GetTime()
        {
            return this.Content(this.serverTime.GetTime());
        }
        /// <summary>
        /// Post提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostMan()
        {
            StreamReader sr = new StreamReader(this.Request.Body);
            string result = sr.ReadToEnd();

            return this.Content(DateTime.Now + "返回：" + result);
        }
    }
}
