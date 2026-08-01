namespace NurserySystem.Domain.Entities;

public class CashRegister : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public decimal OpeningBalance { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime LastReconciliationDate { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<CashTransaction> Transactions { get; set; } = new List<CashTransaction>();
}
