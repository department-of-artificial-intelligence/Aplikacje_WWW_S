using System.Runtime.CompilerServices;

namespace Kolokwium.Model.DataModels; 

public class Student: User {
    
    public virtual IEnumerable<Grade>? Grades {get; set;}
}