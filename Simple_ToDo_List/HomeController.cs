using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        // In-memory list for demo purposes
        private static List<ToDoItem> tasks = new List<ToDoItem>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Add(string task, DateTime? dueAt)
        {
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(new ToDoItem
                {
                    Id = nextId++,
                    Task = task,
                    DueAt = dueAt
                });
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Toggle(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
            }
            return RedirectToAction("Index");
        }
    }
}