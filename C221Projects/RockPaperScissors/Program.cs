using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {

                Random random = new Random(); //generate a random hand for computer
                int compChoice = random.Next(1, 4); //generate a random hand for computer

                Console.WriteLine("Enter Rock, paper or scissors!"); //ask user for hand => 1, 2, 3 or Rock Paper Scissors
                string userChoice = Console.ReadLine().ToLower(); //take user input and convert to lowercase

                Console.WriteLine($"{compChoice}");

                CompareHands(compChoice, userChoice);

                Console.WriteLine($"Press Y to play again, or any other key to Quit");

            }

            while (Console.ReadLine().ToLower() == "y");

        }

        static void CompareHands(int compChoice, string userChoice)
        {
            //TODO
            string win = "You Win!";
            string lose = "You Lose!";
            string tie = "You Tied!";

            int userHand = 0;
            switch (userChoice)
            {
                case "rock":
                    userHand = 1;
                    break;

                case "paper":
                    userHand = 2;
                    break;

                case "scissors":
                    userHand = 3;
                    break;

            }

            if (userHand == compChoice)
            {
                Console.WriteLine($"{tie}");
            }

            else if (userHand == 1 && compChoice == 2)
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 1 && compChoice == 3)
            {
                Console.WriteLine($"{win}");
            }

            else if (userHand == 2 && compChoice == 1)
            {
                Console.WriteLine($"{win}");
            }

            else if (userHand == 2 && compChoice == 3)
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 3 && compChoice == 1)
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 3 && compChoice == 2)
            {
                Console.WriteLine($"{win}");
            }

            else
            {
                Console.WriteLine($"Please enter the correct hand");
            }

        }
    }
}
