using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models;
using System.Diagnostics;

namespace MovieTracker.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //Use the context file to build an instance of the database for use in the program.
        private MovieApplicationContext _context;

        /*
         When this home controller is created, it builds an instance of the db and brings it in
         The private class above allows us to use that db throughout the program
         */
        public HomeController(MovieApplicationContext temp) //We are going to create a constructor for the main program here...
        {
            _context = temp;
        }

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
            return View();
        }

        [HttpPost]
        public IActionResult NewMovieForm(Application response)
        {
            //When the user has posted their response, go out to the tracker table and add their info...
            _context.Applications.Add(response); //Add record (object) to the database
            _context.SaveChanges();

            return View("NewMovieForm", response);
        }
    }
}
