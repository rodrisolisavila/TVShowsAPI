﻿using System.ComponentModel.DataAnnotations;

namespace TvShowsAPI.Models
{
    /// <summary>
    /// Representa un programa de televisión (DTO).
    /// </summary>
    public class TvShowDto
    {
        /// <summary>
        /// Identificador único del programa de televisión.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del programa de televisión.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indica si el programa de televisión es favorito.
        /// </summary>
        public bool Favorite { get; set; }
    }
}