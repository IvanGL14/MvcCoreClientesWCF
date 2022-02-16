using ServicioCountries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Services
{
    public class ServicesCountries
    {
        //EL NOMBRE DEL OBJETO SIEMPRE SERA UN CLIENT
        //QUE SE LLAMARÁ COMO EL NOMBRE DEL SERVICIO QUE HEMOS
        //VISTO EN LA ANTERIOR PAMTALLA
        CountryInfoServiceSoapTypeClient client;

        public ServicesCountries()
        {
            this.client = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        public async Task<tCountryCodeAndName[]> GetCountries()
        {
            ListOfCountryNamesByNameResponse response = await this.client.ListOfCountryNamesByNameAsync();
            tCountryCodeAndName[] objetos = response.Body.ListOfCountryNamesByNameResult;
            return objetos;
        }

        public async Task<FullCountryInfoResponse> InformacionPais(string isoCountry)
        {
            FullCountryInfoResponse country = await this.client.FullCountryInfoAsync(isoCountry);           
            return country;
        }
    }
}
