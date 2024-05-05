using DoctorApointment.Services.Patients.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.patints
{
    public static class UpdatePatientDtoFactory
    {
        public static UpdatePatientDto Create(string? natinalCode = null)
        {
            return new UpdatePatientDto
            {
                FirstName = "zizi",
                LastName = "haqiqat",
                NationalCode = natinalCode ?? "123"
            };
        }

    }
}
