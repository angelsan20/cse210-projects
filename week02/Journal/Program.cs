using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi Team! This is my Journal Project.");
        Console.WriteLine();

        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    string response = "";
                    bool promptConfirmed = false;

                    while (!promptConfirmed)
                    {
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.WriteLine("(Type your answer or enter '0' to change the question)");
                        Console.Write("> ");

                        string input = Console.ReadLine();

                        if (input == "0")
                        {
                            string oldPrompt = prompt;

                            while (prompt == oldPrompt)
                            {
                                prompt = promptGen.GetRandomPrompt();
                            }

                        }
                        else
                        {
                            response = input;
                            promptConfirmed = true;
                        }
                    }

                    string date = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
                    Entry newEntry = new Entry(date, prompt, response);
                    myJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry successfully saved.\n");
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the name of the file? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the name of the file? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again..\n");
                    break;
            }
        }
    }
}