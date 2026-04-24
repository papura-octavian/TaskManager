using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers;

public class TasksController : Controller
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Tasks
    public IActionResult Index()
    {
        var tasks = _context.Tasks.ToList();
        return View(tasks);
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