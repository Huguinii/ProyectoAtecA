using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAulaAtecA.Models
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public string Grupo { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public string ProfesorId { get; set; }
        public string ProfesorNombre { get; set; }
        public string Estado { get; set; }
    }
}
