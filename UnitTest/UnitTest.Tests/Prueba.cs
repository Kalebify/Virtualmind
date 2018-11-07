using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Controllers;
using UnitTest.Models;
using System.Web.Http.Results;

namespace UnitTest.Tests
{
    [TestClass]
    class Prueba
    {
        [TestMethod]
        public void GetAllUsuarios_ShouldReturnAllUsuarios()
        {
            var testUsuarios = GetTestUsuarios();
            var controller = new UsuarioController(testUsuarios);

            var result = controller.GetAllUsuarios() as List<Usuario>;
            Assert.AreEqual(testUsuarios.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllUsuariosAsync_ShouldReturnAllUsuarios()
        {
            var testUsuarios = GetTestUsuarios();
            var controller = new UsuarioController(testUsuarios);

            var result = await controller.GetAllUsuarioAsync() as List<Usuario>;
            Assert.AreEqual(testUsuarios.Count, result.Count);
        }

        [TestMethod]
        public void GetUsuario_ShouldReturnCorrectUsuarios()
        {
            var testUsuarios = GetTestUsuarios();
            var controller = new UsuarioController(testUsuarios);

            var result = controller.GetUsuario(4) as OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testUsuarios[3].Nombre, result.Content.Nombre);
        }

        [TestMethod]
        public async Task GetUsuarioAsync_ShouldReturnCorrectUsuario()
        {
            var testUsuarios = GetTestUsuarios();
            var controller = new UsuarioController(testUsuarios);

            var result = await controller.GetUsuarioAsync(4) as OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testUsuarios[3].Nombre, result.Content.Nombre);
        }

        [TestMethod]
        public void GetUsuario_ShouldNotFindUsuario()
        {
            var controller = new UsuarioController(GetTestUsuarios());

            var result = controller.GetUsuario(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Usuario> GetTestUsuarios()
        {
            var testUsuarios = new List<Usuario>();
            testUsuarios.Add(new Usuario { Id = 1, Nombre = "DemoNombre1", Apellido = "DemoApellido1" });
            testUsuarios.Add(new Usuario { Id = 2, Nombre = "DemoNombre12", Apellido = "DemoApellido2" });
            testUsuarios.Add(new Usuario { Id = 3, Nombre = "DemoNombre13", Apellido = "DemoApellido3" });
            testUsuarios.Add(new Usuario { Id = 4, Nombre = "DemoNombre14", Apellido = "DemoApellido4" });

            return testUsuarios;
        }
    }
}
