using NurserySystem.Domain.Enums;

namespace NurserySystem.Domain.Entities;

public class Subscription : BaseEntity
{
    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
