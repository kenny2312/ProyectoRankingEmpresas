using EntityModel.MClass;
using System;
using System.Collections.Generic;
using System.Text;

 namespace EntityModel.Dto.UserDto
{
   public class DtoUser
    {
        public string Guid { get; set; }

        public string Name { get; set; }

    
        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

     
        public virtual GrupoUser grupouser { get; set; }

        public string user { get; set; }
        public string Password { get; set; }

    }
}
