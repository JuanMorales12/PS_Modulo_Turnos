using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class TurnosByHoursDto
    {
        public DateTime Fecha { get; set; }
        public List<ResponseTurnoDto> Turnos { get; set; }
    }
}
