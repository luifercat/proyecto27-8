using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios; 
using ProyectoCiclo3.App.Dominio;
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class FormServicioModel : PageModel
    {

        private readonly RepositorioUsuario repositorioUsuario;
        private readonly RepositorioEncomienda repositorioEncomienda;
        private readonly RepositorioServicio repositorioServicio;

        public IEnumerable<Usuario> Usuarios {get;set;}
        public IEnumerable<Encomienda> Encomiendas {get;set;}
        public Servicio servicio {get;set;}

        public FormServicioModel(RepositorioServicio repositorioServicio, RepositorioUsuario repositorioUsuario, RepositorioEncomienda repositorioEncomienda)
        {
            this.repositorioServicio=repositorioServicio;
            this.repositorioUsuario=repositorioUsuario;
            this.repositorioEncomienda=repositorioEncomienda;
        }

        public void OnGet()
        {
            Usuarios=repositorioUsuario.GetAll();
            Encomiendas=repositorioEncomienda.GetAll();
        }
    }
}
