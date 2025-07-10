using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using StudentMarksWeb.Models;
using System.Collections.Generic;
using System.IO;

namespace StudentMarksWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/marks.xlsx");
            var students = ReadStudentsFromExcel(filePath);
            return View(students);
        }

        private List<Student> ReadStudentsFromExcel(string path)
        {
            var students = new List<Student>();

            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1); // first sheet
                var rows = worksheet.RangeUsed().RowsUsed();

                foreach (var row in rows.Skip(1)) // skip header
                {
                    var name = row.Cell(1).GetString();
                    var marks = new List<int>();

                    for (int i = 2; i <= row.CellCount(); i++)
                    {
                        if (int.TryParse(row.Cell(i).GetString(), out int mark))
                            marks.Add(mark);
                    }

                    students.Add(new Student { Name = name, Marks = marks });
                }
            }

            return students;
        }
    }
}
