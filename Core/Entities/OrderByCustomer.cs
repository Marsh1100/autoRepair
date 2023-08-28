

namespace Core.Entities

public class OrderByCustomer : BaseEntity
{
    public string IdCustomerFK { get; set; }

    public Datetime dateOrder { get; set; }
    public string IdCarPlateFK { get; set; }
    public string DiagCustomer { get; set; }

    // Finalizar orden ?
}
