using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Application.Services
{
    public interface ITurnoService
    {
        Turno CreateTurno(RequestTurnoDto turno);
        List<ResponseTurnoDto> GetAllTurnosByCliente(int ClienteId);
        List<ResponseTurnoDto> GetAllTurnosByMedico(int MedicoId);
        ResponseTurnoDto GetTurnoById(string id);
        Turno GetTurnoById(int id);
        ResponseTurnoDto UpdateTurnoByCliente(Turno turno);
        ResponseTurnoDto AddObservacion(Turno turno);
        List<ResponseTurnoDto> getTurnosByEspecialidad(int especialidadId);
        //ResponseTurnoDto GetTurnoByClinica(int clinicaId, DateTime fecha);
        //ResponseTurnoDto getTurnoByMedicoYclinica(int clinicaId, int medicoId, DateTime fecha);
        List<ResponseTurnoDto> GetTurnoByClinicaYespecialidad(int clinicaId, int especialidadId);
        List<ResponseTurnoDto> GetTurnoByClinicaEspecialidadYmedico(int clinicaId, int especialidadId,int medicoId);
        //List<TurnosByHoursDto> GetAllTurnosDisponibles(DateTime fecha, string practica);
        //List<ResponseTurnoDto> GetTurnosMedico(int MedicoId, string practica, DateTime fecha);
    }
}
