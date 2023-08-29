

namespace Core.Entities;

public class Employee : BaseEntity
{
    public int IdPersonFK { get; set; }
    public Person Person { get; set; }
    public string Specialty1 { get; set; }
    //public string Specialty2 { get; set; }
    //public string Specialty3 { get; set; }

}
