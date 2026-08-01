namespace NurserySystem.Domain.Entities;

public class BusRoute : BaseEntity
{
    public int BusId { get; set; }
    public Bus Bus { get; set; } = null!;
    public int AreaId { get; set; }
    public Area Area { get; set; } = null!;
    public string RouteOrder { get; set; } = string.Empty; // Stop sequence
    public TimeSpan? PickupTime { get; set; }
    public TimeSpan? DropoffTime { get; set; }
}
