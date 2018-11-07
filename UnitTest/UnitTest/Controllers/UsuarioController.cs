using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitTest.Models;
using System.Threading.Tasks;

namespace UnitTest.Controllers
{
    public class UsuarioController : ApiController
    {

        List<Usuario> usuarios = new List<Usuario>();

        public UsuarioController() { }

        public UsuarioController(List<Usuario> usuarios)
        {
            this.usuarios = usuarios;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            return await Task.FromResult(GetAllUsuarios());
        }

        public IHttpActionResult GetUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault((p) => p.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        public async Task<IHttpActionResult> GetUsuarioAsync(int id)
        {
            return await Task.FromResult(GetUsuario(id));
        }
    }
}
