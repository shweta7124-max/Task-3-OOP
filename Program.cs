
using System;
using System.Collections.Generic;
using System.Linq;

class Teacher
{
    private string _name = "";
    private string _subject = "";
    private int _yearsOfExperience;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            _name = value.Trim();
        }
    }

    public string Subject
    {
        get { return _subject; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Subject cannot be empty.");

            _subject = value.Trim();
        }
    }

    public int YearsOfExperience
    {
        get { return _yearsOfExperience; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(YearsOfExperience),
                    "Experience cannot be negative.");

            _yearsOfExperience = value;
        }
    }

    public Teacher(string name, string subject, int yearsOfExperience)
    {
        Name = name;
        Subject = subject;
        YearsOfExperience = yearsOfExperience;
    }

    public void ShowProfile()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Subject: {Subject}");
        Console.WriteLine($"Experience: {YearsOfExperience} years");
    }
}

class Program
{
    private static readonly List<Teacher> Teachers = new();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddTeacher();
                    break;

                case "2":
                    ShowTeachers();
                    break;

                case "3":
                    ShowTeacherCount();
                    break;

                case "4":
                    ShowAverageExperience();
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n=== Teacher System ===");
        Console.WriteLine("1. Add teacher");
        Console.WriteLine("2. Show teachers");
        Console.WriteLine("3. Count teachers");
        Console.WriteLine("4. Average experience");
        Console.WriteLine("0. Exit");
    }

    static void AddTeacher()
    {
        try
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter subject: ");
            string subject = Console.ReadLine() ?? "";

            Console.Write("Enter years of experience: ");

            if (!int.TryParse(Console.ReadLine(), out int experience))
            {
                Console.WriteLine("Experience must be a whole number.");
                return;
            }

            Teacher teacher = new Teacher(name, subject, experience);
            Teachers.Add(teacher);

            Console.WriteLine("Teacher added successfully!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid data: {ex.Message}");
        }
    }

    static void ShowTeachers()
    {
        if (Teachers.Count == 0)
        {
            Console.WriteLine("No teachers have been added.");
            return;
        }

        Console.WriteLine("\n--- Teacher Profiles ---");

        foreach (Teacher teacher in Teachers)
        {
            teacher.ShowProfile();
            Console.WriteLine("------------------------");
        }
    }

    static void ShowTeacherCount()
    {
        Console.WriteLine($"Total teachers: {Teachers.Count}");
    }

    static void ShowAverageExperience()
    {
        if (Teachers.Count == 0)
        {
            Console.WriteLine(
                "Cannot calculate an average: no teachers yet.");
            return;
        }

        double average = Teachers.Average(
            teacher => teacher.YearsOfExperience);

        Console.WriteLine($"Average experience: {average:F2} years");
    }
}