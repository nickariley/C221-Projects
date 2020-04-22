using System;

namespace PoCos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            DriversLicense nicksDL = new DriversLicense("Nick", "Riley", "Male", 34554345);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(nicksDL.GetDriversLicenseInfoTrafficStop());
            Console.ReadKey();
            Console.Clear();

            Airplane boeing747 = new Airplane("Boeing", "747", "Passenger", 416, 4);
            Airplane airbusA380 = new Airplane("Airbus", "A380", "Passenger", 853, 4);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"The airplane i've heard most about is the {boeing747.GetAirPlaneInfo()}" +
                $"\nuntil I googled it's rival for this class which is the {airbusA380.GetAirPlaneInfo()}\nNow thats a big airplane!");
            Console.ReadKey();
            Console.Clear();

            Book redFern = new Book("Where the Red Fern Grows", new string[] {"Wilson", "Rawls"}, 245, 0440412676, "Doubleday", 8.38, 5, "My favorite book", 
                "Billy has long dreamt of owning not one, but two, dogs. So when he’s finally able to save up enough money for two pups to call his own—Old " +
                "Dan and Little Ann—he’s ecstatic.\nIt doesn’t matter that times are tough, together they’ll roam the hills of the Ozarks.\nSoon Billy and his " +
                "hounds become the finest hunting team in the valley.\nStories of their great achievements spread throughout the region, and the combination of " +
                "Old Dan’s brawn, Little Ann’s brains, and Billy’s sheer will seems unbeatable.\nBut tragedy awaits these determined hunters (now friends) and " +
                "Billy learns that hope can grow out of despair, and that the seeds of the future can come from the scars of the past.");

            Book theGiver = new Book("The Giver", new string[] { "Lois" , "Lowry"}, 192, 0544336267, "Houghton Mifflin Harcourt", 6.99);
            
            theGiver.Summary = "The main message of the novel is that choice is not destructive.\nIn this society, the absence of choice is actually more destructive.\n" +
                "All choices are made for people, and as a result they act in inhumane and immoral ways and don't even know it.";

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(redFern.GetBookWithReview());
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(theGiver.GetBookWoutReview());
            Console.ReadKey();
            Console.Clear();
        }
    }
}
