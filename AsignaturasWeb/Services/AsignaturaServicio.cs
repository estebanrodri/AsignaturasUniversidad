using AccesoADatos;
using AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsignaturasWeb.Services
{
    public class AsignaturaServicio
    {
        private readonly RepositorioDatos repositorio;
        private List<Asignatura> ListaDeAsignaturas { get; set; }

        public AsignaturaServicio()
        {
            UniversidadABCContext ContextoBD = new UniversidadABCContext();
            this.repositorio = new RepositorioDatos(ContextoBD);
        }

        internal async Task<List<Models.Asignatura>> ObtenerListaDeAsignaturas()
        {
            ListaDeAsignaturas = await repositorio.ObtenerListaDeAsignaturas();
            return ConvertirListaDeAsignaturas(ListaDeAsignaturas);
        }

        internal async Task<Models.Asignatura> ObtenerAsignaturaPorCodigo(string elCodigo)
        {
            Asignatura asignatura = await repositorio.ObtenerAsignatura(elCodigo);
            return ConvertirAsignatura(asignatura);
        }

        private List<Models.Asignatura> ConvertirListaDeAsignaturas(List<Asignatura> listaDeAsignaturas)
        {
            return (from asignaturaBD in listaDeAsignaturas select new Models.Asignatura
                    {
                        CodigoAsignatura = asignaturaBD.CodigoAsignatura.Trim(),
                        CarreraProfesional = asignaturaBD.CarreraProfesional.Trim(),
                        NombreAsignatura = asignaturaBD.NombreAsignatura.Trim(),
                        Creditos = asignaturaBD.Creditos.Trim(),
                        Cuatrimestre = asignaturaBD.Cuatrimestre.Trim(),
                        HorasSemanales = Convert.ToInt32(asignaturaBD.HorasSemanales),
                        DuracionSemanas = Convert.ToInt32(asignaturaBD.DuracionSemanas),
                        Inicio = Convert.ToDateTime(asignaturaBD.Inicio).ToString("dd/MM/yyyy HH:mm:ss"),
                        Termino = Convert.ToDateTime(asignaturaBD.Termino).ToString("dd/MM/yyyy HH:mm:ss"),
                        Docente = asignaturaBD.Docente.Trim(),
                        Correo = asignaturaBD.Correo.Trim()
                    }
            ).ToList();
        }

        private Models.Asignatura ConvertirAsignatura(Asignatura asignatura)
        {
            return new Models.Asignatura
            {
                CodigoAsignatura = asignatura.CodigoAsignatura.Trim(),
                CarreraProfesional = asignatura.CarreraProfesional.Trim(),
                NombreAsignatura = asignatura.NombreAsignatura.Trim(),
                Creditos = asignatura.Creditos.Trim(),
                Cuatrimestre = asignatura.Cuatrimestre.Trim(),
                HorasSemanales = Convert.ToInt32(asignatura.HorasSemanales),
                DuracionSemanas = Convert.ToInt32(asignatura.DuracionSemanas),
                Inicio = Convert.ToDateTime(asignatura.Inicio).ToString("dd/MM/yyyy HH:mm:ss"),
                Termino = Convert.ToDateTime(asignatura.Termino).ToString("dd/MM/yyyy HH:mm:ss"),
                Docente = asignatura.Docente.Trim(),
                Correo = asignatura.Correo.Trim()
            };
        }

        private Asignatura ConvertirAsignatura(Models.Asignatura asignatura)
        {
            return new Asignatura
            {
                CodigoAsignatura = asignatura.CodigoAsignatura.Trim(),
                CarreraProfesional = asignatura.CarreraProfesional.Trim(),
                NombreAsignatura = asignatura.NombreAsignatura.Trim(),
                Creditos = asignatura.Creditos.Trim(),
                Cuatrimestre = asignatura.Cuatrimestre.Trim(),
                HorasSemanales = Convert.ToInt32(asignatura.HorasSemanales),
                DuracionSemanas = Convert.ToInt32(asignatura.DuracionSemanas),
                Inicio = Convert.ToDateTime(asignatura.Inicio),
                Termino = Convert.ToDateTime(asignatura.Termino),
                Docente = asignatura.Docente.Trim(),
                Correo = asignatura.Correo.Trim()
            };
        }

        internal async Task AgregarAsignatura(Models.Asignatura asignatura)
        {
            Asignatura asignaturaEntidad = ConvertirAsignatura(asignatura);
            await repositorio.InsertarAsignatura(asignaturaEntidad);
        }

        internal async Task ModificarAsignatura(Models.Asignatura asignatura)
        {
            Asignatura asignaturaEntidad = ConvertirAsignatura(asignatura);
            await repositorio.ActualizarAsignatura(asignaturaEntidad);
        }

        internal async Task BorrarAsignatura(string elCodigoAsignatura)
        {
            await repositorio.EliminarAsignatura(elCodigoAsignatura);
        }


    }
}
