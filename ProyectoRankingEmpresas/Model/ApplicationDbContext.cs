using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityModel.MClass;
namespace ProyectoRankingEmpresas.Model
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
        public virtual DbSet<UserSys> User { get; set; }
        public virtual DbSet<GrupoUser> GrupoUser { get; set; }
        public virtual DbSet<ActionU> Actions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    }
