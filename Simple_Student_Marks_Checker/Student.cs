using System.Collections.Generic;

namespace StudentMarksWeb.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<int> Marks { get; set; } = new();

        public double GetAverage()
        {
            if (Marks.Count == 0) return 0;
            double total = 0;
            foreach (var mark in Marks)
                total += mark;
            return total / Marks.Count;
        }
    }
}
