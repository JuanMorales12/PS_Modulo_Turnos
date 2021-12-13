using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class TurnoDto
    {
        public int MedicoId { get; set; }
        public int ClienteId { get; set; }
        public int ClinicaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
    }
}
