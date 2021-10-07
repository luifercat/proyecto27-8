using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        //List<Encomienda> encomiendas;

        //sgte linea permite conexion a BD
        private readonly AppContext _appContext = new AppContext();
 
    // se elimina este metodo constructor que se usaba antes de la conexion a BD
    // public RepositorioEncomienda()
    //     {
    //         encomiendas= new List<Encomienda>()
    //         {
    //             new Encomienda{id=1,descripcion="Paquete",peso= 100,tipo= "pequeño",presentacion= "aaaaaaa"},
    //             new Encomienda{id=2,descripcion="Sobre",peso= 200,tipo= "grande",presentacion= "bbbbbbbb"},
    //             new Encomienda{id=3,descripcion="Documentos",peso= 300,tipo= "mediano",presentacion= "cccccccc"} 
     //         };
    //     }
 
        // public IEnumerable<Encomienda> GetAll()     usado antes de conexioon a BD
        // {
        //     return encomiendas;
        // }
 
        // se hace referencia a dbset de la BD, se trae todas las encomiendas de la BD
        public IEnumerable<Encomienda> GetAll()
        {
           return _appContext.Encomiendas;    //hace referencia al dbset de appcontext 
        }


        // public Encomienda GetEncomiendaWithId(int id){       usado antes de conexion a BD
        //     return encomiendas.SingleOrDefault(b => b.id == id);
        // }


        public Encomienda GetEncomiendaWithId(int id){   //usado para BD, trae Id de la encomienda
            return _appContext.Encomiendas.Find(id);
        }
        // public Encomienda Create(Encomienda newEncomienda)      usado antes de conexion a BD
        // {
        //    if(encomiendas.Count > 0){
        //    newEncomienda.id=encomiendas.Max(r => r.id) +1; 
        //     }else{
        //        newEncomienda.id = 1; 
        //     }
        //    encomiendas.Add(newEncomienda);
        //    return newEncomienda;
        // }

        //siguente metodo agrega encomienda y la devuelve
        public Encomienda Create(Encomienda newEncomienda)
        {
            var addEncomienda = _appContext.Encomiendas.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }  
        // public Encomienda Update(Encomienda newEncomienda){
        //     var encomienda= encomiendas.SingleOrDefault(b => b.id == newEncomienda.id);
        //     if(encomienda != null){
        //         encomienda.descripcion = newEncomienda.descripcion;
        //         encomienda.peso = newEncomienda.peso;
        //         encomienda.tipo = newEncomienda.tipo;
        //         encomienda.presentacion = newEncomienda.presentacion;
        //         // encomienda.ciudad = newEncomienda.ciudad;
        //     }
        // return encomienda;
        // }

        public Encomienda Update(Encomienda newEncomienda){
            var enco = _appContext.Encomiendas.Find(newEncomienda.id);

            if(enco != null){
                enco.descripcion = newEncomienda.descripcion;
                enco.peso = newEncomienda.peso;
                enco.tipo = newEncomienda.tipo;
                enco.presentacion = newEncomienda.presentacion;
                //enco.ciudad = newEncomienda.ciudad;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            return enco;
        }

        // public void Delete(int id)   antes de conexion a BD
        // {
        // var enco= encomiendas.SingleOrDefault(b => b.id == id);
        // encomiendas.Remove(enco);
        // return;
        //}

        public void Delete(int id)
        {
            var enco = _appContext.Encomiendas.Find(id);
            if (enco == null)
                return;
            _appContext.Encomiendas.Remove(enco);
            _appContext.SaveChanges();
        }
    }
}
