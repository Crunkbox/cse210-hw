using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options: \n1. Start Breathing Activity \n2. Start Reflection Activity \n3. Start Listing Activity \n4. Quit");

            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                Console.WriteLine("Starting Breathing Activity...");
                breathingActivity.Breathing();
                break;

                case "2":
                Console.WriteLine("Starting Reflection Activity...");
                reflectionActivity.Reflecting();
                break;

                case "3":
                Console.WriteLine("Starting Listing Activty...");
                listingActivity.Listing();
                break;

                case "4":
                Console.WriteLine("Exiting the program. Until next time!");
                running = false;
                break;

                default:
                Console.WriteLine("Invalid selection. Please choose a valid option.");
                break;
            }
            if (running)
            {
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}