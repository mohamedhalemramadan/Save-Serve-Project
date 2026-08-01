namespace NurserySystem.Domain.Entities;

public class Area : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public decimal TransportationFee { get; set; }
    public ICollection<BusRoute> BusRoutes { get; set; } = new List<BusRoute>();
}
