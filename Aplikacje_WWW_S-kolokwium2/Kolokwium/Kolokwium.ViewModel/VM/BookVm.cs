namespace Kolokwium.ViewModel.VM
{
    public class BookVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AutorNameSurname { get; set; }
    }
}
// This class is a ViewModel for the Book entity, which is used to transfer data between the view and the controller.
// It contains properties that represent the data needed for displaying a book in the view.