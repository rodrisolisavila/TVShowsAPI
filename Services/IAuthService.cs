using TvShowsAPI.Models;

namespace TvShowsAPI.Services
{
    /// <summary>
    /// Interfaz para el servicio de autenticación y autorización de usuarios.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Autentica a un usuario basado en su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="username">Nombre de usuario del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Token JWT si la autenticación es exitosa; de lo contrario, null.</returns>
        string Authenticate(string username, string password);

        /// <summary>
        /// Registra un nuevo usuario con el nombre de usuario y contraseña especificados.
        /// </summary>
        /// <param name="username">Nombre de usuario del nuevo usuario.</param>
        /// <param name="password">Contraseña del nuevo usuario.</param>
        /// <returns>El usuario registrado.</returns>
        User Register(string username, string password);
    }
}
