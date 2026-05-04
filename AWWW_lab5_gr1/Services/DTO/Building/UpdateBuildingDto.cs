namespace Services.DTO.Building
{
    public class UpdateBuildingDto
    {
        public int Id {get; set; }
        public string Name {get; set; } = null;
        public string Address {get; set;} = null;
        public string? Description {get; set; }
    }
}