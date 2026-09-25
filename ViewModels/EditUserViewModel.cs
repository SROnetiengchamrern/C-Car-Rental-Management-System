using System.ComponentModel.DataAnnotations;
using CarRentalManagementSystem.Models;

namespace CarRentalManagementSystem.ViewModels;

public class EditUserViewModel
{
    [Required]
    public string Id { get; set; } = string.Empty;

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
    public string Role { get; set; } = AppRoles.Staff;

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least {2} characters.")]
    [Display(Name = "New Password")]
    public string? NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm New Password")]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match.")]
    public string? ConfirmNewPassword { get; set; }
}
