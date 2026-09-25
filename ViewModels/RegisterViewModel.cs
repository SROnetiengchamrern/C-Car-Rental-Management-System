using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystem.ViewModels;

public class RegisterViewModel
{
    [Required, StringLength(80)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [Display(Name = "Phone")]
    public string? PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Role")]
    public string Role { get; set; } = "Staff";

    [Required, DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least {2} characters.")]
    public string Password { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
