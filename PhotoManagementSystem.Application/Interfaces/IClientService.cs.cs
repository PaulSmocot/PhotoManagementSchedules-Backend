using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Interfaces
{
    public interface IClinetService
    {
        public Task<Guid> Register(ClientRegisterDto clientDto);
        public Task<ClientGetDto> GetClientById(Guid id);
        public Task DeleteClientById(Guid id);
        public Task<ClientLoginReponseDto> Login(ClientLoginDto clientLoginDto);
        public Task<ClientDto> UpdateClient(ClientDto clientDto, Guid id);
    }
}
