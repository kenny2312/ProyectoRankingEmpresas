using EntityModel.MClass;
using System.Text.Json.Serialization;

namespace ProyectoRankingEmpresas
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
        public AuthenticateResponse(UserSys user, string token, string refreshToken)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            Username = user.user;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}