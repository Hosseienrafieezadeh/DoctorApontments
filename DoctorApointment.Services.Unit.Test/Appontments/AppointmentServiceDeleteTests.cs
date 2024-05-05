using DoctorApointment.Services.Appointments.Contracts.Exeptions;
using DoctorApointment.Services.Appointments.Contracts;
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
using Microsoft.EntityFrameworkCore;

namespace DoctorApointment.Services.Unit.Test.Appontments
{
    public class AppointmentServiceDeleteTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        private readonly AppointmentService _sut;
        public AppointmentServiceDeleteTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = AppointmentServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Delete_deletes_an_appointment_properly()
        {
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var appointment = new AppointmentBuilder(patient.Id, doctor.Id).Build();
            _context.Save(appointment);

            await _sut.Delete(appointment.Id);

            var actual = _readContext.Appointments.FirstOrDefaultAsync(_ => _.Id == appointment.Id);
            actual.Should().NotBeNull();
        }
        [Fact]
        public async Task Delete_throws_AppointmentIsNotExistException()
        {
            var dummyId = 11;

            var actual = () => _sut.Delete(dummyId);

            await actual.Should().ThrowExactlyAsync<AppointmentIsNotExistException>();
        }
    }
}
