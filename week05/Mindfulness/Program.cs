using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CSE210 Block 5, Mindfulness Project, student Angel Santafé.");


        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities Main Menu");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Stretching Activity (Additional)");
            Console.WriteLine("5. Quit");
            Console.Write("Select a menu option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    StretchingActivity stretching = new StretchingActivity();
                    stretching.Run();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nThank you for taking care of your well-being today! Goodbye.");
                    Thread.Sleep(2000);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please select a number between 1 and 5.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    /*
     * EXCEEDING REQUIREMENTS:
     * To exceed expectations and achieve maximum credit, this program includes:
     * 1. A completely new additional activity called "StretchingActivity",
     *    which guides the user through alternate side stretching intervals to release physical tension.
     * 2. Smart selection mechanisms ensuring prompts and questions do not repeat
     *    until all options are exhausted within the current session.
     * 3. Additional custom animation (processing message with animated dots).
     */
}