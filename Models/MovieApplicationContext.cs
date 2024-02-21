using Microsoft.EntityFrameworkCore;

namespace MovieTracker.Models
{
    public class MovieApplicationContext : DbContext
    {
        //Constructor...creates a class called DbContextOptions of type MovieApplicationContext
        //the colon signifies inheritence happening. We are giving the constructor all the options it needs and the base options
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options)
        {

        }

        //We are going to create a databse set of type application that we will refer to as "Applications"
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
