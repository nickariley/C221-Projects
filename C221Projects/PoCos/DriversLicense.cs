using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class DriversLicense
    {
        //fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int LicenseNumber { get; set; }


        //constructor
        public DriversLicense(string firstName, string lastName, string gender, int licenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            LicenseNumber = licenseNumber;
        }

        //property 1
        public string getFirstName()
        {
            return FirstName;
        }

        //property 2
        public string getLastName()
        {
            return LastName;
        }

        //property 3
        public string getGender()
        {
            return Gender;
        }

        //property 4
        public int getLicenseNumber()
        {
            return LicenseNumber;
        }

        //method with a return string to simulate a traffic stop.
        public string GetDriversLicenseInfoTrafficStop()
        {
            return ($"Dispatch we've stopped a {getGender()} suspect that goes by {getFirstName()} {getLastName()} drivers license number " +
                $"{getLicenseNumber()}\nIndividual was traveling at 100mph in a 55mph Zone,\nHow should we proceed with the individual?\nAny active Warrants?\n" +
                $"Thanks dispatch. We will let {getFirstName()} {getLastName()} know he's free to leave with a traffic citation");
        }
    }
}
