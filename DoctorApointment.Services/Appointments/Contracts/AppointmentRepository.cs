using DoctorApointment.Entitis.Apointment;
using DoctorApointment.Services.Appointments.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Services.Appointments.Contracts
{
   public interface AppointmentRepository
    {
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        int DoctorAppointmentsCountsPerDay(int doctorId, DateTime date);
        Appointment? Find(int id);
        Task<List<GetAppointmentDto>> GetAll();
        bool IsExistDoctor(int doctorId);
        bool IsExistPatient(int patientId);
        void Update(Appointment appointment);
    }
}
