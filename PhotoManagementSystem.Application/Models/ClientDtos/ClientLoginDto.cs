using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Models.ClientDtos
{
    public class ClientLoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; }
    }
}
