namespace NurserySystem.Domain.Entities;

public class Expense : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Category { get; set; } = string.Empty; // Salary, Rent, Maintenance, etc.
    public string? Notes { get; set; }
    public int? PaidByUserId { get; set; }
}
