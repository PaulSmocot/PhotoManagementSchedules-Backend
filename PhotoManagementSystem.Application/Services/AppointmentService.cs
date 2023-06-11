using AutoMapper;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.AppointmentsDtos;
using PhotoManagementSystem.Domain.Models;
using PhotoManagementSystem.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Services
{
    public class AppointmentService : IAppointmentsService
    {
        private readonly IMapper mapper;
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }
        public async Task<Guid> CreateAppontment(CreateAppointmentsDto createAppointmentsDto)
        {
            var appointment = mapper.Map<Appointment>(createAppointmentsDto);
            appointment.Id= Guid.NewGuid();
            await appointmentRepository.CreateAppointmentRes(appointment);
            return appointment.Id;
        }
    }
}
