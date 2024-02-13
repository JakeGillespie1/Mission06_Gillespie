using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Application
    {
        //All of these pieces of info will be stored in memory one by one when the user hits the submit form button
        //Primary Key (the first getter and setter)
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        //If we only had the get in the curly braces, that is a read-only variable
        //If we only had the set in the curly braces, that is a set-only variable
        //If we only include these get; and set; in the curly braces, vsCode auto-sets-up the getters and setters
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
