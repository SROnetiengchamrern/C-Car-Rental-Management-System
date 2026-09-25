using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalManagementSystem.Models;

public class ReturnInspection
{
    [Key]
    public int InspectionId { get; set; }

    [Required]
    [Display(Name = "Return")]
    public int ReturnId { get; set; }

    [Required]
    [Display(Name = "Inspected By")]
    public int InspectedByEmployeeId { get; set; }

    [Display(Name = "Inspection Date")]
    [DataType(DataType.DateTime)]
    public DateTime InspectionDate { get; set; } = DateTime.Now;

    [Required, StringLength(50)]
    [Display(Name = "Exterior Condition")]
    public string ExteriorCondition { get; set; } = "Good";

    [Required, StringLength(50)]
    [Display(Name = "Interior Condition")]
    public string InteriorCondition { get; set; } = "Good";

    [Display(Name = "Has Damage")]
    public bool HasDamage { get; set; }

    [StringLength(500)]
    [Display(Name = "Damage Description")]
    public string? DamageDescription { get; set; }

    [Display(Name = "Estimated Repair Cost")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal EstimatedRepairCost { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [ForeignKey(nameof(ReturnId))]
    public CarReturn? CarReturn { get; set; }

    [ForeignKey(nameof(InspectedByEmployeeId))]
    public Employee? InspectedByEmployee { get; set; }
}
