using System;
using System.Collections.Generic;

namespace _3._Anropa_databasen__SQL___ORM_.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public void AllEmployee()
    {
        using MyLab3Context context = new();
        // Foreach to print out all employees in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in context.Employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AllTeachers()
    {
        using MyLab3Context context = new();
        // Choose to only show "Teacher" from database.
        var employees = context.Employees
                                .Where(p => p.Title == "Teacher");

        // Foreach to print out all Teachers in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void Headmaster()
    {
        using MyLab3Context context = new();
        // Choose to only show "Headmaster" from database.
        var employees = context.Employees
                                .Where(p => p.Title == "Headmaster");

        // Foreach to print out all Headmasters in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(15) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(15) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AllOtherStaff()
    {
        using MyLab3Context context = new();
        // Choose to show all that isnt "Headmaster" or "Teacher" from database.
        var employees = context.Employees
                                .Where(p => p.Title != "Headmaster")
                                .Where(p => p.Title != "Teacher");

        // Foreach to print out all employee that isnt Teacher or Headmaster in database. Using PadRight for design purposes.
        Console.WriteLine("Titel".PadRight(20) + "Förnamn".PadRight(15) + "Efternamn");
        Console.WriteLine("------------------------------------------------");
        foreach (var row in employees)
        {
            Console.WriteLine(row.Title.PadRight(20) + row.FirstName.PadRight(15) + row.LastName);
        }
        Console.WriteLine("\nTryck Enter för att gå tillbaka...");
    }

    public void AddEmployees()
    {
        using MyLab3Context context = new();
        Console.Clear();

        // Adding employees to database.
        Console.WriteLine("Lägg till personal\n");
        Console.Write("Förnamn: ");
        string firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        string lastName = Console.ReadLine();

        string title = "";

        string menuChoice = "";
        // Give the user option to quick choose teacher, or else type their own title.
        while (title == "")
        {
            Console.WriteLine("Välj yrke\n" +
                "1. Lärare\n" +
                "2. Övrig personal\n");

            Console.Write("Yrkestitel (engelska): ");
            menuChoice = Console.ReadLine();
            Console.Clear();

            switch (menuChoice)
            {
                case "1":
                    title = "Teacher";
                    break;
                case "2":
                    title = Console.ReadLine();
                    break;
                default:
                    Console.Write("Felaktigt val! Vänligen försök igen.");
                    Console.ReadKey();
                    break;
            }
        }

        // Adding user inputs to new employee.
        var addEmployee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Title = title
        };

        // Adding and saving the new employee.
        context.Employees.Add(addEmployee);
        context.SaveChanges();

        // Give user a confirmation of new employee added.
        Console.WriteLine("Du har lagt till " + firstName + " " + lastName + " som " + title + "!");
        Console.ReadLine();
    }
}

