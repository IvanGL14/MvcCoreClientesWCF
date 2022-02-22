using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcCoreClientesWCF.Services;
using ReferenceCatastro;
using ReferenceCoches;
using ReferenceNumberConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ReferenceNumberConversion.NumberConversionSoapTypeClient;

namespace MvcCoreClientesWCF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CochesContractClient cochesClient = new CochesContractClient(CochesContractClient.EndpointConfiguration.BasicHttpBinding_ICochesContract);
            services.AddSingleton<CochesContractClient>(x => cochesClient);

            services.AddTransient<ServicesCountries>();

            NumberConversionSoapTypeClient clientNumberConversion = new NumberConversionSoapTypeClient(EndpointConfiguration.NumberConversionSoap);
            services.AddSingleton<NumberConversionSoapTypeClient>(z=> clientNumberConversion);

            //CallejerodelasedeelectrónicadelcatastroSoapClient clientCatastro = new CallejerodelasedeelectrónicadelcatastroSoapClient(CallejerodelasedeelectrónicadelcatastroSoapClient.EndpointConfiguration.Callejero_x0020_de_x0020_la_x0020_sede_x0020_electrónica_x0020_del_x0020_catastro_Soap);
            services.AddSingleton<CallejerodelasedeelectrónicadelcatastroSoapClient>();


            services.AddTransient<ServiceCatastro>();
            services.AddTransient<ServiceNumberConversion>();
            services.AddTransient<ServiceVariosMetodos>();
            services.AddTransient<ServiceCoches>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
