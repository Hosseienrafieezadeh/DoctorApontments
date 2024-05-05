using DoctorApointment.Services.Appointments.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Appointments
{
   public static class UpdateAppointmentDtoFactory
    {
        public static UpdateAppointmentDto Create(int doctorId, int patientId, DateTime? date = null)
        {
            return new UpdateAppointmentDto
            {
                DoctorId = doctorId,
                PatientId = patientId,
                Date = date ?? new DateTime(2024, 02, 02)
            };
        }
    }
}
