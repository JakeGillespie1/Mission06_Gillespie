using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace MovieTracker.Controllers
{
    public class HomeController(MovieApplicationContext temp) : Controller
    {
        //Use the context file to build an instance of the database for use in the program.
        private MovieApplicationContext _context = temp;

        //Index Page View
        public IActionResult Index()
        {
            return View();
        }

        //About View
        public IActionResult AbtJoel()
        {
            return View();
        }

        //Movie Form View
        [HttpGet]
        public IActionResult NewMovieForm()
        {
            //We need to bring in the different cartegories
            ViewBag.Categories = _context.Categories.ToList();

            return View(new Movies());
        }

        [HttpPost]
        public IActionResult NewMovieForm(Movies response)
        {
            if (ModelState.IsValid)
            {             
                //When the user has posted their response, go out to the movie list table and add the info...
                _context.Movies.Add(response); //Add record (object) to the database
                _context.SaveChanges();

                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return RedirectToAction("MovieList");
            }
            else
            {
                //We will need the category names here too, so we can load up the movie list on the form :)
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View("NewMovieForm", response);
            }
        }

        [HttpGet]
        public IActionResult MovieList() 
        {
            /*Bring the list of movie objects in and put them in a table*/
            List<Movies> applications = _context.Movies
                .OrderBy(x => x.Year).ToList();

            //Return the view while passing in the applications
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Grab correct movie
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            //Grab the viewbag, so we can load up the names in the New Movie Form
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View("NewMovieForm", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            //This will take the user back to the movie list
            return RedirectToAction("MovieList");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
