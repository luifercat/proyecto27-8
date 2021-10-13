using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {


        //sgte linea permite conexion a BD
        private readonly AppContext _appContext = new AppContext();
 

        // se hace referencia a dbset de la BD, se trae todas las encomiendas de la BD
        public IEnumerable<Servicio> GetAll()
        {
           return _appContext.Servicios;    //hace referencia al dbset de appcontext 
        }


        public Servicio GetServicioWithId(int id){   //usado para BD, trae Id de la encomienda
            return _appContext.Servicios.Find(id);
        }

        //siguente metodo agrega encomienda y la devuelve
        public Servicio Create(Servicio newServicio)
        {
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;
        }  


        public Servicio Update(Servicio newServicio){
            var serv = _appContext.Servicios.Find(newServicio.id);

            if(serv != null){
                serv.origen = newServicio.origen;
                serv.destino = newServicio.destino;
                serv.fecha = newServicio.fecha;
                serv.hora = newServicio.hora;
                serv.encomienda = newServicio.encomienda;
                //Guardar en base de datos
                 _appContext.SaveChanges();


            }
            return serv;
        }

        public void Delete(int id)
        {
            var serv = _appContext.Servicios.Find(id);
            if (serv == null)
                return;
            _appContext.Servicios.Remove(serv);
            _appContext.SaveChanges();
        }
    }
}