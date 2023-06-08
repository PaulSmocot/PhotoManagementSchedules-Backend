using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        public Task Register(Client Client);
        public Task<Client?> GetClientById(Guid id);
        public Task DeleteClientById(Guid clientId);
        public Task<Client?> GetClientByEmail(string email);
        public Task UpdateClient(Client Client);
    }
}
