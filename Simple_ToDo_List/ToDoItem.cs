using System;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueAt { get; set; } // optional due date
    }
}