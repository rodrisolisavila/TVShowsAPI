using System.ComponentModel.DataAnnotations;

namespace TvShowsAPI.Models
{
    /// <summary>
    /// Representa los datos necesarios para actualizar un programa de televisión.
    /// </summary>
    public class UpdateTvShowDto
    {
        /// <summary>
        /// Identificador único del programa de televisión.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del programa de televisión.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Indica si el programa de televisión es favorito.
        /// </summary>
        public bool Favorite { get; set; }
    }
}
