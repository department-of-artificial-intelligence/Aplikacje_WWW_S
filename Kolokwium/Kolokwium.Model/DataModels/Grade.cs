namespace Kolokwium.Model.DataModels; 

public class Grade {

    public int Id {get; set;}
    public double Value {get; set;}
    public int StudentId {get; set;}
    public virtual Student Student {get; set;} = null!;
}