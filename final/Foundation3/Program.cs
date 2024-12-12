using System;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("1189 Main St", "Austin", "TX", "USA");
        Address receptionAddress = new Address("730 James Rd", "Cypress", "TX", "USA");
        Address outdoorAddress = new Address("159 Ocean Walk Blvd", "Morro Bay", "CA", "USA");

        LectureEvent lecture = new LectureEvent(
            "Games Done Quick",
            "Speedrunning Ocarina of Time, Resident Evil 4, and Dragon's Dogma.",
            "08/14/2025",
            "10:00am",
            lectureAddress,
            "Eric Hasha (VoyagerSven)",
            350
        );

        ReceptionEvent reception = new ReceptionEvent(
            "Wedding for John and Jane Doe",
            "Join us for the marriage of John Doe and Jane Buck.",
            "05/28/25",
            "1:00pm",
            receptionAddress,
            "janebuckaneer@gmail.com"
        );

        OutdoorEvent outdoor = new OutdoorEvent(
            "Dirt Bike Rally",
            "REV UP YOUR ENGINES AND BRING AN EXTRA PAIR OF UNDIES FOR THE GREASTEST EVENT OF THE YEAR!",
            "07/10/2025",
            "3:30pm",
            outdoorAddress,
            "Partly Cloudy"
        );

        Console.WriteLine("=== Lecture Event ===");
        Console.WriteLine(lecture.StandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.FullLectureDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.LectureShortDescription());

        Console.WriteLine();

        Console.WriteLine("=== Reception Event ===");
        Console.WriteLine(reception.StandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.FullReceptionDetails());
        Console.WriteLine();
        Console.WriteLine(reception.ReceptionShortDescription());

        Console.WriteLine();

        Console.WriteLine("=== Outdoor Event ===");
        Console.WriteLine(outdoor.StandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.FullOutdoorDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.OutdoorShortDescriptions());
        
        Console.WriteLine();
    }
}