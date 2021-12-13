using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP_Domain.Entities
{
    public class CalendarioTurnos
    {
        [Key]
        public int Id { get; set; }
        public int DiaId { get; set; }
        public Dia Dia { get; set; }
        public DateTime Horario { get; set; }       
        public int MedicoId{ get; set; }
        public string Practica{ get; set; }
    }
}
