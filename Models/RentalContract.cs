using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class RentalContract
{
    [Key]
    public int ContractId { get; set; }

    [Required]
    [Display(Name = "Customer")]
    public int CustomerId { get; set; }

    [Required]
    [Display(Name = "Employee")]
    public int EmployeeId { get; set; }

    [Required]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [Required, StringLength(40)]
    [Display(Name = "Contract Number")]
    public string ContractNumber { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Active";

    [Display(Name = "Total Amount")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Display(Name = "Discount")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999)]
    public decimal DiscountAmount { get; set; }

    [Display(Name = "Deposit Amount")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DepositAmount { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }

    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    public ICollection<RentalContractDetail> RentalContractDetails { get; set; } = new List<RentalContractDetail>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<CarReturn> CarReturns { get; set; } = new List<CarReturn>();
}
