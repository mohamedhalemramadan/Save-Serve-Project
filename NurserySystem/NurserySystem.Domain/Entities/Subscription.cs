namespace NurserySystem.Domain.Entities;

public class Subscription : BaseEntity
{
    public int ChildId { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? Notes { get; set; }
    
    // Navigation Properties
    public Child? Child { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
