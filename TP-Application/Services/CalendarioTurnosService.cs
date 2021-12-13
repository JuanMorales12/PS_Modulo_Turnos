using System;
using System.Collections.Generic;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public interface ICalendarioTurnosService
    {
        ResponseCalendarioTurnosDto CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno);
        List<CalendarioPost> GetAllCalendarioTurnos();

        CalendarioTurnos GetCalendarioMedicoPractica(int DiaId, string practica, int MedicoId);
    }
    public class CalendarioTurnosService : ICalendarioTurnosService
    {
        private readonly IGenericRepository _repository;
        private readonly ICalendarioTurnosQuery _query;
        public CalendarioTurnosService(IGenericRepository repository, ICalendarioTurnosQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public ResponseCalendarioTurnosDto CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno)
        {
            List<CalendarioTurnos> Lista = new List<CalendarioTurnos>(){};

            foreach (var item in calendarioTurno.CalendarioTurnos)
            {
                
                CalendarioTurnos entity = new CalendarioTurnos
                {
                    Practica = item.Practica,
                    MedicoId = item.MedicoId,
                    DiaId = item.DiaId,
                    Horario = Convert.ToDateTime(item.Horario),
                    
                };

                Lista.Add(entity);
                _repository.Add<CalendarioTurnos>(entity);
            }

            return new ResponseCalendarioTurnosDto {
                ListaCalendarioTurnos = Lista
            };
        }

        public List<CalendarioPost> GetAllCalendarioTurnos()
        {
            return _query.GetAllCalendarioTurnos();
        }

        public CalendarioTurnos GetCalendarioMedicoPractica(int DiaId, string practica, int MedicoId)
        {
            return _query.GetCalendarioMedicoPractica(DiaId, practica, MedicoId);
        }
    }
}
