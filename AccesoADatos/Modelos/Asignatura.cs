using System;
using System.Collections.Generic;

namespace AccesoADatos.Modelos
{
    public partial class Asignatura
    {
        public string CodigoAsignatura { get; set; } = null!;
        public string? CarreraProfesional { get; set; }
        public string? NombreAsignatura { get; set; }
        public string? Creditos { get; set; }
        public string? Cuatrimestre { get; set; }
        public int? HorasSemanales { get; set; }
        public int? DuracionSemanas { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public string? Docente { get; set; }
        public string? Correo { get; set; }
    }
}
