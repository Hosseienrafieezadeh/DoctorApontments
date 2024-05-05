using DoctorApointment.Services.Appointments.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Appointments
{
   public static class AddAppointmentDtoFactory
    {
        public static AddAppointmentDto Create(int doctorId, int patientId, DateTime? date = null)
        {
            return new AddAppointmentDto
            {
                DoctorId = doctorId,
                PatientId = patientId,
                Date = date ?? new DateTime(2024, 02, 02)
            };
        }
    }
}
