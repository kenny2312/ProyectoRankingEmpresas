﻿using AutoMapper;
using EntityModel.Dto.EmpresaDto;
using EntityModel.Dto.UserDto;
using EntityModel.MClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoRankingEmpresas
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            //Diccionario de mapeo de objetos agregar todo lo que quieras mapear
            // Add as many of these lines as you need to map your objects 
            //UserSYS
            CreateMap<UserSys, DtoUser>();
            CreateMap<DtoUser, UserSys>();
            CreateMap<UserSys, DtoUserCreate>();
            CreateMap<DtoUserCreate, UserSys>();
            CreateMap<DtoUserUpdate, UserSys>();
            CreateMap<UserSys, DtoUserUpdate>();
            //
            //Empresa
            CreateMap<Company, DtoCompany>();
            CreateMap<DtoCompany, Company>();
            CreateMap<DtoCompanyCreate, Company>();
            CreateMap<Company, DtoCompanyCreate>();
            CreateMap<DtoCompanyUpdate, Company>();
            CreateMap<Company, DtoCompanyUpdate>();
        }

    }
}
