namespace Kolokwium.Models;

public class Owner{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Surname { get; set;}
    public int Telefon { get; set;}
    public ICollection<Car> Cars{ get; set;}
    
    public virtual Garage Garage{ get; set;}
}