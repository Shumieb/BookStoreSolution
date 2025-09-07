using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Backend.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a name with 5 to 50 characters.")]
        public required string Name { get; set; }

        [ValidateNever]
        public DateOnly Added { get; set; }
    }
}
