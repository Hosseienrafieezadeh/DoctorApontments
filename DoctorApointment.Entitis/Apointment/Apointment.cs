﻿using DoctorApointment.Entitis.Doctors;
using DoctorApointment.Entitis.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Entitis.Apointment
{
 
        public class Appointment
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public Doctor Doctor { get; set; }
            public int DoctorId { get; set; }
            public Patient Patient { get; set; }
            public int PatientId { get; set; }
        }
    
}
