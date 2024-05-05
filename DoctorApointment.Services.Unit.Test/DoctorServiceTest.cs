using DoctorApointment.Entitis.Doctors;
using DoctorApointment.Services.Doctors;
using DoctorApointment.Services.Doctors.Contracts;
using DoctorApointment.Services.Doctors.Contracts.Dtos;
using DoctorApointment.Services.Doctors.Contracts.Exeptions;
using DoctorApointment.test.tools.Doctors;
using DoctorApointment.test.tools.Instructure.DatabaseConfig.Unit;
using DoctorApontment.persistence.EF;
using DoctorApontment.persistence.EF.Doctors;
using FluentAssertions;
using System.Numerics;

namespace DoctorApointment.Services.Unit.Test
{
    public class DoctorServiceTest
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        private readonly DoctorService _sut;
        public DoctorServiceTest()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = DoctorServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Add_adds_a_new_doctor_properly()
        {
            //arrange
            var dto = AddDoctorDtoFactory.Create();
           
          

            //act
            await _sut.Add(dto);

            //assert
            var actual = _readContext.Doctors.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.Field.Should().Be(dto.Field);
            actual.NationalCode.Should().Be(dto.NationalCode);
        }
        [Fact]
        public async Task Add_throws_ReduplicateNationalCodeException_if_national_code_is_existed()
        {

            var doctor =new DoctorBuilder().WithNationalCode("222222222").Build();
            _context.Save(doctor);
            var reduplicateDoctorDto =  AddDoctorDtoFactory.Create();


            var actual = () => _sut.Add(reduplicateDoctorDto);

            await actual.Should().ThrowExactlyAsync<ReduplicateNationalCodeException>();
        }

        [Fact]
        public async Task Update_updates_doctor_properly()
        {
           
            //arrange
            var doctor = new DoctorBuilder().WithNationalCode("222222222").Build();
            _context.Save(doctor);
           
            var updateDto = UpdateDoctorDtoFactory.Create();

            //act
            await _sut.Update(doctor.Id, updateDto);

            //assert
            var actual = _readContext.Doctors.First(_ => _.Id == doctor.Id);
            actual.FirstName.Should().Be(updateDto.FirstName);
            actual.LastName.Should().Be(updateDto.LastName);
            actual.Field.Should().Be(updateDto.Field);
        }
        [Fact]
        public async Task Update_throws_ReduplicateNationalCodeException_if_national_code_is_existed()
        {
           
            var doctor = new DoctorBuilder().WithNationalCode("222222222").Build();
            var reduplicateDoctor = new DoctorBuilder().WithNationalCode("22222222ss").Build();
            _context.Save(doctor);
           _context.Save(reduplicateDoctor);
            var dto = new UpdateDoctorDto
            {
                FirstName = "hossein",
                LastName = "rafieezadeh",
                Field = "heart",
                NationalCode = "2283182033"
            };
        

            var actual = () =>_sut.Update(reduplicateDoctor.Id, dto);

            await actual.Should().ThrowExactlyAsync<ReduplicateNationalCodeException>();
        }

        [Fact]
        public async Task Update_throws_DoctorNotExistedException()
        {
           
            var id = 10;
           
            var dto = UpdateDoctorDtoFactory.Create();

            var actual = () => _sut.Update(id, dto);


            await actual.Should().ThrowExactlyAsync<DoctorNotExistedException>();

        }
        [Fact]
        public async Task Delete_deletes_a_doctor_by_id()
        {
            var doctor = new DoctorBuilder().WithNationalCode("222222222").Build();
            _context.Save(doctor);
          
            await _sut.Delete(doctor.Id);

            var actual = _readContext.Doctors.Count();
            actual.Should().Be(0);
        }
        [Fact]
        public async Task Delete_throws_DoctorNotExistedException()
        {
           
            var id = 10;
           

            var actual = () => _sut.Delete(id);

            await actual.Should().ThrowExactlyAsync<DoctorNotExistedException>();
        }
        [Fact]
        public void GetAll_gets_all_doctors_count()
        {
            
            var doctor1 = new DoctorBuilder().WithNationalCode("222222222").Build();
            var doctor2 = new DoctorBuilder().WithNationalCode("222222222wqfa").Build();
            var doctor3 = new DoctorBuilder().WithNationalCode("2222222wwdads22").Build();
            var doctor4 = new DoctorBuilder().WithNationalCode("222222222").Build();
            _context.Save(doctor1);
            _context.Save(doctor2);
            _context.Save(doctor3);
            _context.Save(doctor4);

            var actual = _sut.GetAll();

            actual.Count().Should().Be(4);
        }
        [Fact]
        public void GetAll_get_a_doctor_check_valid_data()
        {
            
            var doctor = new DoctorBuilder().WithNationalCode("222222222").Build();
            _context.Save(doctor);
            

            var actual = _sut.GetAll();

            actual.Single().FirstName.Should().Be("hossein");
            actual.Single().LastName.Should().Be("rafieezadeh");
            actual.Single().NationalCode.Should().Be("12");
            actual.Single().Field.Should().Be("general");
        }

    }
}
