using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{

    public class TurnoService : ITurnoService
    {
        private readonly IGenericRepository _repository;
        private readonly ITurnoQuery _query;
        private readonly ICalendarioTurnosQuery _calendarioTurnosQuery;
        public TurnoService(IGenericRepository repository, ITurnoQuery query, ICalendarioTurnosQuery calendarioTurnosQuery)
        {
            _repository = repository;
            _query = query;
            _calendarioTurnosQuery = calendarioTurnosQuery;
        }

        public Turno CreateTurno(RequestTurnoDto turno)
        {
            /*validateCrearTurno(turno);*/
            Turno entity = new Turno
            {
                MedicoId = turno.MedicoId,
                ClienteId = turno.ClienteId,
                ClinicaId = turno.ClinicaId,
                EspecialidadId = turno.EspecialidadId,
                Fecha = ConvertirStringDiaAdate(turno.Fecha),
                Horario = ConvertirStringHoraAtimespan(turno.Horario),
                Estado = "Aceptado",
                Precio = 0,
                Diagnostico = "Sin diagnostico"
            };

            _repository.Add<Turno>(entity);
            
            return entity;
        }

        public ResponseTurnoDto UpdateTurnoByCliente(Turno turno)
        {
            /*validateCrearTurno(turno);*/
            Turno entity = new Turno
            {
                Id = turno.Id,
                ClienteId = turno.ClienteId,
                MedicoId = turno.MedicoId,
                ClinicaId = turno.ClinicaId,
                EspecialidadId = turno.EspecialidadId,
                Fecha = turno.Fecha,
                Horario = turno.Horario,
                Estado = turno.Estado,
                Precio = turno.Precio,
                Diagnostico = turno.Diagnostico
            };

            ResponseTurnoDto tur = new ResponseTurnoDto
            {
                Id = turno.Id,
                ClienteId = turno.ClienteId,
                MedicoId = turno.MedicoId,
                ClinicaId = turno.ClinicaId,
                EspecialidadId = turno.EspecialidadId,
                Fecha = turno.Fecha.ToShortDateString(),
                Horario = turno.Horario.ToString(),
                Estado = turno.Estado,
                Diagnostico = turno.Diagnostico
            };


            _repository.Update<Turno>(entity);

            return tur;
        }


        public ResponseTurnoDto AddObservacion(Turno turno)
        {
            /*validateCrearTurno(turno);*/
            Turno entity = new Turno
            {
                Id = turno.Id,
                ClienteId = turno.ClienteId,
                MedicoId = turno.MedicoId,
                ClinicaId = turno.ClinicaId,
                EspecialidadId = turno.EspecialidadId,
                Fecha = turno.Fecha,
                Horario = turno.Horario,
                Estado = turno.Estado,
                Precio = turno.Precio,
                Diagnostico = turno.Diagnostico
            };

            ResponseTurnoDto tur = new ResponseTurnoDto
            {
                Id = turno.Id,
                ClienteId = turno.ClienteId,
                MedicoId = turno.MedicoId,
                ClinicaId = turno.ClinicaId,
                EspecialidadId = turno.EspecialidadId,
                Fecha = turno.Fecha.ToShortDateString(),
                Horario = turno.Horario.ToString(),
                Estado = turno.Estado,
                Diagnostico = turno.Diagnostico
            };


            _repository.Update<Turno>(entity);

            return tur;
        }

        /*        public void validateCrearTurno(RequestTurnoDto turno) {
                    Turno turnoExistente = _query.GetTurnoExistente(turno.MedicoId, turno.EspecialidadId, turno.Fecha, turno.Horario);
                    if (turnoExistente != null)
                    {
                        throw new Exception("El turno el cual intenta reservar ya está reservado.");
                    }
                }*/

        public List<ResponseTurnoDto> GetAllTurnosByCliente(int ClienteId)
        {
            List<Turno> turnos = _query.GetTurnosByCliente(ClienteId);
            List<ResponseTurnoDto> turnosDTO = new List<ResponseTurnoDto>();
            foreach(Turno a in turnos)
            {
                ResponseTurnoDto tur = new ResponseTurnoDto()
                {
                    Id = a.Id,
                    ClienteId = a.ClienteId,
                    EspecialidadId = a.EspecialidadId,
                    Fecha = a.Fecha.ToShortDateString(),
                    Horario = a.Horario.ToString(),
                    MedicoId = a.MedicoId,
                    Estado = a.Estado,
                    ClinicaId = a.ClinicaId,
                    Diagnostico = a.Diagnostico

                };
                turnosDTO.Add(tur);
            }

            return turnosDTO;
        }


        public ResponseTurnoDto GetTurnoById(string id)
        {
            Turno a = _query.GetTurnoById(Int32.Parse(id));
            ResponseTurnoDto tur = new ResponseTurnoDto()
            {
                Id = a.Id,
                ClienteId = a.ClienteId,
                EspecialidadId = a.EspecialidadId,
                Fecha = a.Fecha.ToShortDateString(),
                Horario = a.Horario.ToString(),
                MedicoId = a.MedicoId,
                Estado = a.Estado,
                ClinicaId = a.ClinicaId,
                Diagnostico = a.Diagnostico

            };

            return tur;
        }
        public Turno GetTurnoById(int id)
        {
            Turno a = _query.GetTurnoById(id);
            return a;
        }

        public List<ResponseTurnoDto> GetAllTurnosByMedico(int MedicoId)
        {
            List<Turno> turnos = _query.GetTurnosByMedico(MedicoId);
            List<ResponseTurnoDto> turnosDTO = new List<ResponseTurnoDto>();
            foreach (Turno a in turnos)
            {
                ResponseTurnoDto tur = new ResponseTurnoDto()
                {
                    Id = a.Id,
                    ClienteId = a.ClienteId,
                    EspecialidadId = a.EspecialidadId,
                    Fecha = a.Fecha.ToShortDateString(),
                    Horario = a.Horario.ToString(),
                    MedicoId = a.MedicoId,
                    Estado = a.Estado,
                    ClinicaId = a.ClinicaId   ,
                    Diagnostico = a.Diagnostico

                };
                turnosDTO.Add(tur);
            }

            return turnosDTO;
        }

        public List<ResponseTurnoDto> getTurnosByEspecialidad(int especialidadId)
        {
            List<Turno> turnos = _query.GetTurnosByEspecialidad(especialidadId);
            List<ResponseTurnoDto> turnosDTO = new List<ResponseTurnoDto>();
            foreach (Turno a in turnos)
            {
                ResponseTurnoDto tur = new ResponseTurnoDto()
                {
                    ClienteId = a.ClienteId,
                    EspecialidadId = a.EspecialidadId,
                    Fecha = a.Fecha.ToShortDateString(),
                    Horario = a.Horario.ToString(),
                    MedicoId = a.MedicoId,
                    Estado = a.Estado,
                    ClinicaId = a.ClinicaId,
                    Diagnostico = a.Diagnostico

                };
                turnosDTO.Add(tur);
            }

            return turnosDTO;
        }

        public List<ResponseTurnoDto> GetTurnoByClinicaYespecialidad(int clinicaId, int especialidadId)
        {
            List<Turno> turnos = _query.GetTurnosByClinicaYespecialidad(clinicaId,especialidadId);
            List<ResponseTurnoDto> turnosDTO = new List<ResponseTurnoDto>();
            foreach (Turno a in turnos)
            {
                ResponseTurnoDto tur = new ResponseTurnoDto()
                {
                    Id = a.Id,
                    ClienteId = a.ClienteId,
                    EspecialidadId = a.EspecialidadId,
                    Fecha = a.Fecha.ToShortDateString(),
                    Horario = a.Horario.ToString(),
                    MedicoId = a.MedicoId,
                    Estado = a.Estado,
                    ClinicaId = a.ClinicaId

                };
                turnosDTO.Add(tur);
            }

            return turnosDTO;
        }

        public List<ResponseTurnoDto> GetTurnoByClinicaEspecialidadYmedico(int clinicaId, int especialidadId, int medicoid)
        {
            List<Turno> turnos = _query.GetTurnosByClinicaEspecialidadYmedico(clinicaId, especialidadId,medicoid);
            List<ResponseTurnoDto> turnosDTO = new List<ResponseTurnoDto>();
            foreach (Turno a in turnos)
            {
                ResponseTurnoDto tur = new ResponseTurnoDto()
                {
                    ClienteId = a.ClienteId,
                    EspecialidadId = a.EspecialidadId,
                    Fecha = a.Fecha.ToShortDateString(),
                    Horario = a.Horario.ToString(),
                    MedicoId = a.MedicoId,
                    Estado = a.Estado,
                    ClinicaId = a.ClinicaId

                };
                turnosDTO.Add(tur);
            }

            return turnosDTO;
        }


        public DateTime ConvertirStringDiaAdate(string dia)
        {
            string diaFormateado = dia.Replace("-", "");
            int NumeroAnio = Int32.Parse(diaFormateado.Substring(0, 4));
            int NumeroMes = Int32.Parse(diaFormateado.Substring(4, 2));
            int NumeroDia = Int32.Parse(diaFormateado.Substring(6, 2));
            return new DateTime(NumeroAnio, NumeroMes, NumeroDia);
        }

        public TimeSpan ConvertirStringHoraAtimespan(string hora)
        {
            string horaFormateada = hora.Replace(":", "");
            int horaNumero = Int32.Parse(horaFormateada.Substring(0, 2));
            int minutoNumero = Int32.Parse(horaFormateada.Substring(2, 2));
            return new TimeSpan(horaNumero, minutoNumero, 0);
        }
    }
}
