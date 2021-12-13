using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TP_Application.Services;
using TP_Domain.DTOs;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarioTurnosController:ControllerBase
    {
        private readonly ICalendarioTurnosService _service;
        public CalendarioTurnosController(ICalendarioTurnosService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(CalendarioTurnosDto calendarioTurnos)
        {
            try
            {
                return new JsonResult(_service.CreateCalendarioTurnos(calendarioTurnos)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_service.GetAllCalendarioTurnos()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Medico/{Id?}")]
        [Authorize]
        public IActionResult Gext(int Id, [FromQuery][Required] int DiaId, [FromQuery][Required] string practica)
        {
            try
            {
                return new JsonResult(_service.GetCalendarioMedicoPractica(DiaId, practica, Id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
