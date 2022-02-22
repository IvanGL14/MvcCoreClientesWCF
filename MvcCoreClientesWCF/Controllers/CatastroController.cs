using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesWCF.Models;
using MvcCoreClientesWCF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Controllers
{
    public class CatastroController : Controller
    {
        private ServiceCatastro service;

        public CatastroController(ServiceCatastro service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Provincia> provincias = await this.service.GetProvincias();
            return View(provincias);
        }

        public async Task<IActionResult> Municipios(string provincia)
        {
            List<string> municipios = await this.service.GetMuniciops(provincia);
            return View(municipios);
        }
    }
}
