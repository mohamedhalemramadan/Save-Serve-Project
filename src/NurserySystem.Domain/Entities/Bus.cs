namespace NurserySystem.Domain.Entities;

public class Bus : BaseEntity
{
    public string PlateNumber { get; set; } = string.Empty;
    public string DriverName { get; set; } = string.Empty;
    public string DriverPhone { get; set; } = string.Empty;
    public string? SupervisorName { get; set; }
    public int Capacity { get; set; }
    public int CurrentCount { get; set; }
    public ICollection<Child> Children { get; set; } = new List<Child>();
    public ICollection<BusRoute> Routes { get; set; } = new List<BusRoute>();
}
