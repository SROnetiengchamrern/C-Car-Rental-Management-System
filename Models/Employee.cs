using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [Required, StringLength(80)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [StringLength(30)]
    public string? Phone { get; set; }

    [Required, StringLength(80)]
    public string Position { get; set; } = "Staff";

    [Display(Name = "Hire Date")]
    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; } = DateTime.Today;

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Salary { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    [NotMapped]
    [Display(Name = "Full Name")]
    public string FullName => $"{FirstName} {LastName}";

    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
    public ICollection<Payment> PaymentsReceived { get; set; } = new List<Payment>();
    public ICollection<CarReturn> CarReturns { get; set; } = new List<CarReturn>();
    public ICollection<ReturnInspection> ReturnInspections { get; set; } = new List<ReturnInspection>();
    public ICollection<CarMaintenance> CarMaintenances { get; set; } = new List<CarMaintenance>();
    public ICollection<CarStatusHistory> CarStatusHistories { get; set; } = new List<CarStatusHistory>();
}
