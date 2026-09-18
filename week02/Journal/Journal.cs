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
        Console.WriteLine("\n--- Blog Posts ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        /*  using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    // the ~|~ delimiter was selected to avoid conflicts with commas or semicolons.
                    writer.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
                }
            }
            Console.WriteLine($"Log successfully saved in '{file}'.\n"); 
        */

        var options = new JsonSerializerOptions { WriteIndented = true };
        
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

        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);

        /*
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(entry);
            }
        }
        */
        Console.WriteLine($"Log successfully uploaded from '{file}'.\n");
    }
}