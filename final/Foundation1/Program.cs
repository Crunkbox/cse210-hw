using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video();
        video1.SetAuthor("Crunkbox");
        video1.SetTitle("Minecraft Let's Play: Episode 1!");
        video1.SetVideoLength("965 seconds");
        video1.AddComment(new Comment ("UrbanWolf","Can't wait to see more!"));
        video1.AddComment(new Comment ("JiggleHeimmmer420", "Get into the Nether. NOW!"));
        video1.AddComment(new Comment ("BinjaNinja", "Make a mob spawner."));

        Video video2 = new Video();
        video2.SetAuthor("Electronic Restoration");
        video2.SetTitle("N64 Controller Restoration");
        video2.SetVideoLength("1,986 seconds");
        video2.AddComment(new Comment ("NUTCR@CK3R","Man, I wish I could fix my controller."));
        video2.AddComment(new Comment ("xxxGenericGamerTag69xxx", "Could I hire you to fix my GameCube? It has been crashing after 5 minutes of play."));
        video2.AddComment(new Comment ("THE_MEGA_GURKIN", "I love your videos! The perfect ASMR for me to fall asleep too."));

        Video video3 = new Video();
        video3.SetAuthor("Xtreme Bushcrafting");
        video3.SetTitle("Making an In-Hill Hut");
        video3.SetVideoLength("2,895 seconds");
        video3.AddComment(new Comment ("TurboTurbinTurk","I think this is the first legit bushcraft channel that doesn't use modern equipment between cuts."));
        video3.AddComment(new Comment ("Jake Halloway", "Wow! I know it isn't easy per se, but I didn't realize that it was a lot more simple than it seemed."));
        video3.AddComment(new Comment ("Nurpl3_G1v3r", "Fake."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}