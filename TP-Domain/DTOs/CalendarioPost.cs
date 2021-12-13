using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class CalendarioPost
    {
        public int MedicoId { get; set; }
        public string Practica { get; set; }
        public int DiaId { get; set; }
        public DateTime Horario { get; set; }

    }
}
