using ProyectoRankingEmpresas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EntityModel.MClass
{
   public class UserSys
    {
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Key]
        public string Guid { get; set; }

        [DisplayName("Nombre")]
        [StringLength(55)]
        public string Name { get; set; }

        [DisplayName("Apellido")]
        [StringLength(55)]
        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public int GrupuserId { get; set; }
        [ForeignKey("GrupuserId")]
        public GrupoUser grupouser { get; set; }

        public string user { get; set; }
        public string Password { get; set; }


        [NotMapped]
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
      public  UserSys() {
            RefreshTokens = new List<RefreshToken>() { };


        }
    }
}
