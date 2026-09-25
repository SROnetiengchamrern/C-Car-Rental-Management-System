using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class CarMaintenance
{
    [Key]
    public int MaintenanceId { get; set; }

    [Required]
    [Display(Name = "Car")]
    public int CarId { get; set; }

    [Display(Name = "Handled By")]
    public int? EmployeeId { get; set; }

    [Required, StringLength(80)]
    [Display(Name = "Maintenance Type")]
    public string MaintenanceType { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Cost { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Scheduled";

    [StringLength(150)]
    [Display(Name = "Service Provider")]
    public string? ServiceProvider { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }
}
