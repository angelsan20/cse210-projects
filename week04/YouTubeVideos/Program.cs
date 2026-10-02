using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("\nHello partners! Here is my YouTube Videos Project.");
        Console.WriteLine("");

        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Object-Oriented Programming Basics", "CodeMaster", 640);
        video1.AddComment(new Comment("CarlosP", "Great explanation, very clear!"));
        video1.AddComment(new Comment("AnaG", "Helped me a lot with my assignment."));
        video1.AddComment(new Comment("LuisDev", "Thanks for sharing this content."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Mastering Git and GitHub from the Terminal", "TechGuru", 920);
        video2.AddComment(new Comment("Sofia123", "Just what I needed to fix a merge conflict."));
        video2.AddComment(new Comment("PedroM", "Straight to the point, awesome tutorial."));
        video2.AddComment(new Comment("EmmaW", "Very helpful commands explained well."));
        video2.AddComment(new Comment("JohnDoe", "Subscribed! Looking forward to more."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Responsive Web Design with CSS Grid and Flexbox", "WebDesignPro", 1150);
        video3.AddComment(new Comment("MariaTech", "The Flexbox examples are amazing."));
        video3.AddComment(new Comment("JuanProg", "Great video, greetings from abroad!"));
        video3.AddComment(new Comment("ElenaR", "Loved the layout structure you built."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("SQL Database Fundamentals and JOIN Queries", "DataMaster", 810);
        video4.AddComment(new Comment("GabrielS", "Finally understood how inner joins work."));
        video4.AddComment(new Comment("ValeriaM", "Super clear explanation of relationships."));
        video4.AddComment(new Comment("TomH", "Awesome breakdown of queries."));
        video4.AddComment(new Comment("RachelGreen", "Saved my database exam, thank you!"));
        video4.AddComment(new Comment("ChandlerB", "Could this video BE any more helpful?"));
        videos.Add(video4);

        // Iterate through each video and display its details
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}