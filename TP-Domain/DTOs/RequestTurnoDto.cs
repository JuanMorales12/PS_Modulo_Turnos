using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class RequestTurnoDto
    {
        public int EspecialidadId { get; set; }
        public int ClinicaId { get; set; }
        public int MedicoId { get; set; }
        public int ClienteId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
    }
}
