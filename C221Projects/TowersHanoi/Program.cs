using System;
using System.Collections.Generic;

namespace TowersHanoi
{
    class Program
    {
        private static Dictionary<string, Stack<int>> board = new Dictionary<string, Stack<int>>();

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(); //Create empty stack
            stack.Push(4);//push 4,3,2,1, on stack these will be the values for the dictionary
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            board.Add("A", stack); //add the stack we created to board dictionary and assign A as the key
            board.Add("B", new Stack<int>()); //add empty stack to board dictionary and assign B as the key
            board.Add("C", new Stack<int>()); //add empty stack to board dictionary and assign C as the key

            do
            {
                Console.Clear(); //start of game printboard ask for input, each time a move is successful clear and reprint board and ask again until win.
                PrintBoard();
                Console.WriteLine("Enter Tower to move FROM:");
                string from = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter Tower to move To:");
                string to = Console.ReadLine().ToUpper();

                try
                {
                    if (IsMoveValid(from, to)) //if move is valid returns trye
                    {
                        board[to].Push(board[from].Pop()); //push to board to pop from board from
                    }
                    else
                    {
                        Console.WriteLine("Invalid Move."); //if move is not allowed or returns false
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                    }
                } 
                catch (Exception) // catch invalid entries
                {
                    Console.WriteLine("Invalid Entry");
                    Console.ReadKey();
                }

            }
            while (!CheckWin()); //do above while checkwin is not true

            Console.Clear(); //when check win returns true, clear console, print board and winning message
            PrintBoard();
            Console.WriteLine("You Won!");
            Console.ReadKey();
        }

        private static bool CheckWin()
        {
            if (board["C"].Count == 4) // if all 4 values are on stack C
            {
                return true;
            }
            return false; //if all 4 pieces are not then cannot be a win.
        }

        private static void PrintBoard()
        {
            foreach (var item in board)
            {
                Console.WriteLine($"\n{item.Key}: ");
                var numbers = item.Value.ToArray();

                for (int i = numbers.Length; i > 0; i--) // use reverse for loop to print values in array
                {
                    Console.Write(numbers[i - 1] + " "); //index -1 to print backwards or it will not print current iteration when in reverse.
                }
                Console.WriteLine();
            }

            
        }

        private static bool IsMoveValid(string from, string to)//use following logic to evaluate move based on user input string from and to
        {
            if (board[from].Count == 0)// board from has to have at least 1 value to move
            {
                return false;
            }
            else if (board[to].Count !=0)//if board stack to has a value
            {
                if (board[to].Peek() > board[from].Peek())//is to greater than from?
                {
                    return true; //if to is greater return true
                }
                return false; //if to is less than return false
                
            }
            else
            {
                return true; //returns true if there is no value in the to stack on board.
            }
        }
    }
}
