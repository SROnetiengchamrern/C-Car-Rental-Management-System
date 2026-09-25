using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class CarReturn
{
    [Key]
    public int ReturnId { get; set; }

    [Required]
    [Display(Name = "Contract")]
    public int ContractId { get; set; }

    [Required]
    [Display(Name = "Car")]
    public int CarId { get; set; }

    [Required]
    [Display(Name = "Processed By")]
    public int EmployeeId { get; set; }

    [Display(Name = "Return Date")]
    [DataType(DataType.DateTime)]
    public DateTime ReturnDate { get; set; } = DateTime.Now;

    [Display(Name = "Odometer Reading")]
    public int OdometerReading { get; set; }

    [StringLength(30)]
    [Display(Name = "Fuel Level")]
    public string FuelLevel { get; set; } = "Full";

    [Display(Name = "Late Fee")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal LateFee { get; set; }

    [Display(Name = "Damage Fee")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DamageFee { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Completed";

    [ForeignKey(nameof(ContractId))]
    public RentalContract? RentalContract { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }

    public ICollection<ReturnInspection> ReturnInspections { get; set; } = new List<ReturnInspection>();
}
