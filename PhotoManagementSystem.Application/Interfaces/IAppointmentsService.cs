using PhotoManagementSystem.Application.Models.AppointmentsDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Interfaces
{
    public interface IAppointmentsService
    {
        public Task<Guid> CreateAppontment(CreateAppointmentsDto createAppointmentsDto);
        
    }
}
