using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesWCF.Services;
using ServicioCountries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Controllers
{
    public class CountriesController : Controller
    {
        private ServicesCountries services;

        public CountriesController(ServicesCountries services)
        {
            this.services = services;
        }

        public async Task<IActionResult> Index()
        {
            tCountryCodeAndName[] countries = await this.services.GetCountries();
            return View(countries);
        }

        public async Task<IActionResult> Detalles(string iso)
        {
            FullCountryInfoResponse country = await this.services.InformacionPais(iso);
            return View(country);
        }
    }
}
