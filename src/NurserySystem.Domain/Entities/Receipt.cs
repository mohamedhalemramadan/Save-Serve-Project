namespace NurserySystem.Domain.Entities;

public class Receipt : BaseEntity
{
    public string ReceiptNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public int? IssuedByUserId { get; set; }
}
