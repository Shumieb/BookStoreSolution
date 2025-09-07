using System.ComponentModel.DataAnnotations;

namespace BookStore.FrontEnd.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50, MinimumLength =5, ErrorMessage ="Please enter a name with 5 to 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter a description with 5 to 100 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Author is required.")]
        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        [Required(ErrorMessage = "The Category is required.")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "The Price is required.")]
        [Range(1, 1000, ErrorMessage ="Please enter a price between 1 and 1000")]

        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
