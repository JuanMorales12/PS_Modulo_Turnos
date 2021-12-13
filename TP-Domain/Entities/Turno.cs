using System;
using System.ComponentModel.DataAnnotations;

namespace TP_Domain.Entities
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public int EspecialidadId {get; set;}
        public DateTime Fecha {get; set;}
        public TimeSpan Horario {get; set;}
        public string Estado {get; set;}
        public double Precio {get; set;}
        public int ClienteId {get; set;}
        public int MedicoId {get;set;}
        public int ClinicaId {get; set;}
        public string Diagnostico { get; set; }
       
    }
}
