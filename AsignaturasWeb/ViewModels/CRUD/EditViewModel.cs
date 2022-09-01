using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;
using AsignaturasWeb.Models;
using AsignaturasWeb.Services;
using AccesoADatos.Modelos;
using System.Security.Cryptography.Xml;

namespace AsignaturasWeb.ViewModels.CRUD
{
    public class EditViewModel : MasterPageViewModel
    {

        private readonly AsignaturaServicio asignaturaServicio;
        public Models.Asignatura asignatura { get; set; }

        [FromRoute("Id")]
        public string CodigoAsignatura { get; private set; }

        public EditViewModel()
        {
            this.asignaturaServicio = new AsignaturaServicio();
        }

        public override async Task PreRender()
        {
            if (CodigoAsignatura != "")
            {
                asignatura = await asignaturaServicio.ObtenerAsignaturaPorCodigo(CodigoAsignatura);
            }
            await base.PreRender();
        }

        public async Task EditarAsignatura()
        {
            await asignaturaServicio.ModificarAsignatura(asignatura);
            Context.RedirectToRoute("CRUD_Detail", new { Id = CodigoAsignatura });
        }

    }
}
