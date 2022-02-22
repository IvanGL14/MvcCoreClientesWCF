using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesWCF.Services;
using ReferenceCoches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Controllers
{
    public class CochesController : Controller
    {
        private ServiceCoches service;

        public CochesController(ServiceCoches service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            Coche[] coches = await this.service.GetCocheAsync();
            return View(coches);
        }

        public async Task<IActionResult> Details(int idcoche)
        {
            Coche coche = await this.service.FindCocheAsync(idcoche);
            return View(coche);
        }
    }
}
