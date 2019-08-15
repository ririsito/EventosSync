using System;
using System.Collections.Generic;

namespace AplicacionConsolaEventos
{
    public partial class Permisos
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public string FechaSalida { get; set; }
        public string FechaSalidaReal { get; set; }
        public string HoraSalida { get; set; }
        public string HoraSalidaReal { get; set; }
        public string FechaRegreso { get; set; }
        public string FechaRegresoReal { get; set; }
        public string HoraRegreso { get; set; }
        public string HoraRegresoReal { get; set; }
        public string Motivo { get; set; }
        public int IdEstado { get; set; }
    }
}
