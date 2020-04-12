using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {

                Random random = new Random(); //instantiate generate a random hand for computer
                int compChoice = random.Next(1, 4); //call random and store it in compChoice 

                Console.WriteLine("Enter Rock, paper or scissors!"); //ask user for hand => 1, 2, 3 or Rock Paper Scissors
                string userChoice = Console.ReadLine().ToLower(); //take user input and convert to lowercase

                Console.WriteLine($"{compChoice}"); //write what random number computer chose to screen

                CompareHands(compChoice, userChoice); //calling CompareHands method with the arguments CompChoice and userChoice

                Console.WriteLine($"Press Y to play again, or any other key to Quit");

            }

            while (Console.ReadLine().ToLower() == "y"); //while loop to continue game if y is entered after do is executed each time.

        }

        static void CompareHands(int compChoice, string userChoice) //method to compare the int compChoice to the String userChoice using a switch statement to switch the string given to an integer for comparison.
        {
            //TODO
            string win = "You Win!"; //storing win lose tie messages for easier use.
            string lose = "You Lose!";
            string tie = "You Tied!";

            int userHand = 0; //initialize an int for userHand
            switch (userChoice) //switch whatever value user entered from userChoice to the following. 
            {
                case "rock": //if userChoice was string rock, create userHand with value 1
                    userHand = 1;
                    break;

                case "paper"://if userChoice was paper create userHand with value 2
                    userHand = 2;
                    break;

                case "scissors":// if userChoice was scissors create userHand with value 3
                    userHand = 3;
                    break;

            } //after this runs if the user picked rock, paper or scissors userhand will store 1, 2 or 3 then be compared below using userHand instead of userChoice.

            if (userHand == compChoice) // if same value tie.
            {
                Console.WriteLine($"{tie}");
            }

            else if (userHand == 1 && compChoice == 2) // if user equals 1"rock" and Comp equals 2"paper" lose
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 1 && compChoice == 3) //if user equals 1"rock" and comp equals 3"scissors" win
            {
                Console.WriteLine($"{win}");
            }

            else if (userHand == 2 && compChoice == 1) // if user equals 2"paper" and comp equals 1"rock" win
            {
                Console.WriteLine($"{win}");
            }

            else if (userHand == 2 && compChoice == 3) // if user equals 2"paper" and comp equals 3"scissors" lose
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 3 && compChoice == 1) // if user equals 3"scissors" and comp equals 1"rock" lose
            {
                Console.WriteLine($"{lose}");
            }

            else if (userHand == 3 && compChoice == 2) // if user equals 3"scissors" and comp equals 2"paper" win
            {
                Console.WriteLine($"{win}");
            }

            else //catch bad user input and ask to enter correct hand
            {
                Console.WriteLine($"Please enter the correct hand"); 
            }

        }
    }
}
