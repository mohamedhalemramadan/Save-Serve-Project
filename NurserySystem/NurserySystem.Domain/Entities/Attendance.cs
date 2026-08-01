namespace NurserySystem.Domain.Entities;

public class Attendance : BaseEntity
{
    public int ChildId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    public bool IsPresent { get; set; }
    public TimeSpan? CheckInTime { get; set; }
    public TimeSpan? CheckOutTime { get; set; }
    public string? Notes { get; set; }
    
    // Navigation Properties
    public Child? Child { get; set; }
}
