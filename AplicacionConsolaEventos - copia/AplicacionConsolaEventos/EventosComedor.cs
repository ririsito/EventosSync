using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AplicacionConsolaEventos
{
    [Table("EventosComedor")]
    public partial class EventosComedor
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string IdEmpleado { get; set; }

        [StringLength(255)]
        public string Fecha { get; set; }

        [StringLength(255)]
        public string Hora { get; set; }
    }
}
