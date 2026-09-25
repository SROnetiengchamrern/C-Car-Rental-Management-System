using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class Car
{
    [Key]
    public int CarId { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Required]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [Required, StringLength(50)]
    public string Make { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Model { get; set; } = string.Empty;

    [Range(1980, 2100)]
    public int Year { get; set; }

    [StringLength(40)]
    public string? Color { get; set; }

    [Required, StringLength(20)]
    [Display(Name = "License Plate")]
    public string LicensePlate { get; set; } = string.Empty;

    [StringLength(50)]
    public string? VIN { get; set; }

    [Display(Name = "Daily Rate")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DailyRate { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Available";

    public int Mileage { get; set; }

    [Range(2, 50)]
    public int Seats { get; set; } = 5;

    [StringLength(20)]
    public string Transmission { get; set; } = "Automatic";

    [StringLength(20)]
    [Display(Name = "Fuel Type")]
    public string FuelType { get; set; } = "Gasoline";

    [StringLength(300)]
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(CategoryId))]
    public CarCategory? Category { get; set; }

    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    public ICollection<RentalContractDetail> RentalContractDetails { get; set; } = new List<RentalContractDetail>();
    public ICollection<CarReturn> CarReturns { get; set; } = new List<CarReturn>();
    public ICollection<CarMaintenance> CarMaintenances { get; set; } = new List<CarMaintenance>();
    public ICollection<CarStatusHistory> CarStatusHistories { get; set; } = new List<CarStatusHistory>();
}
