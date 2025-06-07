using System.ComponentModel.DataAnnotations; // Dla atrybutów walidacji

 namespace SchoolRegister.ViewModels.VM
 {
     public class AddOrUpdateTeacherVm
     {
         public int Id { get; set; } // Dla aktualizacji

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; } 

         [Required]
         [StringLength(50)]
         public string? LastName { get; set; }

         [Required]
         [EmailAddress]
         public string? Email { get; set; }

         [Required]
         [StringLength(50, MinimumLength = 3)]
         public string? UserName { get; set; }

         [StringLength(50)]
         public string? Title { get; set; }

         // Hasło będzie ustawiane osobno przez UserManager, więc nie ma go tutaj
         // chyba że formularz ma też tworzyć konto i ustawiać hasło
     }
}
