using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SanookMovie.Models;

namespace SanookMovie.Controllers
{
    public class MovieController : Controller
    {
        private IList<Movie> _movies = new List<Movie>();

        public MovieController()
        {
            // _movies.Add("Titanic");
            // _movies.Add("Avengers");
            // _movies.Add("Alita"); 
            //_movies = new List<Movie>();
        }

        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movies.Add(movie);

            return View(nameof(Index), _movies);
            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
            
        }

        public IActionResult Edit(int id)
        {
           var movie = _movies.FirstOrDefault(x => x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        public IActionResult Delete(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                return View(movie);
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if(movie != null)
            {
                _movies.Remove(movie);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
