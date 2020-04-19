using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();
            string answer = string.Empty;
            do
            {

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Enter student name.");

                Console.ForegroundColor = ConsoleColor.White;

                name = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Enter student's grades");

                Console.ForegroundColor = ConsoleColor.White;

                string grades = Console.ReadLine();

                gradeBook.Add(name, grades);

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Do you want to add another student? Y/N.");

                Console.ForegroundColor = ConsoleColor.White;

                answer = Console.ReadLine().ToLower();

                Console.Clear();

            }
            while (answer.Equals("y"));


            int lowestGrade = 0;
            int highestGrade = 0;
            double average = 0.00;

            foreach (var item in gradeBook)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{item.Key}\n");

                try
                {
                    int[] individualGrades = Array.ConvertAll<string, int>(gradeBook[item.Key].Split(), Convert.ToInt32);
                    lowestGrade = individualGrades.Min();
                    highestGrade = individualGrades.Max();
                    average = individualGrades.Average();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry");
                }

                Console.WriteLine($"Highest grade = {highestGrade} Lowest grade = {lowestGrade} Average = {average}\n");
            }
            Console.ReadKey();
        }
    }
}
