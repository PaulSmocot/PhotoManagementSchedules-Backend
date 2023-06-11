using Microsoft.AspNetCore.Mvc;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.AppointmentsDtos;
using PhotoManagementSystem.Domain.Models;

namespace PhotoManagementSchedules_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService appointmentsService;
        public AppointmentsController(IAppointmentsService appointmentsService) {
            this.appointmentsService = appointmentsService;
        }

        [HttpPost("createAppointments")]
        public async Task<IActionResult> CreateAppointments(CreateAppointmentsDto createAppointmentsDto)
        {
            try
            {
                var appointmentId = await appointmentsService.CreateAppontment(createAppointmentsDto);

                return Ok(appointmentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
