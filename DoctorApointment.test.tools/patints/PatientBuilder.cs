﻿using DoctorApointment.Entitis.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.patints
{
    public class PatientBuilder
    {
        private readonly Patient _patient;
        public PatientBuilder()
        {
            _patient = new Patient
            {
                FirstName = "zahra",
                LastName = "ahmadi",
                NationalCode = "123"
            };
        }
        public PatientBuilder WithNatinalCode(string nationalCode)
        {
            _patient.NationalCode = nationalCode;
            return this;
        }

        public Patient Build()
        {
            return _patient;
        }
    }
}
