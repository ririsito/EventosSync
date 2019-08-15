using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionConsolaEventos
{
    public partial class Eventos
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdEmpleado { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Tevento { get; set; }
    }
}
