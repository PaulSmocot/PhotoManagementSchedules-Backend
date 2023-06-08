using AutoMapper;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;
using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;
using PhotoManagementSystem.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Services
{
   public class ClientService : IClinetService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Register(ClientRegisterDto ClientDto)
        {

            var client = mapper.Map<Client>(ClientDto);

            client.Id = Guid.NewGuid();

            await clientRepository.Register(client);

            return client.Id;
        }

        public async Task DeleteClientById(Guid userId)
        {
            await clientRepository.DeleteClientById(userId);
        }

        public async Task<ClientGetDto> GetClientById(Guid id)
        {
            var client = await clientRepository.GetClientById(id);

            return mapper.Map<ClientGetDto>(client);
        }
        public async Task<ClientLoginReponseDto> Login(ClientLoginDto clientLoginDto)
        {
            var client = await clientRepository.GetClientByEmail(clientLoginDto.Email);
            if (client == null)
            {
                throw new Exception("Client not found");
            }
            if (client.Password != clientLoginDto.Password)
            {
                throw new Exception("Invalid password");
            }

            return mapper.Map<ClientLoginReponseDto>(client);
        }

        public async Task<ClientDto> UpdateClient(ClientDto ClientDto, Guid id)
        {
            var client = await clientRepository.GetClientById(id);

            if (client == null)
            {
                throw new Exception("Client not found");
            }

            var mappedClient = mapper.Map(ClientDto, client);

            await clientRepository.UpdateClient(mappedClient);

            return mapper.Map<ClientDto>(mappedClient);
        }
    }
}
