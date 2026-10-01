using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello again CSE210! This is my Scripture Memorizer.");
        
        List<Scripture> scriptures = new List<Scripture>()
        {
            // Proverbs 3:5-6 (KJV)
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            
            // 2 Nephi 31:20 (BoM)
            new Scripture(new Reference("2 Nephi", 31, 20), "Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life."),
            
            // Doctrine and Covenants 4:2-4 (D&C)
            new Scripture(new Reference("Doctrine and Covenants", 4, 2, 4), "Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day. Therefore, if ye have desires to serve God ye are called to the work; for behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul."),
            
            // Matthew 25:40 (KJV)
            new Scripture(new Reference("Matthew", 25, 40), "And the King shall answer and say unto them, Verily I say unto you, Inasmuch as ye have done it unto one of the least of these my brethren, ye have done it unto me."),
            
            // 1 Nephi 3:7 (BoM)
            new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            
            // Doctrine and Covenants 1:38 (D&C)
            new Scripture(new Reference("Doctrine and Covenants", 1, 38), "What I have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same.")
        };

        Random randomScripture = new Random();
        Scripture scripture = scriptures[randomScripture.Next(scriptures.Count)];

        string userInput = "";

        while (userInput != "quit")
        {
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nCongratulations! You've learned a new scripture.");
                Console.WriteLine("Press Enter to load a new random script, or type 'quit' to exit:");
                
                userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "quit") break;

                scripture = scriptures[randomScripture.Next(scriptures.Count)];
                continue;
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press [Enter] to hide more words, type “next” to change the text, or “quit” to exit:");
            
            userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "quit")
            {
                break;
            }
            else if (userInput == "next")
            {
            
                scripture = scriptures[randomScripture.Next(scriptures.Count)];
            }
            else if (userInput == "")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine("\nThank you for using our Scripture Memorizer! Come back soon and learn more scriptures.");
    }
}