using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class FilmController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;

        public FilmController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Films()
        {
            //var films = await _db.Films.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(FilmViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var author = await _userManager.GetUserAsync(User);

            var film = new Film()
            {
                Name = model.Name,
                Description = model.Description,
                Author = author,
                Director = model.Director,
                ReleaseYear = model.ReleaseYear,
                Poster = ConvertPoster(model.Poster)
            };

            _db.Films.Add(film);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Редактировать фильм
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var model = _db.Films.Where(f => f.Id == Id).FirstOrDefault();

            return View(model);
        }

        /// <summary>
        /// Редактировать фильм
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(FilmViewModel model)
        {
            var film = _db.Films.Where(f => f.Id == model.Id).FirstOrDefault();

            //_db.Entry(film).State = EntityState.Modified; - Так хорошо, но костыли пока

            film.Name = model.Name;
            film.Description = model.Description;
            film.ReleaseYear = model.ReleaseYear;
            film.Director = model.Director;

            if (model.Poster != null)
            {
                film.Poster = ConvertPoster(model.Poster);
            }

            _db.SaveChanges();

            return RedirectToAction("Details", "Film", new { Id = film.Id });
        }

        /// <summary>
        /// Информация о фильме
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(string Id)
        {
            var film = _db.Films.Where(f => f.Id == Id).Include(a => a.Author).FirstOrDefault();

            var model = new FilmViewModel()
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Director = film.Director,
                ReleaseYear = film.ReleaseYear,
                PosterImage = film.Poster,
                Author = film.Author
            };

            return View(model);
        }

        /// <summary>
        /// Конвертирование IFormFile -> byte[]
        /// P.S. Возможно тоже не лучший вариант
        /// </summary>
        /// <param name="file">View file data</param>
        /// <returns></returns>
        private byte[] ConvertPoster(IFormFile file)
        {
            if (file == null)
            {
                return new byte[0];
            }

            using var fileStream = file.OpenReadStream();
            var length = file.Length;
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            return bytes;
        }
    }
}
