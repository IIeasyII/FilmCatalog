using System;

namespace FilmsCatalog.Models
{
    /// <summary>
    /// Модель фильма
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Идентификатор фильма
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание фильма
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Год выпуска фильма
        /// </summary>
        public DateTime ReleaseYear { get; set; }

        /// <summary>
        /// Режиссёр фильма
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// Пользователь опубликовавший фильм
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Постер фильма
        /// </summary>
        public byte[] Poster { get; set; }

        public Film()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
