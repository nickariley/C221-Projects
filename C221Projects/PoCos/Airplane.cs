using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class Airplane
    {
        //Fields
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public int Capacity { get; set; }
        public int Engines { get; set; }

        //Constructor
        public Airplane(string manufacturer, string model, string variant, int capacity, int engines)
        {
            Manufacturer = manufacturer;
            Model = model;
            Variant = variant;
            Capacity = capacity;
            Engines = engines;
        }

        //property 1
        public string GetManufacturer()
        {
            return Manufacturer;
        }

        //property 2
        public string GetModel()
        {
            return Model;
        }

        //property 3
        public string GetVariant()
        {
            return Variant;
        }

        //property 4
        public int GetCapacity()
        {
            return Capacity;
        }

        //property 5
        public int GetEngines()
        {
            return Engines;
        }

        public string GetAirPlaneInfo()
        {
            return ($"{GetManufacturer()} {GetModel()} {GetVariant()}\nThat holds approximately {GetCapacity()} people on board" +
                $"\npowered by {GetEngines()} engines");
        }



    }
}
