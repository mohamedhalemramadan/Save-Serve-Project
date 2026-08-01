using NurserySystem.Domain.Enums;

namespace NurserySystem.Domain.Entities;

public class Payment : BaseEntity
{
    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;
    public int? SubscriptionId { get; set; }
    public Subscription? Subscription { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? ReceiptNumber { get; set; }
    public string? Notes { get; set; }
    public int? PaidByUserId { get; set; } // User who collected the payment
}
