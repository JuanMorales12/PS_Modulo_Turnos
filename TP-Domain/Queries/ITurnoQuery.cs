using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Domain.Queries
{
    public interface ITurnoQuery
    {
        List<Turno> GetTurnosByCliente(int ClienteId);
        List<Turno> GetTurnosByMedico(int MedicoId);
        List<Turno> GetTurnosByClinica(int ClinicaId,DateTime dia);
        List<Turno> GetTurnosByClinicaYespecialidad(int ClinicaId,int especialidadId);
        List<Turno> GetTurnosByClinicaEspecialidadYmedico(int ClinicaId, int especialidadId, int medicoId);
        List<Turno> GetTurnosDelDia(DateTime fecha, string practica);
        Turno GetTurnoById(int id);
        List<Turno> GetTurnosMedicoPorDia(int MedicoId, DateTime fecha);
        List<Turno> GetTurnosByEspecialidad(int especialidadId);
        Turno GetTurnoExistente(int MedicoId, string practica, DateTime fecha, DateTime horario);
    }
}
