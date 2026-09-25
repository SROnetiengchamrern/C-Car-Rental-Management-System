using CarRentalManagementSystem.Models;

namespace CarRentalManagementSystem.ViewModels;

public class InvoiceListItemViewModel
{
    public int ContractId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalDue { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string CarsSummary { get; set; } = string.Empty;
}

public class InvoiceDetailViewModel
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public RentalContract Contract { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalDue { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public IReadOnlyList<RentalContractDetail> Lines { get; set; } = Array.Empty<RentalContractDetail>();
    public IReadOnlyList<Payment> Payments { get; set; } = Array.Empty<Payment>();
}
