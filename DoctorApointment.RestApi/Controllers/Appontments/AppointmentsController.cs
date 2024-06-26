﻿using DoctorApointment.Services.Appointments.Contracts.Dtos;
using DoctorApointment.Services.Appointments.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApointment.RestApi.Controllers.Appontments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;
        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddAppointmentDto dto)
        {
            await _service.Add(dto);
        }
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateAppointmentDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _service.Delete(id);
        }
        [HttpGet]
        public async Task<List<GetAppointmentDto>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
