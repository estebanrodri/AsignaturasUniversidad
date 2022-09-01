using System;

namespace AsignaturasWeb.Models
{
    public class Asignatura
    {
        public string CodigoAsignatura { get; set; }
        public string CarreraProfesional { get; set; }
        public string NombreAsignatura { get; set; }
        public string Creditos { get; set; }
        public string Cuatrimestre { get; set; }
        public int HorasSemanales { get; set; }
        public int DuracionSemanas { get; set; }
        public string Inicio { get; set; }
        public string Termino { get; set; }
        public string Docente { get; set; }
        public string Correo { get; set; }
    }
}
