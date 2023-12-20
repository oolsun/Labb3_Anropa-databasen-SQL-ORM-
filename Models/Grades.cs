using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3._Anropa_databasen__SQL___ORM_.Models;
public partial class Grades
{
    public int FkemployeeId { get; set; }

    public int FkstudentId { get; set; }

    public string Subject { get; set; } = null!;

    public int Grade1 { get; set; }

    public DateTime GradeDate { get; set; }

    public virtual Employee Fkemployee { get; set; } = null!;

    public virtual Student Fkstudent { get; set; } = null!;

    public void LastMonthsGrades()
    {
        using MyLab3Context context = new();

        // Include foreign keys and choose to show all rows with gradedates last month. Sort by grade date.
        var grades = context.Grades
            .Include(b => b.Fkemployee)
            .Include(b => b.Fkstudent)
            .Where(b => b.GradeDate <= DateTime.Today)
            .Where(b => b.GradeDate >= DateTime.Today.AddMonths(-1))
            .OrderBy(b => b.GradeDate);

        Console.Clear();
        Console.WriteLine("---------------------\n" +
            "Betyg senaste månaden\n" +
            "---------------------\n");
        Console.WriteLine("Lärare".PadRight(27) + "Elev".PadRight(25) + "Ämne".PadRight(15) + "Betyg".PadRight(15) + "Betygsdatum");
        Console.WriteLine("---------------------------------------------------------------------------------------------");
        // Foreach to show all grades in last 30 days. 
        foreach (var row in grades)
        {
            Console.WriteLine(row.Fkemployee.FirstName.PadRight(11) + " " + row.Fkemployee.LastName.PadRight(15) +
                row.Fkstudent.FirstName.PadRight(9) + " " + row.Fkstudent.LastName.PadRight(15) +
                row.Subject.PadRight(15) + row.Grade1 + "".PadRight(14) + row.GradeDate.ToString("yyyy-MM-dd"));
        }

        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
        Console.ReadLine();
                
    }

    public void AverageGrade()
    {
        using MyLab3Context context = new();

        // Group all subjects and grades to show average, max and min grade of each subject.
        var grades = context.Grades
            .GroupBy(g => g.Subject, g => g.Grade1)
            .Select(g => new
            {
                Subject = g.Key,
                Average = g.Average(),
                Highest = g.Max(),
                Lowest = g.Min()
            });

        Console.Clear();
        Console.WriteLine("----------------------\n" +
    "Kurser och snittbetyg\n" +
    "----------------------\n");
        Console.WriteLine("Kurs".PadRight(30) + "Snittbetyg".PadRight(15) + "Högst betyg".PadRight(15) + "Lägst betyg");
        Console.WriteLine("-----------------------------------------------------------------------");
        // Foreach to print all subjects with average, max and min grade. Converted all grades to string so I could use PadRight for design purpose.
        foreach (var grade in grades)
        {
            Console.WriteLine(grade.Subject.PadRight(30) + Convert.ToString(grade.Average).PadRight(15) + Convert.ToString(grade.Highest).PadRight(15) + grade.Lowest);
        }

        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
        Console.ReadLine();
    }
}
