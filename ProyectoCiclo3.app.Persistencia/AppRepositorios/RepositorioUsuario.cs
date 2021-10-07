using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        //List<Usuario> usuarios;
        private readonly AppContext _appContext = new AppContext();
 
    // public RepositorioUsuario()       se elimina ya no se necesita, se va a trar la inf de la bd
    //     {
    //         usuarios= new List<Usuario>()
    //         {
    //             new Usuario{id=1,nombre="Mario",apellidos= "Sánchez",direccion= "Carrera 27",telefono= "8945412121"},
    //             new Usuario{id=2,nombre="Camila",apellidos= "Rodriguez",direccion= "Calle 96",telefono= "895656562"},
    //             new Usuario{id=3,nombre="Maria Carolina",apellidos= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454"} 
 
    //         };
    //     }
 
        // public IEnumerable<Usuario> GetAll() antes de conexion a BD
        // {
        //     return usuarios;
        // }

        // GetAll para la BD -  trae todos los usuario de la bd
        public IEnumerable<Usuario> GetAll()
        {
           return _appContext.Usuarios;
        }
 
        // public Usuario GetUsuarioWithId(int id){     ANTES DE CONEXION A BD
        //     return usuarios.SingleOrDefault(b => b.id == id);
        // }

        // GetUsuarioWithId para BD 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuarios.Find(id);
        }
        // public Usuario Create(Usuario newUsuario)    Antes de conectar a BD
        // {
        //    if(usuarios.Count > 0){
        //    newUsuario.id=usuarios.Max(r => r.id) +1; 
        //     }else{
        //        newUsuario.id = 1; 
        //     }
        //    usuarios.Add(newUsuario);
        //    return newUsuario;
        // }

        // metodo create con BD
        public Usuario Create(Usuario newUsuario)
        {
            var addUsuario = _appContext.Usuarios.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;      //retorna la entidad usuario que se acaba de crear
        }

        // public Usuario Update(Usuario newUsuario){     ANTES DE CONEXION A BD
        //     var usuario= usuarios.SingleOrDefault(b => b.id == newUsuario.id);
        //     if(usuario != null){
        //         usuario.nombre = newUsuario.nombre;
        //         usuario.apellidos = newUsuario.apellidos;
        //         usuario.direccion = newUsuario.direccion;
        //         usuario.telefono = newUsuario.telefono;
        //         // usuario.ciudad = newUsuario.ciudad;
        //     }
        // return usuario;
        // }

        // Update con BD
        public Usuario Update(Usuario newUsuario){
            var user = _appContext.Usuarios.Find(newUsuario.id);

            if(user != null){
                user.nombre = newUsuario.nombre;
                user.apellidos = newUsuario.apellidos;
                user.direccion = newUsuario.direccion;
                user.telefono = newUsuario.telefono;
                // user.ciudad = newUsuario.ciudad;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            return user;
        }

        // public void Delete(int id)
        // {
        // var user= usuarios.SingleOrDefault(b => b.id == id);
        // usuarios.Remove(user);
        // return;
        //}

        // metodo delete con BD
        public void Delete(int id)
        {
        var user = _appContext.Usuarios.Find(id);
        if (user == null)
            return;
        _appContext.Usuarios.Remove(user);
        _appContext.SaveChanges();
        }
    }
}
