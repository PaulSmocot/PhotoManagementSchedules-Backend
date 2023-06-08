using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Models.UserDtos
{
    public class UserLoginResponseDto
    {
        public Guid Id { get; set; }
        public string userRole { get; set; } = null!;
    }
}
