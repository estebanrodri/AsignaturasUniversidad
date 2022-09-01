using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;
using AsignaturasWeb.Models;
using AsignaturasWeb.Services;

namespace AsignaturasWeb.ViewModels.CRUD
{
    public class DetailViewModel : MasterPageViewModel
    {
        private readonly AsignaturaServicio asignaturaServicio;
        public Asignatura Asignatura { get; set; }

        [FromRoute("Id")]
        public string CodigoAsignatura { get; private set; }

        public DetailViewModel()
        {
            this.asignaturaServicio = new AsignaturaServicio();
        }

        public override async Task PreRender()
        {
            Asignatura = await asignaturaServicio.ObtenerAsignaturaPorCodigo(CodigoAsignatura);
            await base.PreRender();
        }

        public async Task BorrarAsignatura()
        {
            await asignaturaServicio.BorrarAsignatura(CodigoAsignatura);
            Context.RedirectToRoute("Default", replaceInHistory: true);
        }
    }
}
