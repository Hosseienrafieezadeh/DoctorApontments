using DoctorApointment.Entitis.Apointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Appointments
{
    public  class AppointmentBuilder
    {
        private readonly Appointment _appointment;
        public AppointmentBuilder(int patientId, int doctorId)
        {
            _appointment = new Appointment
            {
                Date = new DateTime(2024 / 01 / 03),
                PatientId = patientId,
                DoctorId = doctorId,
            };
        }
        public AppointmentBuilder WithDate(DateTime date)
        {
            _appointment.Date = date;
            return this;
        }
        public Appointment Build()
        {
            return _appointment;
        }
    }
}
