using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab3_gr1.ViewModels
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public List<int> SelectedTagIds { get; set; } = new List<int>();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Tags { get; set; } = new List<SelectListItem>();
    }
}