using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.Controllers;

[Authorize]
public class TasksController : Controller
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Tasks
    public IActionResult Index(string? priority = null, string? status = null)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var tasks = _context.Tasks.Where(t => t.UserId == userId);

        if (priority != null)
        {
            tasks = tasks.Where(t => t.Priority == priority);
        }

        if (status == "completed")
        {
            tasks = tasks.Where(t => t.IsCompleted == true);
        }
        
        if (status == "inprogress")
        {
            tasks = tasks.Where(t => t.IsCompleted == false);
        }
        
        return View(tasks.ToList());
    }

    // GET: /Tasks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Tasks/Create
    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            task.UserId = userId;
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(task);
    }
    
    // GET: /Tasks/Edit
    public IActionResult Edit(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();
        return View(task);
    }

    // POST: /Tasks/Edit 
    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            task.UserId = userId;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(task);
    }
    
    // GET: /Tasks/Complete
    public IActionResult Complete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();
        task.IsCompleted = true;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: /Tasks/Delete/5
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null) return NotFound();
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}