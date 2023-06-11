using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Infrastructure.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task CreateAppointmentRes(Appointment appointment);
    }
}
