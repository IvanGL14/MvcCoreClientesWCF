using MvcCoreClientesWCF.Models;
using ReferenceCatastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MvcCoreClientesWCF.Services
{
    public class ServiceCatastro
    {
        CallejerodelasedeelectrónicadelcatastroSoapClient client;

        public ServiceCatastro(CallejerodelasedeelectrónicadelcatastroSoapClient client)
        {
            this.client = client;
        }

        public async Task<List<Provincia>> GetProvincias()
        {

            ConsultaProvincia1 response = await this.client.ObtenerProvinciasAsync();

            XmlNode node = response.Provincias;
            string dataXml = node.OuterXml;
            XDocument document = XDocument.Parse(dataXml);
            XNamespace ns = "http://www.catastro.meh.es/";

            List<Provincia> provincias = new List<Provincia>();

            var consulta = from datos in document.Descendants(ns+"prov")
                           select datos;

            foreach(XElement dato in consulta)
            {
                string nombreProvincia = dato.Element(ns + "np").Value;
                int idProvincia = int.Parse(dato.Element(ns + "cpine").Value);
                Provincia provincia = new Provincia
                {
                    IdProvincia = idProvincia,
                    Nombre = nombreProvincia
                };
                provincias.Add(provincia);
            }

            return provincias;
        }

        public async Task <List<string>> GetMuniciops(string provincia)
        {
            ConsultaMunicipio1 response = await this.client.ObtenerMunicipiosAsync(provincia, null);

            XmlNode node = response.Municipios;
            string dataXml = node.OuterXml;
            XDocument document = XDocument.Parse(dataXml);
            XNamespace ns = "http://www.catastro.meh.es/";

            List<string> municipios = new List<string>();

            var consulta = from datos in document.Descendants(ns + "muni")
                           select datos;

            foreach (XElement dato in consulta)
            {
                string nombreMunicipio = dato.Element(ns + "nm").Value;
                
                municipios.Add(nombreMunicipio);
            }

            return municipios;


        }
    }
}
