using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HaiwellFuture.Controllers
{
    public class HomeController:Controller
    {
        public HomeController()
        {

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
    }
}
