namespace Kolokwium.Models;

public class Garage{
    public int Id { get; set;}
    public string Nazwa { get; set;}
    public string Lokalizacja { get; set;}
    public int Slots { get; set;}
    public ICollection<Car> Cars { get; set;}
    public int OwnerId { get; set;}
    public virtual Owner Owner{ get; set;}
}