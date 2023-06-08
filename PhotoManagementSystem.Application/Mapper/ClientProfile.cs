using AutoMapper;

using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;
using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Mapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();

            CreateMap<Client, ClientGetDto>();

            CreateMap<Client, ClientLoginReponseDto>();

            CreateMap<Client, ClientDto>();

            CreateMap<ClientRegisterDto, Client>();
        }
    }
}
