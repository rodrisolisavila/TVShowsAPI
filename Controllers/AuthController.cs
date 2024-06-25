using Microsoft.AspNetCore.Mvc;
using TvShowsAPI.Models;
using TvShowsAPI.Services;

namespace TvShowsApi.Controllers
{
    /// <summary>
    /// Controlador para la autenticación y registro de usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Constructor del controlador AuthController.
        /// </summary>
        /// <param name="authService">Servicio de autenticación.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Endpoint para autenticar a un usuario.
        /// </summary>
        /// <param name="dto">Datos de autenticación (nombre de usuario y contraseña).</param>
        /// <returns>Token JWT si la autenticación es exitosa, Unauthorized si falla.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthDto dto)
        {
            var token = _authService.Authenticate(dto.Username, dto.Password);

            if (token == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(new { token });
        }

        /// <summary>
        /// Endpoint para registrar a un nuevo usuario.
        /// </summary>
        /// <param name="dto">Datos de registro (nombre de usuario y contraseña).</param>
        /// <returns>Usuario registrado.</returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var user = _authService.Register(dto.Username, dto.Password);
            return Ok(user);
        }
    }
}
