using AutoMapper;
using EntityModel.MClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using ProyectoRankingEmpresas.Jwt;
using ProyectoRankingEmpresas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProyectoRankingEmpresas.Controllers
{
    public class PermisoAttribute : ActionFilterAttribute
    {
       


        

        public RolesPermisos Permiso { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           //verificar que los usuarios tengan los permisos respectivos
            base.OnActionExecuting(filterContext);
            var identity = filterContext.HttpContext.User.Identity as ClaimsIdentity;
            string Guid = "";
            if (identity != null)
            {
                IEnumerable<Claim> claims  = identity.Claims;

              Guid = claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            }
           
           

            var dto = FrontUser.Hola(Guid);



                if (!FrontUser.TienePermiso(this.Permiso, dto))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "api",
                        action = "/"
                    }));
                }
        }

      
    }
}