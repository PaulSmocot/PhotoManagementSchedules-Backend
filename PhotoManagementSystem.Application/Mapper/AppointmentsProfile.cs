using AutoMapper;

using PhotoManagementSystem.Application.Models.AppointmentsDtos;
using PhotoManagementSystem.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Mapper
{
    public class AppointmentsProfile :Profile
    {
        public AppointmentsProfile()
        {
            CreateMap<CreateAppointmentsDto, Appointment>();
        }
    }
}
