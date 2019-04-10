using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Controllers
{
    public class ToolController:Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        [HttpPost]
        /// <summary>
        /// html格式化替换<>为&lt;和&gt;
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public IActionResult Html(Models.ToolModel toolModel)
        {
            string result = toolModel.Html;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("<", "&lt;").Replace(">", "&gt;");
            }
            return this.Content(result);
        }
    }
}
