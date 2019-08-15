using System;
using System.Collections.Generic;

namespace AplicacionConsolaEventos
{
    public partial class Empleados
    {
        public int Id { get; set; }
        public int? IdFoto { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public string NumeroExtension { get; set; }
        public string Celular { get; set; }
        public string CuentaRed { get; set; }
        public string CorreoElectronico { get; set; }
        public int IdArea { get; set; }
        public int IdDepartamento { get; set; }
        public int IdClaseNomina { get; set; }
        public int IdNivelSeguridad { get; set; }
        public int IdJefeInmediato { get; set; }
    }
}
