using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD_API.Models;



namespace CRUD_API.Controllers
{
    public class UsuarioController : ApiController
    {
        Usuario[] usuarios = new Usuario[] {
             new Usuario {ID=1, Nombre="Caleb", Apellido="Francois" },
             new Usuario {ID=1, Nombre="Roberto", Apellido="Jime" },
             new Usuario {ID=1, Nombre="Andres", Apellido="Venuo" },
        };


        public IEnumerable<Usuario> GetAllUsuario() {
            return usuarios;
        }

        public IHttpActionResult GetUsuario(int id) {
            var usuario = usuarios.FirstOrDefault((c) => c.ID == id);
            if (usuario != null)
            {
                return Ok(usuario);
            }else
            {
                return NotFound();
            }
        }
           
           
    }
}
