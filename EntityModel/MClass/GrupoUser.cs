using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.MClass
{
    public class GrupoUser
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [StringLength(55)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string UsuarioCreation { get; set; }

        public DateTime CreationDate { get; set; }

        public UserSys User { get; set; }
        public ICollection<ActionU> Acciones { get; set; }
    }
}