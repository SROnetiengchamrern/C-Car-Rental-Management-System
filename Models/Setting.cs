using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystem.Models;

public class Setting
{
    [Key]
    public int SettingId { get; set; }

    [Required, StringLength(100)]
    [Display(Name = "Setting Key")]
    public string SettingKey { get; set; } = string.Empty;

    [Required, StringLength(500)]
    [Display(Name = "Setting Value")]
    public string SettingValue { get; set; } = string.Empty;

    [StringLength(80)]
    [Display(Name = "Group")]
    public string GroupName { get; set; } = "General";

    [StringLength(300)]
    public string? Description { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "Updated At")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
