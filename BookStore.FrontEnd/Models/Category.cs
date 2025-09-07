using System.ComponentModel.DataAnnotations;

namespace BookStore.FrontEnd.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a name with 5 to 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter a description with 5 to 100 characters.")]
        public required string Description { get; set; }


    }
}
