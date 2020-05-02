using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot carlotNarly = new CarLot("\tNARLY'S AUTOS", "We have the Gnarliest Rides in Town so come on down!\n\n\tNARLY'S Inventory:");
            CarLot carlotBurly = new CarLot("\tBURLY'S AUTOS", "Wow, What a Beaut!\n\n\tBURLY'S Inventory:");

            carlotNarly.AddVehicle(new Truck(1972, "Chevy", "C10", 15999.99, "CEEYA", "Single Cab", "6ft"));
            
            carlotNarly.AddVehicle(new Truck(1996, "Chevy", "1500", 10999.99, "ROLLIN", "Crew Cab", "6ft"));

            carlotNarly.AddVehicle(new Truck(2018, "Chevy", "Colorado", 50999.99, "2SLOW", "Full Cab", "6ft"));


            carlotBurly.AddVehicle(new Car(2019, "Chevy", "Cruise LT", 15999.99, "YEEHAW", "Hatchback", 4));

            carlotBurly.AddVehicle(new Car(2006, "Infiniti", "G35", 35999.99, "BETSY", "Coupe", 2));

            carlotBurly.AddVehicle(new Car(1969, "Chevy", "Camaro", 45999.99, "WBR", "Coupe", 2));

            
            carlotNarly.CarLotCommercial();
            Console.WriteLine($"{carlotNarly.vehicles.Count} Gnarly Rides");
            Console.WriteLine();


            foreach (var automobile in carlotNarly.GetVehicles())
            {
                automobile.VehicleDescription();
            }


            Console.WriteLine("Or Press any key to find a sweet ride at our other location:\n");
            Console.ReadKey();


            carlotBurly.CarLotCommercial();
            Console.WriteLine($"{carlotBurly.vehicles.Count} Beauts!");
            Console.WriteLine();


            foreach (var automobile in carlotBurly.GetVehicles())
            {
                automobile.VehicleDescription();
            }

            Console.WriteLine("Did you find one you love? Press any key to exit the program. Don't forget to come sign the paperwork to get yourself rollin'!");
            Console.ReadKey();

        }

        abstract class Vehicle
        {
            public int Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public double Price { get; set; }
            public string LicenseNumber { get; set; }

            public Vehicle(int year, string make, string model, double price, string licenseNumber)
            {
                Year = year;
                LicenseNumber = licenseNumber;
                Make = make;
                Model = model;
                Price = price;
            }

            public virtual void VehicleDescription()
            {
                Console.WriteLine($"Vehicle Description: {Year} {Make} {Model} ${Price} {LicenseNumber}");
            }
        }

        class Car : Vehicle
        {
            public int NoOfDoors { get; set; }

            public string CarType { get; set; }

            public Car(int year, string make, string model, double price, string licenseNumber, string carType ,int noOfDoors) : base(year, make, model, price, licenseNumber)
            {
                
                NoOfDoors = noOfDoors;
                CarType = carType;
            }

            public override void VehicleDescription()
            {
                Console.WriteLine($"\tCar Description:\n\t Year: {Year}\n\t Make: {Make}\n\t Model: {Model}\n\t CarType: {CarType}\n\t Doors: {NoOfDoors}\n\t Price: ${Price}\n\t License Plate: {LicenseNumber}\n");
            }
        }

        class Truck : Vehicle
        {
            public string BedSize { get; set; }
            public string CabType { get; set; }

            public Truck(int year, string make, string model, double price, string licenseNumber, string cabType, string bedSize) : base(year, make, model, price, licenseNumber)
            {
                BedSize = bedSize;
                CabType = cabType;
            }

            public override void VehicleDescription()
            {
                Console.WriteLine($"\tTruck Description:\n\t Year: {Year}\n\t Make: {Make}\n\t Model: {Model}\n\t CabType: {CabType}\n\t BedSize: {BedSize}\n\t Price: ${Price}\n\t License Plate: {LicenseNumber}\n");
            }

        }

        class CarLot
        {
            public string Name { get; set; }
            public string CatchPhrase { get; set; }

            

            public CarLot(string name, string catchPhrase)
            {
                Name = name;
                CatchPhrase = catchPhrase;
            }

            public List<Vehicle> vehicles = new List<Vehicle>();

            public void AddVehicle(Vehicle vehicle)
            {
                vehicles.Add(vehicle);
            }

            public List<Vehicle> GetVehicles()
            {
                return vehicles;
            }

            public void CarLotCommercial()
            {
                Console.Write($"{Name}, {CatchPhrase} ");
            }

        }
    }
}
