using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class RentalContractDetail
{
    [Key]
    public int DetailId { get; set; }

    [Required]
    [Display(Name = "Contract")]
    public int ContractId { get; set; }

    [Required]
    [Display(Name = "Car")]
    public int CarId { get; set; }

    [Display(Name = "Daily Rate")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DailyRate { get; set; }

    [Range(1, 3650)]
    public int Days { get; set; }

    [Display(Name = "Sub Total")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal SubTotal { get; set; }

    [StringLength(300)]
    public string? Notes { get; set; }

    [ForeignKey(nameof(ContractId))]
    public RentalContract? RentalContract { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }
}
