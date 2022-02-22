using ReferenceVariosMetodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Services
{
    public class ServiceVariosMetodos
    {
        MetodosVariosContractClient client;

        public ServiceVariosMetodos()
        {
            this.client = new MetodosVariosContractClient(MetodosVariosContractClient.EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract);
        }

        public async Task<int[]> GetTablaMultiplicar(int numero)
        {
            int[] results = await this.client.GetTablaMultiplicarAsync(numero);
            return results;
        }
    }
}
