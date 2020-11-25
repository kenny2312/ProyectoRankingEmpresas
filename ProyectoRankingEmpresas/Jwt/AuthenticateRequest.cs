using System.ComponentModel.DataAnnotations;

namespace ProyectoRankingEmpresas
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}