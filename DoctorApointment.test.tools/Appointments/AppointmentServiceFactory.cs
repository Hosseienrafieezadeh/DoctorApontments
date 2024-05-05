using DoctorApointment.Services.Appointments.Contracts;
using DoctorApointment.Services.Appointments;
using DoctorApontment.persistence.EF.Appintment;
using DoctorApontment.persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.test.tools.Appointments
{
    public static class AppointmentServiceFactory
    {
        public static AppointmentService Create(EFDataContext context)
        {
            return new AppointmentAppService(new EFAppointmentRepository(context), new EFUnitOfWork(context));
        }
    }
}
