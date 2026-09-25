using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class CarCategory
{
    [Key]
    public int CategoryId { get; set; }

    [Required, StringLength(100)]
    [Display(Name = "Category Name")]
    public string CategoryName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Display(Name = "Base Daily Rate")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal BaseDailyRate { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
