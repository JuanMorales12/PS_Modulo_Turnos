using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TP_Application.Services;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _service;
        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RequestTurnoDto turno)
        {
            try
            {
                return new JsonResult(_service.CreateTurno(turno)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("Cliente")]
        public IActionResult GetTurnosByCliente([FromQuery]int ClienteId)
        {
            try
            {
                return new JsonResult(_service.GetAllTurnosByCliente(ClienteId)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetTurnoById(string Id)
        {
            try
            {
                ResponseTurnoDto turno = _service.GetTurnoById(Id);
                if (turno != null)
                {
                    return new JsonResult(turno) { StatusCode = 200 };
                }
                return new JsonResult(turno) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Medico/{Id}")]
        public IActionResult GetTurnosByMedico(int Id)
        {
            try
            {
                var turnos = _service.GetAllTurnosByMedico(Id);
                if (turnos != null)
                {
                    return new JsonResult(turnos) { StatusCode = 200 };
                }
                return new JsonResult(turnos) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTurnoByClinicaYespecialidad([FromQuery(Name = "clinica")] int clinicaId, [FromQuery(Name = "especialidad")] int especialidadId)
        {
            try
            {
                var turnos = _service.GetTurnoByClinicaYespecialidad(clinicaId,especialidadId);
                if (turnos != null)
                {
                    return new JsonResult(turnos) { StatusCode = 200 };
                }
                return new JsonResult(turnos) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateTurnoByCliente([FromQuery(Name = "turno")] int turnoId, [FromQuery(Name = "cliente")] int clienteId)
        {
            try
            {
                var turnos = _service.GetTurnoById(turnoId);
                turnos.ClienteId = clienteId;

                ResponseTurnoDto tur = _service.UpdateTurnoByCliente(turnos);

                if (turnos != null)
                {
                    return new JsonResult(tur) { StatusCode = 200 };
                }
                return new JsonResult(tur) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("diagnostico")]
        public IActionResult AgregarObs([FromBody] DiagnosticoDTO diagn)
        {
            try
            {
                var turnos = _service.GetTurnoById(Int32.Parse(diagn.TurnoId));
                turnos.Diagnostico = diagn.Diagnostico;

                ResponseTurnoDto tur = _service.AddObservacion(turnos);

                if (turnos != null)
                {
                    return new JsonResult(tur) { StatusCode = 200 };
                }
                return new JsonResult(tur) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Cancelar")]
        public IActionResult CancelarTurno([FromQuery(Name = "turno")] int turnoId)
        {
            try
            {
                var turnos = _service.GetTurnoById(turnoId);
                turnos.Estado = "Cancelado";

                ResponseTurnoDto tur = _service.UpdateTurnoByCliente(turnos);

                if (turnos != null)
                {
                    return new JsonResult(tur) { StatusCode = 200 };
                }
                return new JsonResult(tur) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
