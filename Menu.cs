using _3._Anropa_databasen__SQL___ORM_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Anropa_databasen__SQL___ORM_
{
    public class Menu
    {
        Employee employee = new();
        Student student = new();
        Grades grade = new();
        // Start menu where all choices are made.
        public void StartMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                // Print out all options.
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "1. Information om personal\n" +
                              "2. Information om elever\n" +
                              "3. Betyg\n" +
                              "4. Kurser\n" +
                              "5. Lägg till personal\n" +
                              "6. Lägg till elever\n" +
                              "0. Avsluta program\n");

                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        EmployeeMenu();
                        break;
                    case "2":
                        StudentMenu();
                        break;
                    case "3":
                        grade.LastMonthsGrades();
                        break;
                    case "4":
                        grade.AverageGrade();
                        break;
                    case "5":
                        employee.AddEmployees();
                        break;
                    case "6":
                        student.AddStudents();
                        break;
                    case "0":
                        Console.Write("\nProgrammet avslutas\n");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nFelaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void EmployeeMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "Information om personal\n" +
                              "---------------------------------------\n" +
                              "1. All personal\n" +
                              "2. Rektorer\n" +
                              "3. Lärare\n" +
                              "4. Övrig personal\n" +
                              "0. Återgå till föregående meny\n");
                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                Console.Clear();

                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        employee.AllEmployee();
                        Console.ReadKey();
                        break;
                    case "2":
                        employee.Headmaster();
                        Console.ReadKey();
                        break;
                    case "3":
                        employee.AllTeachers();
                        Console.ReadKey();
                        break;
                    case "4":
                        employee.AllOtherStaff();
                        Console.ReadKey();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Write("Felaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void StudentMenu()
        {
            string menuChoice = "";
            // While loop when navigating menu.
            while (menuChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("Hämta information från Hogwarts databas\n" +
                              "---------------------------------------\n" +
                              "Information om elever\n" +
                              "---------------------------------------\n" +
                              "1. Alla elever\n" +
                              "2. Elever i Gryffindor\n" +
                              "3. Elever i Slytherin\n" +
                              "4. Elever i Hufflepuff\n" +
                              "5. Elever i Ravenclaw\n" +
                              "0. Återgå till föregående meny\n");
                Console.Write("Ditt val: ");
                menuChoice = Console.ReadLine();
                Console.Clear();

                // Switch loop that takes user to the menu it chooses.
                switch (menuChoice)
                {
                    case "1":
                        student.AllStudents();
                        break;
                    case "2":
                        student.StudentsInClass("Gryffindor");
                        Console.ReadKey();
                        break;
                    case "3":
                        student.StudentsInClass("Slytherin");
                        Console.ReadKey();
                        break;
                    case "4":
                        student.StudentsInClass("Hufflepuff");
                        Console.ReadKey();
                        break;                    
                    case "5":
                        student.StudentsInClass("Ravenclaw");
                        Console.ReadKey();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Write("Felaktigt val! Vänligen försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    }
}