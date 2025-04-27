using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kolokwium.Models;

public class Car{
    public int Id { get; set;}
    public string Marka { get; set;}
    public string Model { get; set; }
    public DateTime RokProdukcji { get; set; }
    public int GarageId { get; set; }
    public virtual Garage Garage{ get; set; }
    public ICollection<Owner> Owners{ get; set; }
}

