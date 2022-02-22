using ReferenceNumberConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Services
{
    public class ServiceNumberConversion
    {
        NumberConversionSoapTypeClient client;

        public ServiceNumberConversion(NumberConversionSoapTypeClient client)
        {
            this.client = client;
        }

        public async Task<string> GetNumberToWords(int numero)
        {
            NumberToWordsResponse response = await this.client.NumberToWordsAsync((ulong)numero);
            string result = response.Body.NumberToWordsResult;
            return result;
        }

    }
}
