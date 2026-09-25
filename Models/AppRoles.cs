namespace CarRentalManagementSystem.Models;

public static class AppRoles
{
    public const string Admin = "Admin";
    public const string Manager = "Manager";
    public const string Staff = "Staff";

    public static readonly string[] All = [Admin, Manager, Staff];
}
