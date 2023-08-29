

namespace Core.Entities;

public class Customer: BaseEntity
{
    public int IdPersonFK { get; set; }
    public Person Person { get; set; }
    public string Email { get; set; }
    //public DateTime RegistrationDate { get; set; }

    public ICollection<Car> Cars { get; set; }
}
