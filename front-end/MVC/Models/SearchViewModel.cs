using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class SearchViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Query is required.")]
        [StringLength(100, ErrorMessage = "Query cannot exceed 100 characters.")]
        public string? Query { get; set; } = "land registry search";

        public SearchViewModel(ApiSettings apiSettings) : base(apiSettings)
        {
        }
    }
}
