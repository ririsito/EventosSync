using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionConsolaEventos
{
    public class Eventos
    {
       
        
        public int Id { get; set; }

        public String IdEmpleado { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Tevento { get; set; }
    }
}
