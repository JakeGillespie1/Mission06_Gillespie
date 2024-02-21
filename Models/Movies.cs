using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTracker.Models
{
    public class Movies
    {
        int year = DateTime.Now.Year;

        [Key]
        [Required]
        public int MovieId { get; set; }

        /*Establish foreign key relationship with category*/
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

        [Required]
        public string Title { get; set; }
        [Required, Range(1888,2024)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
