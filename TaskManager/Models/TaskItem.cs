using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace TaskManager.Models;

public class TaskItem
{
    public int Id { get; set; }
    
    [Required(ErrorMessage= "Titlul este obligatoriu")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public DateTime CeatedAt { get; set; } = DateTime.Now;
    
    public DateTime? DueDate { get; set; }

    [Required] 
    public string Priority { get; set; } = "Normal"; // Low, Normal, High
}