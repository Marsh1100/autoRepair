
namespace Core.Entities;
public class Car: BaseEntity
{
    public string CarPlate { get; set; }
    public int IdCustomerFK { get; set; }
    public Customer Customer { get; set; }
    public string Model { get; set; }
    //public string Branch { get; set; }
    //public string Color { get; set; }
    //public int Km { get; set; }
}
