﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementSystem.Domain.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
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
