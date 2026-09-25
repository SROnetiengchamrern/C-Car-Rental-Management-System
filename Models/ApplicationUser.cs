using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarRentalManagementSystem.Models;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(80)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
