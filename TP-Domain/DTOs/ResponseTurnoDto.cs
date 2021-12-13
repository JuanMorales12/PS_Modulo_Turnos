using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class ResponseTurnoDto
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public int EspecialidadId { get; set; }
        public int ClienteId { get; set; }
        public int ClinicaId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public string Estado { get; set; }
        public string Diagnostico { get; set; }
    }
}
