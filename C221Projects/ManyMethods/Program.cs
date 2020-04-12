using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Globalization;

namespace Many_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            Hello();
            Addition();
            CatDog();
            OddEvent();
            Inches();
            Echo();
            KillGrams();
            Date();
            Age();
            Guess();
        }

        static void Hello()
        {
            string name;
            Console.WriteLine("Hello, What is your name?\n");
            name = Console.ReadLine();
            Console.WriteLine($"\nBye { name }!");
            Console.ReadLine();
        }

        static void Addition()
        {
            Console.WriteLine("Please enter a number: \n");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nPlease enter a second number: \n");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nThe sum of the two numbers is: {a + b}\n", (a + b));
            Console.ReadLine();

        }

        /*static void CatDog()
        {
            Console.WriteLine("If you prefer Cats over Dogs enter 1:\n");
            Console.WriteLine("If you prefer Dogs over Cats enter 2:\n");

            int answer1 = Convert.ToInt32(Console.ReadLine());
            if (answer1 == 1)
            {
                Console.WriteLine("\nMeow Meow Meow Meow!\n");
            }
            else if (answer1 == 2)
            {
                Console.WriteLine("\nWho let the Dogs out?! Woof, Woof Woof Woof Woof!\n");
            }
            else
            {
                Console.WriteLine("\nYour Choice was invalid!\n");
            }
            Console.ReadLine();

        }*/

        static void CatDog()
        {
            string DOGS = "DOGS";
            string CATS = "CATS";

            Console.WriteLine("\nDo you prefer Dogs or Cats?\n");

            string answer = Console.ReadLine()/*.ToUpper()*/;
            string answerUpper = answer.ToUpper();

            if (answerUpper == DOGS)
            {
                Console.WriteLine("\nWho let the Dogs out?! Woof, Woof Woof Woof Woof!\n");
            }
            else if (answerUpper == CATS)
            {
                Console.WriteLine("\nMeow Meow Meow Meow!\n");
            }
            else
            {
                Console.WriteLine("\nYour answer was invalid\n");
            }
            Console.ReadLine();

        }

        static void OddEvent()
        {
            int i;
            Console.WriteLine("Please enter any positive number of your choosing and I will tell you if it is Odd or Even!\n");
            i = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                Console.WriteLine("\nThe number you entered is even!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nThe number you entered is odd!");
                Console.ReadLine();
            }
        }

        static void Inches()
        {
            int i;
            Console.WriteLine("How many Feet Tall are you?\n");
            i = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nYou are at least { i * 12 } inches tall!");
            Console.ReadLine();
        }

        static void Echo()
        {

            Console.WriteLine("What is your favorite Word?!\n");
            string favWord = Console.ReadLine();
            string favWordUpper = favWord.ToUpper();
            string favWordLower = favWord.ToLower();
            Console.WriteLine($"\n{ favWordUpper } { favWordUpper } { favWordUpper } { favWordLower } { favWordLower }\n");
            Console.ReadLine();
        }

        static void KillGrams()
        {
            Console.WriteLine("How many pounds do you weigh? (Sorry Ladies not very GentlemenLike of me)");
            double i = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"\n{ i } Pounds is the equivalent to { i * 0.453592 } Kilograms!");
            Console.ReadLine();
        }

        static void Date()
        {
            Console.WriteLine($"The Current Date and Time is: { DateTime.Now }\n");
            Console.ReadLine();
        }

        static void Age()
        {
            int birthYear;
            var today = DateTime.Now;
            Console.WriteLine("\nPlease enter the year you were born:\n ");
            birthYear = int.Parse(Console.ReadLine());
            var age = today.Year - birthYear;
            var age2 = today.Year - birthYear - 1;
            //Console.WriteLine("\nIf you have already celebrated your birthday you are " + age + " years old! If you have not celebrated your Birthday yet, then you are " + age2 + "!\n");
            Console.WriteLine($"\nIf you have already celebrated your birthday you are { age } years old! If you have not celebrated your Birthday yet, then you are { age2 } years old!\n");
            Console.ReadLine();
        }

        static void Guess()
        {
            string secretWord = "CSHARP";

            Console.WriteLine("\nGuess what word I'm thinking of: \n");

            string guess = Console.ReadLine();
            string guessUpper = guess.ToUpper();

            if (guessUpper == secretWord)
            {
                Console.WriteLine("\nCORRECT!!\n");
            }
            else if (guessUpper != secretWord)
            {
                Console.WriteLine("\nWRONG!!\n");
            }
            Console.ReadLine();

        }

    }
}
