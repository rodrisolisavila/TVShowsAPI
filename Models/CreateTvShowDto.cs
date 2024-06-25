using System.ComponentModel.DataAnnotations;

namespace TvShowsAPI.Models
{
    /// <summary>
    /// DTO para la creación de un programa de televisión.
    /// </summary>
    public class CreateTvShowDto
    {
        /// <summary>
        /// Nombre del programa de televisión.
        /// </summary>
        [Required(ErrorMessage = "El nombre del programa de televisión es requerido.")]
        public string Name { get; set; }

        /// <summary>
        /// Indica si el programa de televisión es favorito.
        /// </summary>
        public bool Favorite { get; set; }
    }
}
