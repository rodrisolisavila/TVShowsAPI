using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TvShowsAPI.Models;

namespace TvShowsAPI.Services
{
    /// <summary>
    /// Servicio de autenticación y autorización de usuarios.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly List<User> _users = new List<User>();

        /// <summary>
        /// Constructor del servicio AuthService.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Autentica a un usuario basado en su nombre de usuario y contraseña.
        /// Genera un token JWT si la autenticación es exitosa.
        /// </summary>
        /// <param name="username">Nombre de usuario del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Token JWT si la autenticación es exitosa; de lo contrario, null.</returns>
        public string Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiryMinutes"])),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Registra un nuevo usuario con el nombre de usuario y contraseña especificados.
        /// </summary>
        /// <param name="username">Nombre de usuario del nuevo usuario.</param>
        /// <param name="password">Contraseña del nuevo usuario.</param>
        /// <returns>El usuario registrado.</returns>
        public User Register(string username, string password)
        {
            var user = new User { Username = username, Password = password };
            _users.Add(user);
            return user;
        }
    }
}
