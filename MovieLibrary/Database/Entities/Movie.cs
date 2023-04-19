using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Database.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Director { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
}
