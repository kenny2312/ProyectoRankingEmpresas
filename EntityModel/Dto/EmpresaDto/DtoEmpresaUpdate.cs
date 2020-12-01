using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.Dto.EmpresaDto
{
    public class DtoEmpresaUpdate
    {
        public string Guid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_code { get; set; }
        public string Phone { get; set; }
    }
}
