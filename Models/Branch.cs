using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystem.Models;

public class Branch
{
    [Key]
    public int BranchId { get; set; }

    [Required, StringLength(150)]
    [Display(Name = "Branch Name")]
    public string BranchName { get; set; } = string.Empty;

    [Required, StringLength(250)]
    public string Address { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(30)]
    public string? Phone { get; set; }

    [EmailAddress, StringLength(150)]
    public string? Email { get; set; }

    [Display(Name = "Manager Name")]
    [StringLength(150)]
    public string? ManagerName { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    public ICollection<Car> Cars { get; set; } = new List<Car>();
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
}
