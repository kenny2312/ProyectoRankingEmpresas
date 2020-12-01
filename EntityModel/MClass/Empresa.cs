using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.MClass
{
    public class Empresa
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

        [DisplayName("direccion")]
        [StringLength(55)]
        public string Address { get; set; }

        [DisplayName("ciudad")]
        [StringLength(60)]
        public string City { get; set; }

        [DisplayName("codigo_postal")]
        [StringLength(10)]
        public string Postal_code { get; set; }

        [DisplayName("telefono")]
        [StringLength(10)]

        public string Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public string empresa { get; set; }
        

    }
}
