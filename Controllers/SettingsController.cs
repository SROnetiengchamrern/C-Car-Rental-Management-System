using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Manager}")]
public class SettingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SettingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? group)
    {
        var query = _context.Settings.AsQueryable();
        if (!string.IsNullOrWhiteSpace(group))
        {
            query = query.Where(s => s.GroupName == group);
            ViewBag.CurrentGroup = group;
        }

        ViewBag.Groups = await _context.Settings
            .Select(s => s.GroupName)
            .Distinct()
            .OrderBy(g => g)
            .ToListAsync();

        var settings = await query
            .OrderBy(s => s.GroupName)
            .ThenBy(s => s.SettingKey)
            .ToListAsync();

        return View(settings);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var setting = await _context.Settings.FirstOrDefaultAsync(m => m.SettingId == id);
        if (setting == null) return NotFound();

        return View(setting);
    }

    [Authorize(Roles = AppRoles.Admin)]
    public IActionResult Create()
    {
        return View(new Setting { IsActive = true, GroupName = "General", UpdatedAt = DateTime.Now });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Create(Setting setting)
    {
        if (await _context.Settings.AnyAsync(s => s.SettingKey == setting.SettingKey))
        {
            ModelState.AddModelError(nameof(setting.SettingKey), "Setting key already exists.");
        }

        if (ModelState.IsValid)
        {
            setting.UpdatedAt = DateTime.Now;
            _context.Add(setting);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Setting created.";
            return RedirectToAction(nameof(Index));
        }

        return View(setting);
    }

    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var setting = await _context.Settings.FindAsync(id);
        if (setting == null) return NotFound();

        return View(setting);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Edit(int id, Setting setting)
    {
        if (id != setting.SettingId) return NotFound();

        if (await _context.Settings.AnyAsync(s => s.SettingKey == setting.SettingKey && s.SettingId != id))
        {
            ModelState.AddModelError(nameof(setting.SettingKey), "Setting key already exists.");
        }

        if (ModelState.IsValid)
        {
            setting.UpdatedAt = DateTime.Now;
            _context.Update(setting);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Setting updated.";
            return RedirectToAction(nameof(Index));
        }

        return View(setting);
    }

    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var setting = await _context.Settings.FirstOrDefaultAsync(m => m.SettingId == id);
        if (setting == null) return NotFound();

        return View(setting);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var setting = await _context.Settings.FindAsync(id);
        if (setting != null)
        {
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Setting deleted.";
        }

        return RedirectToAction(nameof(Index));
    }
}
