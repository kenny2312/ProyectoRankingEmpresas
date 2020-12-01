using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.MClass
{
    public class Cargos
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Key]
        public string Guid { get; set; }

        [DisplayName("Codigo")]
        [StringLength(20)]
        public string Code { get; set; }

        [DisplayName("Nombre")]
        [StringLength(55)]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string cargos { get; set; }
    }
}
