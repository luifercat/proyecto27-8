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
    public class ListServicioModel : PageModel
    {
       
        private readonly RepositorioServicio repositorioServicio;
        [BindProperty]
        public Servicio Serv { get; set; }
        public IEnumerable<Servicio> Servicio {get;set;}
//  constructor
    public ListServicioModel(RepositorioServicio repositorioServicio)    
    {
        this.repositorioServicio=repositorioServicio;
     }
 
    public void OnGet()
    {
        Servicio=repositorioServicio.GetAll();
    }
    public IActionResult OnPost()
    {
        if(Serv.id>0)
        {
        repositorioServicio.Delete(Serv.id);
        }
        return RedirectToPage("./List");
    }
    }
}
