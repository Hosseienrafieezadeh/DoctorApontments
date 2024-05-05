using DoctorApointment.Entitis.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Services.Doctors.Contracts.Dtos
{
   public interface DoctorRepository
    {
        void Add(Doctor doctor);
        Task<Doctor?> FindById(int id);
        bool IsExistNationalCode(string nationalCode);
        bool IsExistNationalCodeExceptItSelf(int id, string nationalCode);
        void Delete(Doctor doctor);
        List<GetDoctorDto> GetAll();
    }
}
