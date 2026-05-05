using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.ViewModels;

public class OrderEditStatusViewModel
{
    public int OrderId { get; set; }

    [Display(Name = "Aktualny status")]
    public string CurrentStatusName { get; set; } = string.Empty;

    [Display(Name = "Nowy status")]
    public int SelectedStatusId { get; set; }

    public List<SelectListItem> AvailableStatuses { get; set; } = new();
}
