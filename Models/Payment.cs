using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [Required]
    [Display(Name = "Contract")]
    public int ContractId { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Display(Name = "Payment Date")]
    [DataType(DataType.DateTime)]
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Required, StringLength(40)]
    [Display(Name = "Payment Method")]
    public string PaymentMethod { get; set; } = "Cash";

    [StringLength(100)]
    [Display(Name = "Transaction Reference")]
    public string? TransactionReference { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Completed";

    [StringLength(300)]
    public string? Notes { get; set; }

    [Display(Name = "Received By")]
    public int? ReceivedByEmployeeId { get; set; }

    [ForeignKey(nameof(ContractId))]
    public RentalContract? RentalContract { get; set; }

    [ForeignKey(nameof(ReceivedByEmployeeId))]
    public Employee? ReceivedByEmployee { get; set; }
}
