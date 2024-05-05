using DoctorApointment.Services.Doctors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Doctors
{
    public static class UpdateDoctorDtoFactory
    {
        public static UpdateDoctorDto Create(string? nationalCode = null)
        {
            return new UpdateDoctorDto
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "heart",
                NationalCode = nationalCode ?? "dummy-national-code"
            };
        }
    }
}
