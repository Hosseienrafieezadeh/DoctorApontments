using DoctorApointment.Services.Patients.Contracts.Dtos;
using DoctorApointment.Services.Patients.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApointment.RestApi.Controllers.Patints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatintsController : ControllerBase
    {
        private readonly PatientService _service;
        public PatintsController(PatientService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddPatientDto dto)
        {
            await _service.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdatePatientDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _service.Delete(id);
        }
        [HttpGet]
        public List<GetPatientDto> GetAll()
        {
            return _service.GetAll();
        }
    }
}
