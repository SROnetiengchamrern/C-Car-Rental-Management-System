namespace CarRentalManagementSystem.ViewModels;

public class DashboardViewModel
{
    public int TotalCars { get; set; }
    public int AvailableCars { get; set; }
    public int RentedCars { get; set; }
    public int TotalCustomers { get; set; }
    public int ActiveContracts { get; set; }
    public int TotalBranches { get; set; }
    public int TotalEmployees { get; set; }
    public int PendingMaintenance { get; set; }
    public decimal TotalPayments { get; set; }
}
