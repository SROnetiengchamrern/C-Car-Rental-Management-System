using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required, StringLength(80)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string Phone { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [Required, StringLength(50)]
    [Display(Name = "License Number")]
    public string LicenseNumber { get; set; } = string.Empty;

    [Display(Name = "License Expiry")]
    [DataType(DataType.Date)]
    public DateTime? LicenseExpiry { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [Display(Name = "Full Name")]
    public string FullName => $"{FirstName} {LastName}";

    public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
}
