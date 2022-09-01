using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Runtime.Filters;
using AsignaturasWeb.Models;
using AsignaturasWeb.Services;

namespace AsignaturasWeb.ViewModels.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly AsignaturaServicio asignaturaServicio;
        public Asignatura asignatura { get; set; } = new Asignatura();

        public CreateViewModel()
        {
            this.asignaturaServicio = new AsignaturaServicio();
        }

        public async Task AgregarAsignatura()
        {
            await asignaturaServicio.AgregarAsignatura(asignatura);
            Context.RedirectToRoute("Default");
        }
    }
}
