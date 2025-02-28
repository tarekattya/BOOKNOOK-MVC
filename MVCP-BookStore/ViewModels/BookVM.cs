using System.ComponentModel.DataAnnotations;

namespace MVCP_BookStore.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string Language { get; set; }

        [Required,
        MaxLength(13)]
        public string ISBN { get; set; }

        [Required,
        DataType(DataType.Date),
        Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }

        [Required,
        DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required]
        public string Author { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
        public string? CurrentImageUrl { get; set; }
    }
}
