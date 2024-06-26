﻿using DoctorApointment.Contracts.Interface;
using DoctorApointment.Entitis.Doctors;
using DoctorApointment.Services.Doctors.Contracts;
using DoctorApointment.Services.Doctors.Contracts.Dtos;
using DoctorApointment.Services.Doctors.Contracts.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddDoctorDto dto)
        {
            if (_repository.IsExistNationalCode(dto.NationalCode))
            {
                throw new ReduplicateNationalCodeException();
            }
            var doctor = new Doctor()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode

            };

            _repository.Add(doctor);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var doctor = await _repository.FindById(id);
            if (doctor is null)
            {
                throw new DoctorNotExistedException();
            }
            _repository.Delete(doctor);
            await _unitOfWork.Complete();
        }



        public async Task Update(int id, UpdateDoctorDto dto)
        {
            var doctor = await _repository.FindById(id);
            if (doctor is null)
            {
                throw new DoctorNotExistedException();
            }
            if (_repository.IsExistNationalCodeExceptItSelf(doctor.Id, dto.NationalCode))
            {
                throw new ReduplicateNationalCodeException();
            }
            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Field = dto.Field;
            doctor.NationalCode = dto.NationalCode;
            await _unitOfWork.Complete();
        }

        public List<GetDoctorDto> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
