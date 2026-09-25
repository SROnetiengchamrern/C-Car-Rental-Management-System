using CarRentalManagementSystem.Models;
using CarRentalManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalManagementSystem.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is null || !user.IsActive)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName!,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Account is locked. Try again later.");
            return View(model);
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password.");
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (User.Identity?.IsAuthenticated == true && !User.IsInRole(AppRoles.Admin))
        {
            return RedirectToAction("Index", "Home");
        }

        PopulateRoles();
        return View(new RegisterViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        PopulateRoles();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Only Admin can assign Admin/Manager; public register defaults to Staff
        var requestedRole = model.Role;
        if (User.Identity?.IsAuthenticated != true || !User.IsInRole(AppRoles.Admin))
        {
            requestedRole = AppRoles.Staff;
        }

        if (!AppRoles.All.Contains(requestedRole))
        {
            ModelState.AddModelError(nameof(model.Role), "Invalid role.");
            return View(model);
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        await _userManager.AddToRoleAsync(user, requestedRole);

        if (User.Identity?.IsAuthenticated == true && User.IsInRole(AppRoles.Admin))
        {
            TempData["Success"] = $"User {user.Email} created with role {requestedRole}.";
            return RedirectToAction(nameof(Users));
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }

    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Users()
    {
        var users = _userManager.Users.OrderByDescending(u => u.CreatedAt).ToList();
        var rows = new List<UserListItemViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            rows.Add(new UserListItemViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                Role = roles.FirstOrDefault() ?? "—",
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            });
        }

        return View(rows);
    }

    [HttpPost]
    [Authorize(Roles = AppRoles.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleActive(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        if (IsCurrentUser(user))
        {
            TempData["Error"] = "You cannot deactivate your own account.";
            return RedirectToAction(nameof(Users));
        }

        user.IsActive = !user.IsActive;
        await _userManager.UpdateAsync(user);
        TempData["Success"] = $"User {user.Email} is now {(user.IsActive ? "active" : "inactive")}.";
        return RedirectToAction(nameof(Users));
    }

    [HttpGet]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);
        PopulateRoles();

        return View(new EditUserViewModel
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber,
            Role = roles.FirstOrDefault() ?? AppRoles.Staff,
            IsActive = user.IsActive
        });
    }

    [HttpPost]
    [Authorize(Roles = AppRoles.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserViewModel model)
    {
        PopulateRoles();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!AppRoles.All.Contains(model.Role))
        {
            ModelState.AddModelError(nameof(model.Role), "Invalid role.");
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.Id);
        if (user is null)
        {
            return NotFound();
        }

        var emailOwner = await _userManager.FindByEmailAsync(model.Email);
        if (emailOwner is not null && emailOwner.Id != user.Id)
        {
            ModelState.AddModelError(nameof(model.Email), "Email is already used by another user.");
            return View(model);
        }

        if (IsCurrentUser(user) && !model.IsActive)
        {
            ModelState.AddModelError(nameof(model.IsActive), "You cannot deactivate your own account.");
            return View(model);
        }

        user.FullName = model.FullName;
        user.Email = model.Email;
        user.UserName = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        user.IsActive = model.IsActive;

        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        var currentRoles = await _userManager.GetRolesAsync(user);
        if (!currentRoles.Contains(model.Role) || currentRoles.Count != 1)
        {
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }

            await _userManager.AddToRoleAsync(user, model.Role);
        }

        if (!string.IsNullOrWhiteSpace(model.NewPassword))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
            if (!passwordResult.Succeeded)
            {
                foreach (var error in passwordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }

        TempData["Success"] = $"User {user.Email} updated successfully.";
        return RedirectToAction(nameof(Users));
    }

    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    private bool IsCurrentUser(ApplicationUser user)
    {
        return string.Equals(user.Email, User.Identity?.Name, StringComparison.OrdinalIgnoreCase)
            || string.Equals(user.UserName, User.Identity?.Name, StringComparison.OrdinalIgnoreCase);
    }

    private void PopulateRoles()
    {
        var roles = AppRoles.All.AsEnumerable();
        if (User.Identity?.IsAuthenticated != true || !User.IsInRole(AppRoles.Admin))
        {
            roles = [AppRoles.Staff];
        }

        ViewBag.RoleList = new SelectList(roles);
    }
}
