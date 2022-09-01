using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using AsignaturasWeb.Models;
using AsignaturasWeb.Services;
using AccesoADatos;
using AccesoADatos.Modelos;

namespace AsignaturasWeb.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly AsignaturaServicio asignaturaServicio;

        [Bind(Direction.ServerToClient)]
        public List<Models.Asignatura> ListaDeAsignaturas { get; set; }

        public DefaultViewModel()
        {
            this.asignaturaServicio = new AsignaturaServicio();
        }
        public override async Task PreRender()
        {
            ListaDeAsignaturas = await asignaturaServicio.ObtenerListaDeAsignaturas();
            await base.PreRender();
        }

    }
}
