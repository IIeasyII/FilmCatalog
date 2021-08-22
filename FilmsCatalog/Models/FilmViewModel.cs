using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models
{
    /// <summary>
    /// Модель для страницы фильма
    /// </summary>
    public class FilmViewModel
    {
        /// <summary>
        /// Идентификатор фильма
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание фильма
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Год выпуска фильма
        /// </summary>
        [Display(Name = "Год выпуска")]
        public DateTime ReleaseYear { get; set; }

        /// <summary>
        /// Режиссёр фильма
        /// </summary>
        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        /// <summary>
        /// Постер фильма
        /// </summary>
        public IFormFile Poster { get; set; }

        /// <summary>
        /// Постер фильма
        /// </summary>
        public byte[] PosterImage { get; set; }

        /// <summary>
        /// Автор публикации
        /// </summary>
        public User Author { get; set; }
    }
}
