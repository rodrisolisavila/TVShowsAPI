namespace TvShowsAPI.Models
{
    /// <summary>
    /// DTO para la autenticación de usuario.
    /// </summary>
    public class AuthDto
    {
        /// <summary>
        /// Nombre de usuario del usuario.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; }
    }
}
