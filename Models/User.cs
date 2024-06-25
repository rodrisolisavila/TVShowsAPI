namespace TvShowsAPI.Models
{
    /// <summary>
    /// Representa un usuario del sistema.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

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
