﻿using DoctorApointment.Entitis.Doctors;
using DoctorApointment.Services.Doctors.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApontment.persistence.EF.Doctors
{
  public class EFDoctorRepository: DoctorRepository
    {
        private readonly EFDataContext _context;

        public EFDoctorRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }

        public async Task<Doctor?> FindById(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public List<GetDoctorDto> GetAll()
        {

            IQueryable<Doctor> query = _context.Doctors;

            List<GetDoctorDto> doctors = query.Select(doctor => new GetDoctorDto
            {

                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                NationalCode = doctor.NationalCode,
                Field = doctor.Field,
            }).ToList();
            return doctors;
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _context.Doctors.Any(_ => _.NationalCode == nationalCode);
        }

        public bool IsExistNationalCodeExceptItSelf(int id, string nationalCode)
        {
            return _context.Doctors.Any(_ => _.NationalCode == nationalCode && _.Id != id);
        }
    }
}
