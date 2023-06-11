using PhotoManagementSystem.Application.Models;
using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Interfaces
{
    public interface IUserService
    {       
        public Task<Guid> Register(UserRegisterDto userDto);
        public Task<UserGetDto> GetUserById(Guid id);
        public Task DeleteUserById(Guid id);
        public Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
        public Task<UserDto> UpdateUser(UserDto userDto, Guid id);
    }
}
