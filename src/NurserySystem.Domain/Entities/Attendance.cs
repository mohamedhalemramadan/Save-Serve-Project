namespace NurserySystem.Domain.Entities;

public class Attendance : BaseEntity
{
    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public TimeSpan? CheckInTime { get; set; }
    public TimeSpan? CheckOutTime { get; set; }
    public string? Notes { get; set; }
}
