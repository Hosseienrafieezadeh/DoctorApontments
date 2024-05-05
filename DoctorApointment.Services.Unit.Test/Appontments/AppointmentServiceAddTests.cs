using DoctorApointment.Services.Appointments.Contracts.Exeptions;
using DoctorApointment.Services.Appointments.Contracts;
using DoctorApointment.Services.Patients.Contracts.Exeptions;
using DoctorApointment.test.tools.Doctors;
using DoctorApointment.test.tools.Instructure.DatabaseConfig.Unit;
using DoctorApontment.persistence.EF;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorApointment.test.tools.Appointments;
using DoctorApointment.test.tools.patints;

namespace DoctorApointment.Services.Unit.Test.Appontments
{
    public class AppointmentServiceAddTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        private readonly AppointmentService _sut;
        public AppointmentServiceAddTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = AppointmentServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Add_adds_a_new_appointment_properly()
        {
            var doctor = new DoctorBuilder().Build();
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            _context.Save(doctor);
            var dto = AddAppointmentDtoFactory.Create(doctor.Id, patient.Id);

            await _sut.Add(dto);

            var actual = _readContext.Appointments.Single();
            actual.PatientId.Should().Be(dto.PatientId);
            actual.DoctorId.Should().Be(dto.DoctorId);
            actual.Date.Should().Be(dto.Date);
        }
        [Fact]
        public async Task Add_throw_DoctorIsNotExistedException()
        {
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dummyDoctorId = 12;
            var dto = AddAppointmentDtoFactory.Create(patient.Id, dummyDoctorId);

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<DoctorIsNotExistedException>();
        }
        [Fact]
        public async Task Add_throw_PatientIsNotExistedException()
        {
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var dummyPatientId = 12;
            var dto = AddAppointmentDtoFactory.Create(doctor.Id, dummyPatientId);

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<PatientIsNotExistedException>();
        }
        [Fact]
        public async Task Add_throw_DoctorCantHaveMoreThanFiveAppointmentPerDayException()
        {
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dto = AddAppointmentDtoFactory.Create(doctor.Id, patient.Id);
            await _sut.Add(dto);
            await _sut.Add(dto);
            await _sut.Add(dto);
            await _sut.Add(dto);
            await _sut.Add(dto);

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<DoctorCantHaveMoreThanFiveAppointmentPerDayException>();
        }
    }
}
