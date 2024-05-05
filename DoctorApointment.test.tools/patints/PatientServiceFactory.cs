using DoctorApointment.Services.Patients.Contracts;
using DoctorApointment.Services.Patients;
using DoctorApontment.persistence.EF.Patients;
using DoctorApontment.persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.patints
{
    public static class PatientServiceFactory
    {
        public static PatientService Create(EFDataContext context)
        {
            return new PatientAppService(new EFPatientRepository(context), new EFUnitOfWork(context));
        }
    }
}
