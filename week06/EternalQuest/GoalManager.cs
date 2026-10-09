using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private Level _userLevel;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _userLevel = new Level();
    }

    public void Start()
    {
        string choice = "";
        while (choice != "8")
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. Edit Goal");
            Console.WriteLine("  3. List Goals");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Record Event");
            Console.WriteLine("  7. Register / Update User Profile");
            Console.WriteLine("  8. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    EditGoal();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    RecordEvent();
                    break;
                case "7":
                    RegisterUserProfile();
                    break;
                case "8":
                    
                    Thread.Sleep(2000); 
                    
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("Keep working on your goals. Goodbye!");
                    Console.WriteLine();

                    Thread.Sleep(2000);

                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        var (levelNum, title) = _userLevel.GetCurrentLevelAndTitle(_score);
        string fullName = _userLevel.GetFullNameDisplay();

        Console.WriteLine($"{fullName}");
        Console.WriteLine($"Level: {levelNum}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Total Points: {_score}");
        
        if (!_userLevel.IsRegistered() && _score >= 600)
        {
            Console.WriteLine("\n⚠️ Notice: You have accumulated enough points to advance past Level 3, but your rank is set to 'Less Active Member'. Register your profile to unlock your proper titles!");
        }
        else if (!_userLevel.IsRegistered() && _score >= 450)
        {
            Console.WriteLine("\n⚠️ Notice: You are approaching the registration limit (Level 3 - Valiant). Register your profile to continue advancing through official titles!");
        }
    }

    public void RegisterUserProfile()
    {
        Console.Clear();
        Console.WriteLine("--- User Profile Registration ---");
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(firstName))
        {
            Console.WriteLine("\nInvalid first name. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("\nInvalid last name. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        char gender = ' ';
        while (true)
        {
            Console.Write("Enter your gender [M for Male / F for Female]: ");
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (input == "M" || input == "F")
            {
                gender = input[0];
                break;
            }
            Console.WriteLine("Invalid input. Please type strictly 'M' or 'F'.");
        }

        _userLevel.RegisterUser(firstName, lastName, gender);
        Console.WriteLine("\nUser profile successfully registered/updated!");
        Console.Write("Press Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("--- List of Goals ---");
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
        }
        else
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("--- Create New Goal ---");
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3")
        {
            Console.WriteLine("\nInvalid goal type selected. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("\nGoal name cannot be empty. Press Enter to return...");
            Console.ReadLine();
            return;
        }

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = GetValidNonZeroInt("What is the amount of points associated with this goal? (Positive to add, negative to subtract, e.g., 50 or -50): ");

        if (typeChoice == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("\nSimple goal created successfully!");
        }
        else if (typeChoice == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("\nEternal goal created successfully!");
        }
        else if (typeChoice == "3")
        {
            int target = GetValidPositiveInt("How many times does this goal need to be accomplished for a bonus? (Must be at least 1): ");
            int bonus = GetValidPositiveInt("What is the bonus for accomplishing it that many times? (Must be at least 1): ");

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
            Console.WriteLine("\nChecklist goal created successfully!");
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void EditGoal()
    {
        Console.Clear();
        Console.WriteLine("--- Edit Goal ---");
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to edit.");
            Console.Write("\nPress Enter to return to the main menu...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("\nWhich goal would you like to edit? (Enter number or type 'cancel' to return): ");
        string input = Console.ReadLine();

        if (input.Equals("cancel", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (int.TryParse(input, out int index))
        {
            int adjustedIndex = index - 1;
            if (adjustedIndex >= 0 && adjustedIndex < _goals.Count)
            {
                Goal goal = _goals[adjustedIndex];
                string rep = goal.GetStringRepresentation();
                string[] parts = rep.Split('|');
                string type = parts[0];

                string currentName = parts[1];
                string currentDesc = parts[2];
                int currentPoints = int.Parse(parts[3]);

                Console.WriteLine($"\nEditing: {currentName}");
                Console.WriteLine("Press Enter without typing anything to keep current values.");

                Console.Write($"Enter new name [{currentName}]: ");
                string newNameInput = Console.ReadLine();
                string name = string.IsNullOrWhiteSpace(newNameInput) ? currentName : newNameInput;

                Console.Write($"Enter new description [{currentDesc}]: ");
                string newDescInput = Console.ReadLine();
                string description = string.IsNullOrWhiteSpace(newDescInput) ? currentDesc : newDescInput;

                Console.Write($"Enter new points [{currentPoints}]: ");
                string newPointsInput = Console.ReadLine();
                int points = currentPoints;
                if (!string.IsNullOrWhiteSpace(newPointsInput) && int.TryParse(newPointsInput, out int p) && p != 0)
                {
                    points = p;
                }

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    SimpleGoal updatedGoal = new SimpleGoal(name, description, points, isComplete);
                    _goals[adjustedIndex] = updatedGoal;
                }
                else if (type == "EternalGoal")
                {
                    EternalGoal updatedGoal = new EternalGoal(name, description, points);
                    _goals[adjustedIndex] = updatedGoal;
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(parts[4]);
                    int amountCompleted = int.Parse(parts[5]);
                    int target = int.Parse(parts[6]);

                    Console.Write($"Enter new target amount [{target}]: ");
                    string newTargetInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTargetInput) && int.TryParse(newTargetInput, out int t) && t >= 1)
                    {
                        target = t;
                    }

                    Console.Write($"Enter new bonus points [{bonus}]: ");
                    string newBonusInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newBonusInput) && int.TryParse(newBonusInput, out int b) && b >= 1)
                    {
                        bonus = b;
                    }

                    ChecklistGoal updatedGoal = new ChecklistGoal(name, description, points, amountCompleted, target, bonus);
                    _goals[adjustedIndex] = updatedGoal;
                }

                Console.WriteLine("\nGoal updated successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input format.");
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }

    private int GetValidPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value >= 1)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid whole number greater than or equal to 1.");
        }
    }

    private int GetValidNonZeroInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value != 0)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid whole number other than 0 (positive or negative).");
        }
    }

    public void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("--- Record Event ---");
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nThere are no goals available to record.");
            Console.Write("\nPress Enter to return to the main menu...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("\nWhich goal did you accomplish? (Enter number or type 'cancel' to return): ");
        string input = Console.ReadLine();

        if (input.Equals("cancel", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (int.TryParse(input, out int index))
        {
            int adjustedIndex = index - 1;
            if (adjustedIndex >= 0 && adjustedIndex < _goals.Count)
            {
                Goal goal = _goals[adjustedIndex];
                int earnedPoints = goal.RecordEvent();
                
                _score = Math.Max(0, _score + earnedPoints);

                if (earnedPoints >= 0)
                {
                    Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points!");
                }
                else
                {
                    Console.WriteLine($"\nRecorded penalty: {earnedPoints} points.");
                }
                
                Console.WriteLine($"Total Points: {_score}");
            }
            else
            {
                Console.WriteLine("\nInvalid goal selection number.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input format.");
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Clear();
        Console.WriteLine("--- Save Goals ---");
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("\nInvalid filename. Save operation cancelled.");
            Console.Write("Press Enter to return to the main menu...");
            Console.ReadLine();
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"{_score}|{_userLevel.GetSerializationString()}");
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("\nGoals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving the file: {ex.Message}");
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Clear();
        Console.WriteLine("--- Load Goals ---");
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length == 0)
                {
                    Console.WriteLine("\nThe file is empty.");
                    Console.Write("Press Enter to return to the main menu...");
                    Console.ReadLine();
                    return;
                }

                string[] headerParts = lines[0].Split("|");
                if (!int.TryParse(headerParts[0], out int loadedScore))
                {
                    Console.WriteLine("\nError: Corrupted score data in file.");
                    Console.Write("Press Enter to return to the main menu...");
                    Console.ReadLine();
                    return;
                }

                _score = loadedScore;

                if (headerParts.Length >= 5 && bool.TryParse(headerParts[1], out bool isReg) && isReg)
                {
                    string fName = headerParts[2];
                    string lName = headerParts[3];
                    char g = string.IsNullOrEmpty(headerParts[4]) ? 'M' : headerParts[4][0];
                    _userLevel = new Level(fName, lName, g, true);
                }
                else
                {
                    _userLevel = new Level();
                }

                _goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split("|");
                    if (parts.Length < 4) continue;

                    string goalType = parts[0];

                    if (goalType == "SimpleGoal" && parts.Length >= 5)
                    {
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);

                        SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                        _goals.Add(goal);
                    }
                    else if (goalType == "EternalGoal" && parts.Length >= 4)
                    {
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);

                        EternalGoal goal = new EternalGoal(name, description, points);
                        _goals.Add(goal);
                    }
                    else if (goalType == "ChecklistGoal" && parts.Length >= 7)
                    {
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        int bonus = int.Parse(parts[4]);
                        int amountCompleted = int.Parse(parts[5]);
                        int target = int.Parse(parts[6]);

                        ChecklistGoal goal = new ChecklistGoal(name, description, points, amountCompleted, target, bonus);
                        _goals.Add(goal);
                    }
                }
                Console.WriteLine("\nGoals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred while loading the file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nFile not found.");
        }

        Console.Write("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }
}