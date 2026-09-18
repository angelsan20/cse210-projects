using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The Log is currently empty.\n");
            return;
        }
        Console.WriteLine("\n--- Log Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(_entries, options);

        File.WriteAllText(file, jsonString);

        Console.WriteLine($"Log successfully saved in JSON format with the name '{file}'.\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("The specified file does not exist.\n");
            return;
        }

        string jsonString = File.ReadAllText(file);

        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? new List<Entry>();

        Console.WriteLine($"Log successfully uploaded from '{file}'.\n");
    }
}