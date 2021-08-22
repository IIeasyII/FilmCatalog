using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    /// <summary>
    /// Общая модель для основной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Список всех фильмов
        /// </summary>
        public IEnumerable<Film> Films { get; set; }

        /// <summary>
        /// Информация о странице
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}
