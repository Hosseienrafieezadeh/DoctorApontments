using DoctorApointment.Services.Doctors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Doctors
{
    public static class AddDoctorDtoFactory
    {
        public static AddDoctorDto Create(string? nationalCode = null)
        {
            return new AddDoctorDto
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "heart",
                NationalCode = nationalCode ?? "2283182033"
            };
        }
    }
}
