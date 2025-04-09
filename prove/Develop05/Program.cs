using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

//For creativity, I added in the ability to level up based on your points.
class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _totalPoints = 0;
    private static int _level = 1;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayStatus();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": DisplayGoals(); break;
                case "2": CreateGoal(); break;
                case "3": RecordEvent(); break;
                case "4": SaveProgress(); break;
                case "5": LoadProgress(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid option"); break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void DisplayStatus()
    {
        Console.WriteLine($"Level: {_level} | Total Points: {_totalPoints}");
    }

    private static void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplay()}");
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");

        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    private static void RecordEvent()
    {
        DisplayGoals();
        Console.Write("\nSelect goal to record (number): ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int pointsEarned = _goals[index].RecordEvent();
        _totalPoints += pointsEarned;
        _level = _totalPoints / 1000 + 1;
        Console.WriteLine($"Earned {pointsEarned} points!");
    }

    private static void SaveProgress()
    {
        var saveData = new SaveData
        {
            TotalPoints = _totalPoints,
            Goals = _goals
        };
        string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        });
        File.WriteAllText("progress.json", json);
        Console.WriteLine("Progress saved!");
    }

    private static void LoadProgress()
    {
        if (File.Exists("progress.json"))
        {
            try
            {
                string json = File.ReadAllText("progress.json");
                SaveData saveData = JsonSerializer.Deserialize<SaveData>(json, new JsonSerializerOptions
                {
                    IncludeFields = true
                });

                _totalPoints = saveData.TotalPoints;
                _level = _totalPoints / 1000 + 1;
                _goals = saveData.Goals ?? new List<Goal>();

                Console.WriteLine("Progress loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading progress: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No saved progress found!");
        }
    }
}