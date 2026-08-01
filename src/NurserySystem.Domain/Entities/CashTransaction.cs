namespace NurserySystem.Domain.Entities;

public class CashTransaction : BaseEntity
{
    public int CashRegisterId { get; set; }
    public CashRegister CashRegister { get; set; } = null!;
    public string TransactionType { get; set; } = string.Empty; // Deposit, Withdrawal
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string? Notes { get; set; }
    public int? UserId { get; set; }
}
