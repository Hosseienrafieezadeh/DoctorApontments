﻿using DoctorApointment.Entitis.Apointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Entitis.Patients
{
   public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public HashSet<Appointment> Appointments { get; set; }
    }
}
