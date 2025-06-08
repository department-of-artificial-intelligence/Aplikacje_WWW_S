namespace Kolokwium.Model.DataModels;

public class Wydawnictwo
{
    public int Id { get; set; }
    public string Nazwa { get; set; }

    public virtual ICollection<Ksiazka> Ksiazki { get; set; }
}