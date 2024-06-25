namespace TvShowsAPI.Models
{
    /// <summary>
    /// DTO para el registro de usuarios.
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// Nombre de usuario para el registro.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Contraseña para el registro.
        /// </summary>
        public string Password { get; set; }
    }
}
