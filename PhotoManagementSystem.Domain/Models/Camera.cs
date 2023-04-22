using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Domain.Models
{
    public class Camera
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string Lens { get; set; }

        public string Flash { get; set; }
    }
}
