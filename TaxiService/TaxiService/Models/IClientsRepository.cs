using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface IClientsRepository
    {
        IEnumerable<Clients> AllClients { get; }
        void AddClient(string clientName, string clientPhone);
    }
}
