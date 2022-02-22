using ReferenceCoches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreClientesWCF.Services
{
    public class ServiceCoches
    {
        CochesContractClient client;

        public ServiceCoches(CochesContractClient client)
        {
            this.client = client;
        }

        public async Task<Coche[]> GetCocheAsync()
        {
            Coche[] coches = await this.client.GetCochesAsync();
            
            return coches;
        }

        public async Task<Coche> FindCocheAsync(int idcoche)
        {
            Coche coche = await this.client.FindCocheAsync(idcoche);
            
            return coche;
        }
    }
}
