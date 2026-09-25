using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class BookingRequest
{
    [Key]
    public int BookingRequestId { get; set; }

    [Required, StringLength(40)]
    public string Reference { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Car")]
    public int CarId { get; set; }

    [Required, StringLength(150)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [StringLength(1000)]
    public string? Notes { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "New";

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(CarId))]
    public Car? Car { get; set; }
}
