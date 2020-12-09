using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoRankingEmpresas;
using ProyectoRankingEmpresas.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestApiRank
{
   public class BasePrueba
    {


        protected ApplicationDbContext ContruirContext(string nombredb)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(nombredb).Options;
            var dbContext = new ApplicationDbContext(opciones);
            return dbContext;
        }
        protected IMapper ContruirAutoMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingProfile());
            });
            return config.CreateMapper();
        }

    }
}
