using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCoreClientesWCF.Models;
using MvcCoreClientesWCF.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Controllers
{
    public class HomeController : Controller
    {
        private ServiceVariosMetodos service;

        public HomeController(ServiceVariosMetodos service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int numero)
        {
            int[] results = await this.service.GetTablaMultiplicar(numero);
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
