using System.ComponentModel.DataAnnotations;

namespace BookStore.FrontEnd.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Please enter a name with 5 to 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Author is required.")]
        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        [Required(ErrorMessage = "The Price is required.")]
        [Range(1, 1000, ErrorMessage ="Please enter a price between 1 and 1000")]
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
