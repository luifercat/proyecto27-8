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
    public class ListEncomiendaModel : PageModel
    {
       
        private readonly RepositorioEncomienda repositorioEncomienda;
        [BindProperty]
        public Encomienda Enco { get; set; }
        public IEnumerable<Encomienda> Encomienda {get;set;}
//  constructor
    public ListEncomiendaModel(RepositorioEncomienda repositorioEncomienda)    
    {
        this.repositorioEncomienda=repositorioEncomienda;
     }
 
    public void OnGet()
    {
        Encomienda=repositorioEncomienda.GetAll();
    }
    public IActionResult OnPost()
    {
        if(Enco.id>0)
        {
        repositorioEncomienda.Delete(Enco.id);
        }
        return RedirectToPage("./List");
    }
    }
}
