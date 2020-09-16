using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TP3.Repository;
using TP3.Domain;
using Microsoft.IdentityModel.Tokens;

namespace TP3.ApplicationService
{
    public class AuthenticateService
    {
        private AmigoRepository Repository { get; set; }

        private IConfiguration Configuration { get; set; }

        public AuthenticateService(AmigoRepository repository, IConfiguration configuration)
        {
            this.Repository = repository;
            this.Configuration = configuration;
        }

        public string AuthenticateUser (string nome, string email)
        {
            var amigo = this.Repository.GetAmigoByEmail(email);

            if (amigo == null)      
            {
                return null;
            }

            if (amigo.Nome != nome)
            {
                return null;
            }

            return CreateToken(amigo);
        }

        private string CreateToken(Amigo amigo)
        {
            var key = Encoding.UTF8.GetBytes(this.Configuration["Token:Secret"]);

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, amigo.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, amigo.Nome));
            claims.Add(new Claim(ClaimTypes.Email, amigo.Email));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = "AMIGO-API",
                Issuer = "AMIGO-API"

            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);

            var token = tokenHandler.WriteToken(securityToken);

            return token;

        }
    }
}
