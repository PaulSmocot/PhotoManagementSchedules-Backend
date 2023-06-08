using AutoMapper;
using PhotoManagementSystem.Application.Models.UserDtos;
using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<User, UserGetDto>();

            CreateMap<User, UserLoginResponseDto>()
                .ForMember(dest => dest.userRole,
                                   opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<User, UserDto>();

            CreateMap<UserRegisterDto, User>();
        }
    }
}
