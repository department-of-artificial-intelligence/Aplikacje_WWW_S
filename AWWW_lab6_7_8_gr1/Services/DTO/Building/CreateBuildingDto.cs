namespace Services.DTO.Building
{
    public class CreateBuildingDto
    {
        public string Name {get; set;} = null;
        public string Address {get; set;} = null;

        public string? Description {get; set;}
    }
}