using DoctorApointment.Services.Doctors;
using DoctorApointment.Services.Doctors.Contracts;
using DoctorApontment.persistence.EF;
using DoctorApontment.persistence.EF.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Doctors
{
    public static class DoctorServiceFactory
    {
        public static DoctorService Create(EFDataContext context)
        {
            return new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        }
    }
}
