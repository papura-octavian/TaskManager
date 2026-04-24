using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManager.Models;

namespace TaskManager.ViewComponents;

public class NotificationBadgeViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public NotificationBadgeViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null) return Content("");

        var threeDaysFromNow = DateTime.Now.AddDays(3);

        var count = await _context.Tasks.CountAsync(t =>
            t.UserId == userId &&
            t.IsCompleted == false &&
            t.DueDate != null &&
            t.DueDate <= threeDaysFromNow);

        return View(count);
    }
}