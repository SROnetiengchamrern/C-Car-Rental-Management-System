using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class CarStatusHistory
{
    [Key]
    public int HistoryId { get; set; }

    [Required]
    [Display(Name = "Car")]
    public int CarId { get; set; }

    [Required, StringLength(30)]
    [Display(Name = "Previous Status")]
    public string PreviousStatus { get; set; } = string.Empty;

    [Required, StringLength(30)]
    [Display(Name = "New Status")]
    public string NewStatus { get; set; } = string.Empty;

    [Display(Name = "Changed At")]
    public DateTime ChangedAt { get; set; } = DateTime.Now;

    [Display(Name = "Changed By")]
    public int? ChangedByEmployeeId { get; set; }

    [StringLength(200)]
    public string? Reason { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }

    [ForeignKey(nameof(ChangedByEmployeeId))]
    public Employee? ChangedByEmployee { get; set; }
}
