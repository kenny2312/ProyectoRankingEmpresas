using AutoMapper;
using EntityModel.MClass;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoRankingEmpresas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoRankingEmpresas.Jwt
{
    public class FrontUser
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }
        public FrontUser( ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            Configuration = configuration;
        }
        public static bool TienePermiso(RolesPermisos valor, UserSys usuario)
        {
            var channels = Enum.GetNames(typeof(RolesPermisos)).ToList();
        
            return usuario.grupouser.Acciones.Where(x => x.Valor.ToString() == valor.ToString())
                         .Any();
   
        }

        public  static UserSys Hola(string Guid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            UserSys aa = null;
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = RankEmp; User Id = postgres; password = kenny");
            using (var cont = new ApplicationDbContext(optionsBuilder.Options))
            {
                /*var a3 = from a in cont.User
                         join b in cont.GrupoUser on a.GrupuserId equals b.Id
                         join c in cont.Actions on b.Id equals c.GroupId
                         where a.Guid == Guid
                         select new UserSys
                         {
                             grupouser = b.,
                         };
                */
                aa = cont.User.Include(o => o.grupouser).Include(o => o.grupouser.Acciones).FirstOrDefault(x => x.Guid == Guid);

            }
                

           
               
            
            return aa;
        }

    }
}
