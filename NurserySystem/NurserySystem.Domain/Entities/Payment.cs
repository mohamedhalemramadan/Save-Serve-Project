namespace NurserySystem.Domain.Entities;

public class Payment : BaseEntity
{
    public int SubscriptionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionReference { get; set; } // رقم المعاملة
    public string? Notes { get; set; }
    public string? ReceiptNumber { get; set; } // رقم الإيصال
    public int? ReceivedByUserId { get; set; } // الموظف الذي استلم الدفع
    
    // Navigation Properties
    public Subscription? Subscription { get; set; }
}
