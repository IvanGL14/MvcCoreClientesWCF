using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesWCF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Controllers
{
    public class NumberToWordsController : Controller
    {
        private ServiceNumberConversion service;

        public NumberToWordsController(ServiceNumberConversion service)
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
            string response = await this.service.GetNumberToWords(numero);
            ViewData["RESPONSE"] = response;
            return View();
        }
    }
}
