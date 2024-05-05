using DoctorApointment.Services.Doctors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        Task Add(AddDoctorDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateDoctorDto dto);
        List<GetDoctorDto> GetAll();
    }
}
