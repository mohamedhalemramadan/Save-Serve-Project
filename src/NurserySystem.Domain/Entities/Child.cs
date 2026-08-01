using NurserySystem.Domain.Enums;

namespace NurserySystem.Domain.Entities;

public class Child : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string? PhotoPath { get; set; }
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; } = null!;
    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; } = null!;
    public bool UsesTransportation { get; set; }
    public int? BusId { get; set; }
    public Bus? Bus { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
