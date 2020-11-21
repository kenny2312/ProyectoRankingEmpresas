using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.Dto.UserDto
{
  public  class DtoUserCreate
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string user { get; set; }
        public string Password { get; set; }
        public int GrupuserId { get; set; }
    }
}
