using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Models
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public ClientsRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public IEnumerable<Clients> AllClients => _appDbContext.Clients;
        public void AddClient(string clientName, string clientPhone)
        {
            _appDbContext.Clients.Add(new Clients { ClientName = clientName, ClientPhoneNumber = clientPhone});
            _appDbContext.SaveChanges();
        }
    }
}
