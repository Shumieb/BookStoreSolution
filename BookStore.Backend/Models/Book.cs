using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Backend.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a name with 5 to 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter a description with 5 to 100 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Author is required.")]
        public int? AuthorId { get; set; }

        [ValidateNever]
        public Author? Author { get; set; }

        [Required(ErrorMessage = "The Category is required.")]
        public int? CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "The Price is required.")]
        [Range(1, 1000, ErrorMessage = "Please enter a price between 1 and 1000")]
        public decimal Price { get; set; }

        [ValidateNever]
        public DateOnly ReleaseDate { get; set; }
    }
}
