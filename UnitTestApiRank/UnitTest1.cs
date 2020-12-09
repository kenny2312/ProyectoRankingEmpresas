using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoRankingEmpresas;
using ProyectoRankingEmpresas.Model;
using ProyectoRankingEmpresas.Controllers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel.MClass;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace UnitTestApiRank
{
    [TestClass]
    public class UnitTest1: BasePrueba
    {
       
        public UnitTest1()
        {
           
        }
      

        [TestMethod]
        public async Task  LoginMal()
        {
            //Preparacion
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ContruirContext(nombreBD);
                 //  contexto.User.Add(new UserSys() {  });
            var mapper = ContruirAutoMapper();
            IOptions<AppSettings> casteo = Options.Create<AppSettings>(new AppSettings());
                IUserService userService = new UserService(casteo, contexto);
                var modelo=
                new AuthenticateRequest() {Username = "Elias",Password = "pass"};
            //Prueba
            var controller = new Login(userService);
            IActionResult respuesta = (IActionResult)await controller.Authenticate(modelo) ;
            //OkResult
            //NotFoundResult

            //verificacion
            Assert.IsInstanceOfType(respuesta, typeof(NotFoundResult));
        }
    }
}
