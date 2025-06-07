using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class AddOrUpdateGroupVm
    {
        public int Id { get; set; }  

        [Required(ErrorMessage = "Nazwa grupy jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa grupy nie może być dłuższa niż 100 znaków.")]
        public string Name { get; set; } = null!;
    }
}