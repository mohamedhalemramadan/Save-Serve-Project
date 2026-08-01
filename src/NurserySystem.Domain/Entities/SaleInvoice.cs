namespace NurserySystem.Domain.Entities;

public class SaleInvoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int InventoryItemId { get; set; }
    public InventoryItem InventoryItem { get; set; } = null!;
    public int Quantity { get; set; }
    public int? ChildId { get; set; }
    public Child? Child { get; set; }
    public string? Notes { get; set; }
}
