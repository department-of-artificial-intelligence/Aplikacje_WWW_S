namespace SchoolRegister.ViewModels.VM
{
    public class TeachersGroupsVm
    {
        public int TeacherId { get; set; }
        public IEnumerable<GroupVm> Groups { get; set; } = null!;
    }
}