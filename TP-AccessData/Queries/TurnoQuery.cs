using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_AccessData.Queries
{
    public class TurnoQuery : ITurnoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public TurnoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<Turno> GetTurnosByCliente(int ClienteId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("ClienteId", "=", ClienteId)
                .Where("Estado", "<>", "Cancelado")
                .WhereDate("Fecha", ">=", DateTime.Now.ToString("MM-dd-yyyy"))
                .OrderBy("Fecha");

            var result = query.Get<Turno>();


            return result.ToList();
        }
        public List<Turno> GetTurnosByEspecialidad(int especialidadId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("ClienteId", "=", 0)
                .WhereDate("Fecha", ">=", DateTime.Now.ToString("MM-dd-yyyy"))
                .Where("EspecialidadId","=",especialidadId)
                .OrderBy("Fecha");

            var result = query.Get<Turno>();


            return result.ToList();
        }

        public List<Turno> GetTurnosByMedico(int MedicoId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("MedicoId", "=", MedicoId)
                .Where("ClienteId","<>",0)
                .Where("Estado","<>","Cancelado")
                .WhereDate("Fecha", ">=", DateTime.Now.ToString("MM-dd-yyyy"))
                .OrderBy("Fecha");

            var result = query.Get<Turno>();


            return result.ToList();
        }

        public List<Turno> GetTurnosDelDia(DateTime fecha, string practica)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("Practica", "=", practica)
                .Where("Fecha", "=", fecha);

            var result = query.Get<Turno>();

            return result.ToList();
        }

        public Turno GetTurnoById(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("Id", "=", id);

            return query.FirstOrDefault<Turno>();
        }

        public List<Turno> GetTurnosMedicoPorDia(int MedicoId, DateTime fecha)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("MedicoId", "=", MedicoId)
                .Where("Fecha", "=", fecha.ToString("MM-dd-yyyy"));
           
            return query
                .Get<Turno>()
                .ToList();
        }

        public Turno GetTurnoExistente(int MedicoId, string practica, DateTime fecha, DateTime horario)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("MedicoId", "=", MedicoId)
                .WhereDate("Fecha", "=", fecha.ToString("MM-dd-yyyy"))
                .Where("Practica", "=", practica)
                .WhereTime("Horario", "=", horario.ToString("HH:mm"));
            
            return query.FirstOrDefault<Turno>();
        }

        public List<Turno> GetTurnosByClinica(int ClinicaId,DateTime fecha)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("ClinicaId", "=", ClinicaId)
                .Where("ClienteId","=",0)
                .WhereDate("Fecha","=",fecha.ToString("MM-dd-yyyy"));

            return query.Get<Turno>().ToList();
        }

        public List<Turno> GetTurnosByClinicaYespecialidad(int ClinicaId, int especialidadId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var fecha = DateTime.Today;
            var query = db.Query("Turnos")
                .Where("ClinicaId", "=", ClinicaId)
                .Where("EspecialidadId", "=",especialidadId)
                .Where("ClienteId","=",0)
                .WhereDate("Fecha", ">=", fecha.ToString("MM-dd-yyyy")); 

            return query.Get<Turno>().ToList();
        }
        public List<Turno> GetTurnosByClinicaEspecialidadYmedico(int ClinicaId, int especialidadId, int medicoId)
        {
            if(medicoId == 0)
            {
                return GetTurnosByClinicaYespecialidad(ClinicaId, especialidadId);
            }
            var db = new QueryFactory(connection, sqlKataCompiler);
            var fecha = DateTime.Today;
            var query = db.Query("Turnos")
                .Where("ClinicaId", "=", ClinicaId)
                .Where("EspecialidadId", "=", especialidadId)
                .Where("ClienteId", "=", 0)
                .Where("MedicoId", "=", medicoId)
                .WhereDate("Fecha", ">=", fecha.ToString("MM-dd-yyyy"));

            return query.Get<Turno>().ToList();
        }
    }
}
