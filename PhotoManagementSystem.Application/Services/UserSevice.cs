using AutoMapper;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;
using PhotoManagementSystem.Domain.Enum;
using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task DeleteUserById(Guid userId, Guid ConnectedUserID)
        {
            await userRepository.DeleteUserById(userId, ConnectedUserID);
        }

        public async Task<UserGetDto> GetUserById(Guid id)
        {
            var user = await userRepository.GetUserById(id);

            return mapper.Map<UserGetDto>(user);
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            var user = await userRepository.GetUserByEmail(userLoginDto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (user.Password != userLoginDto.Password)
            {
                throw new Exception("Invalid password");
            }

            return mapper.Map<UserLoginResponseDto>(user);
        }

       
        public async Task<Guid> Register(UserRegisterDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            user.Id = Guid.NewGuid();
        

            await userRepository.RegisterPhotograf(user);

            return user.Id;
        }

        public async Task<UserDto> UpdateUser(UserDto userDto, Guid id)
        {
            var user = await userRepository.GetUserById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var mappedUser = mapper.Map(userDto, user);

            await userRepository.UpdateUser(mappedUser);

            return mapper.Map<UserDto>(mappedUser);
        }
    }
}
