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
    public int NewBookingRequests { get; set; }
    public int TotalBookingRequests { get; set; }
    public decimal TotalPayments { get; set; }
    public int CarsInMaintenance { get; set; }
    public int ReturnsDueSoon { get; set; }
    public List<DashboardBookingItem> RecentBookings { get; set; } = new();
    public List<DashboardReturnDueItem> UpcomingReturns { get; set; } = new();
}

public class DashboardBookingItem
{
    public int BookingRequestId { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string CarName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class DashboardReturnDueItem
{
    public int ContractId { get; set; }
    public string ContractNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public DateTime EndDate { get; set; }
}
