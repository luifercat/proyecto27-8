using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> encomiendas;
 
    public RepositorioEncomienda()
        {
            encomiendas= new List<Encomienda>()
            {
                new Encomienda{id=1,descripcion="Paquete",peso= 100,tipo= "pequeño",presentacion= "aaaaaaa"},
                new Encomienda{id=2,descripcion="Sobre",peso= 200,tipo= "grande",presentacion= "bbbbbbbb"},
                new Encomienda{id=3,descripcion="Documentos",peso= 300,tipo= "mediano",presentacion= "cccccccc"} 
 
            };
        }
 
        public IEnumerable<Encomienda> GetAll()
        {
            return encomiendas;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return encomiendas.SingleOrDefault(b => b.id == id);
        }
        public Encomienda Update(Encomienda newEncomienda){
            var encomienda= encomiendas.SingleOrDefault(b => b.id == newEncomienda.id);
            if(encomienda != null){
                encomienda.descripcion = newEncomienda.descripcion;
                encomienda.peso = newEncomienda.peso;
                encomienda.tipo = newEncomienda.tipo;
                encomienda.presentacion = newEncomienda.presentacion;
                // encomienda.ciudad = newEncomienda.ciudad;
            }
        return encomienda;
        }



    }
}
