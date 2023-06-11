using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task RegisterPhotograf(User user);
        public Task<User?> GetUserById(Guid id);
        public Task DeleteUserById(Guid userId);
        public Task<User?> GetUserByEmail(string email);
        public Task UpdateUser(User user);

    }
}
