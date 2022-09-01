using AccesoADatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos
{
    public class RepositorioDatos
    {
        private readonly UniversidadABCContext universidadDbContext;

        public RepositorioDatos(UniversidadABCContext universidadDbContext)
        {
            this.universidadDbContext = universidadDbContext;
        }

        public async Task<List<Asignatura>> ObtenerListaDeAsignaturas()
        {

            return await universidadDbContext.Asignaturas.Select(
                model => new Asignatura
                {
                    CodigoAsignatura = model.CodigoAsignatura,
                    CarreraProfesional = model.CarreraProfesional,
                    NombreAsignatura = model.NombreAsignatura,
                    Creditos = model.Creditos,
                    Cuatrimestre = model.Cuatrimestre,
                    HorasSemanales = model.HorasSemanales,
                    DuracionSemanas = model.DuracionSemanas,
                    Inicio = model.Inicio,
                    Termino = model.Termino,
                    Docente = model.Docente,
                    Correo = model.Correo
                }
            ).ToListAsync();
        }

        public async Task<Asignatura> ObtenerAsignatura(string elCodigoAsignatura)
        {

            return await universidadDbContext.Asignaturas.Select(
                model => new Asignatura
                {
                    CodigoAsignatura = model.CodigoAsignatura,
                    CarreraProfesional = model.CarreraProfesional,
                    NombreAsignatura = model.NombreAsignatura,
                    Creditos = model.Creditos,
                    Cuatrimestre = model.Cuatrimestre,
                    HorasSemanales = model.HorasSemanales,
                    DuracionSemanas = model.DuracionSemanas,
                    Inicio = model.Inicio,
                    Termino = model.Termino,
                    Docente = model.Docente,
                    Correo = model.Correo
                }
            ).FirstOrDefaultAsync(model => model.CodigoAsignatura == elCodigoAsignatura);
        }


        public async Task ActualizarAsignatura(Asignatura asignatura)
        {
            var Entidad = await universidadDbContext.Asignaturas.FirstOrDefaultAsync(s => s.CodigoAsignatura == asignatura.CodigoAsignatura);
            if (Entidad != null)
            {
                Entidad.CodigoAsignatura = asignatura.CodigoAsignatura;
                Entidad.CarreraProfesional = asignatura.CarreraProfesional;
                Entidad.NombreAsignatura = asignatura.NombreAsignatura;
                Entidad.Creditos = asignatura.Creditos;
                Entidad.Cuatrimestre = asignatura.Cuatrimestre;
                Entidad.HorasSemanales = asignatura.HorasSemanales;
                Entidad.DuracionSemanas = asignatura.DuracionSemanas;
                Entidad.Inicio = asignatura.Inicio;
                Entidad.Termino = asignatura.Termino;
                Entidad.Docente = asignatura.Docente;
                Entidad.Correo = asignatura.Correo;

                await universidadDbContext.SaveChangesAsync();
            }
        }

        public async Task InsertarAsignatura(Asignatura asignatura)
        {
            var Entidad = new Asignatura()
            {
                CodigoAsignatura = asignatura.CodigoAsignatura,
                CarreraProfesional = asignatura.CarreraProfesional,
                NombreAsignatura = asignatura.NombreAsignatura,
                Creditos = asignatura.Creditos,
                Cuatrimestre = asignatura.Cuatrimestre,
                HorasSemanales = asignatura.HorasSemanales,
                DuracionSemanas = asignatura.DuracionSemanas,
                Inicio = asignatura.Inicio,
                Termino = asignatura.Termino,
                Docente = asignatura.Docente,
                Correo = asignatura.Correo
            };

            universidadDbContext.Asignaturas.Add(Entidad);
            await universidadDbContext.SaveChangesAsync();
        }

        public async Task EliminarAsignatura(string elCodigoAsignatura)
        {
            var Entidad = new Asignatura()
            {
                CodigoAsignatura = elCodigoAsignatura
            };
            universidadDbContext.Asignaturas.Attach(Entidad);
            universidadDbContext.Asignaturas.Remove(Entidad);
            await universidadDbContext.SaveChangesAsync();
        }

    }

}