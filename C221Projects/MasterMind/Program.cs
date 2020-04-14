using System;
using System.Collections.Generic;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] colorNumbers = new int[] { 1, 2, 3 };//1 = red, 2=yellow & 3=blue

            List<int> userInput = new List<int>();
            List<int> computerInput = new List<int>();

            Random compRandom = new Random();
            computerInput.Add(colorNumbers[compRandom.Next(0, 3)]);
            computerInput.Add(colorNumbers[compRandom.Next(0, 3)]);



            bool stillPlaying = true;
            while (stillPlaying == true)
            {
                Console.Clear();
                userInput.Clear();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine("Welcome to MasterMind!");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter a color choice between: Red, Yellow & Blue.");
                Console.ForegroundColor = ConsoleColor.White;
                string userInputString = Console.ReadLine().ToLower().Trim();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter a color choice between: Red, Yellow & Blue.");
                Console.ForegroundColor = ConsoleColor.White;
                string userInputString2 = Console.ReadLine().ToLower().Trim();

                int userInputNumber1 = 0;
                switch (userInputString)
                {
                    case "red":
                        userInputNumber1 = 1;
                        break;
                    case "yellow":
                        userInputNumber1 = 2;
                        break;
                    case "blue":
                        userInputNumber1 = 3;
                        break;
                }

                int userInputNumber2 = 0;
                switch (userInputString2)
                {
                    case "red":
                        userInputNumber2 = 1;
                        break;
                    case "yellow":
                        userInputNumber2 = 2;
                        break;
                    case "blue":
                        userInputNumber2 = 3;
                        break;
                }

                userInput.Add(userInputNumber1);
                userInput.Add(userInputNumber2);

                //Console.WriteLine(userInputNumber1);// testing to see output of userInputNumber1 //could use this to compare individually without adding to list
                //Console.WriteLine(userInputNumber2);// testing to see output of userInputNumber2 //could use this to compare individually without adding to list
                //Console.WriteLine(userInput[0]); //uncomment to see user input at index 0 //test to see value added to user input list at index 0
                //Console.WriteLine(userInput[1]); //uncomment to see user input at index 1 //test to see value added to user input list at index 1 
                //Console.WriteLine(computerInput[0]); //uncomment to see computer choice at index 0
                //Console.WriteLine(computerInput[1]); //uncomment to see computer choice at index 1


                if (userInput[0].Equals(computerInput[0]) && userInput[1].Equals(computerInput[1])) //if userChoice index 0 = computerChoice index 0 && userChoice index 1 = computerChoice index 1
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n2-2. You win! You Guessed both colors in the correct positions.");
                    Console.WriteLine();
                }

                else if (userInput[0].Equals(computerInput[0]) || userInput[1].Equals(computerInput[1])) //if user index 0 = comp index 0 || or user index 1 equals computer index 1
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n0-1. You guessed one of the colors in the correct position.");
                    Console.WriteLine();
                }
                else if (userInput.Contains(computerInput[0]) || userInput.Contains(computerInput[1])) //if user choice contains computer choice at index 0 or 1
                {
                    if (userInput[0].Equals(computerInput[1]) && userInput[1].Equals(computerInput[0])) //and also if user index 0 = computer index 1 && user index 1 = computer index 0
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n2-0. You guessed both of the colors but in the wrong positions.");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n1-0. You guessed one of the colors correctly but not in the correct position.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n0-0. You did not guess either color.");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWould you like to play again? Y/N");
                stillPlaying = Console.ReadLine().ToLower().Contains("y") ? true : false;

            }
            Console.WriteLine("Game Over!");


            Console.ReadKey();

        }
    }
}
