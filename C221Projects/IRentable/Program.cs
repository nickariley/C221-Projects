using System;
using System.Collections.Generic;
using System.Linq;

namespace IRentable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> rentables = new List<IRentable>();
            rentables.Add(new Boat(2020, "Mastercraft", "X24", 8, 75.99M));
            rentables.Add(new Boat(2020, "Ranger", "Z Comanche Series - Z500", 8, 65.99M));
            rentables.Add(new Boat(2020, "Malibu", "Wakesetter", 4, 85.99M));
            rentables.Add(new Car(1969, "Chevrolet", "Camaro", 2, 200));
            rentables.Add(new Car(1969, "Chevrolet", "Chevelle", 2, 100));
            rentables.Add(new Car(1969, "Chevrolet", "Nova", 2, 350));
            rentables.Add(new House("1190 Hilltop Way", 8, 3, 16, "Pool & HotTub", 7));
            rentables.Add(new House("125 Rocky Mountain Way", 12, 4, 24, "Steam Room & Sauna", 7));
            rentables.Add(new House("315 Lakeside Drive", 4, 2, 8, "Private Dock", 7));

            foreach (var item in rentables)
            {
                Console.WriteLine($"{item.GetDescription()} {item.GetRate()}");
            }
            Console.ReadKey();
        }
    }

    interface IRentable
    {
        string GetRate();
        string GetDescription();
    }

    class Boat : IRentable
    {
        private int Year;
        private string Make;
        private string Model;
        private int Hours;
        private decimal HourlyRate;
        private decimal PerDay;
        

        public Boat (int year, string make, string model, int hours, decimal hourlyRate)
        {
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.Hours = hours;
            this.HourlyRate = hourlyRate;
            this.PerDay = hourlyRate * hours;
            
        }

        public string GetDescription()
        {
            return $"\n\n\nThe Boat you're interested in renting is a:\n\n{Year} {Make}, {Model}";
        }

        public string GetRate()
        {
            
            return $"\n\nIt is ${HourlyRate} per hour.\n\nThis boat will cost: ${PerDay}\n\nTo enjoy the lake for {Hours} hours!";
        }
    }

    class Car : IRentable
    {
        private int Year;
        private string Make;
        private string Model;
        private int Doors;
        private decimal Rate;
        private int MileCount;
        private decimal Mpg;
        private decimal CostPerMile;
        private decimal CostPerDay;

        public Car(int year, string make, string model, int doors, int milecount)
        {
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.Doors = doors;
            this.Mpg = milecount / 20;
            this.MileCount = milecount;
            this.CostPerMile = milecount * .55M;
            this.Rate = 35.99M;
            this.CostPerDay = Rate + CostPerMile;
        }

        public string GetDescription()
        {
            return $"\n\n\nThe Vehicle you wish to rent is a:\n\n{Year} {Make}, {Model} it has {Doors} doors and gets {Mpg}MPG!";
        }

        public string GetRate()
        {
            return $"\n\nThis rental car costs ${Rate} per day\n\nThe car is an additional .55 cents a mile that you drive.\n\nYou've chosen to drive {MileCount} miles, being an additional ${CostPerMile}\n\nThis brings your grand total to: ${CostPerDay}\n\nHow would you like to pay?";
        }
    }

    class House : IRentable
    {
        private string Address;
        private int Bedrooms;
        private int Bathrooms;
        private int Sleeps;
        private string Amentities;
        private decimal WeekRate;
        private decimal DailyRate = 250.99M;
        private int Nights;
        private decimal Total;

        public House(string address, int bedrooms, int bathrooms, int sleeps, string amentities, int nights)
        {
            this.Address = address;
            this.Bedrooms = bedrooms;
            this.Bathrooms = bathrooms;
            this.Sleeps = sleeps;
            this.Amentities = amentities;
            this.Nights = nights;
            this.WeekRate = (7 * DailyRate) *.10M;
            this.Total = nights * DailyRate;
        }

        public string GetDescription()
        {
            return $"\n\n\nThe House you've chosen to rent is located at:\n\n{Address}\n\nIt has {Bedrooms} bedrooms, and {Bathrooms} bathrooms.\n\nThis house sleeps {Sleeps} people.\n\nIt has a luxurious {Amentities}";
        }

        public string GetRate()
        {
            return $"The House you've chose to rent costs: ${DailyRate} per day.\n\nIf you choose to stay for a week we will apply a discount and your weekly rate will be reduced by ${WeekRate} dollars.\n\nYou Chose to stay for {Nights} nights making your total: {Total} before any discounts are applied.";
        }
    }
}
