namespace NurserySystem.Domain.Entities;

public class Revenue : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime RevenueDate { get; set; }
    public string Category { get; set; } = string.Empty; // Store Sales, Activities, etc.
    public string? Notes { get; set; }
    public int? ReceivedByUserId { get; set; }
}
