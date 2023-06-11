using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Application.Models.AppointmentsDtos
{
    public class CreateAppointmentsDto
    {
        public Guid IdUser { get; set; }
        public Guid IdClient { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public float Duration { get; set; }
        public string Preferences { get; set; }
        public string Service { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }

    }
}
