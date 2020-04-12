using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        private static string[,] Board;

        static void Main(string[] args)
        {
            CreateBoard();
            bool isPlaying = true;
            string playerLetter = "X";

            while (isPlaying)
            {
                PrintBoard();
                Console.WriteLine($"\n\nPlayer {playerLetter}. Choose your square.");
                string answer = Console.ReadLine();
                if (!int.TryParse(answer, out int number))
                {
                    Console.WriteLine("You did not pick a valid square. Press any key to try again");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (PlaceMark(answer, playerLetter))
                    {
                        PrintBoard();
                        if (HasWon(playerLetter))
                        {
                            Console.WriteLine($"\nPlayer {playerLetter} wins!");
                            if (PlayAgain())
                            {
                                continue;
                            }
                            else break;
                        }
                        else if (IsTie())
                        {
                            Console.WriteLine("\nNo winner.");
                            if (PlayAgain())
                            {
                                continue;
                            }
                            else break;
                        }
                        else
                        {
                            playerLetter = (playerLetter == "X") ? "O" : "X";
                        }

                    }
                    else
                    {
                        Console.WriteLine($"\nPlayer {playerLetter} cannot play there. Press any key to continue.");
                        Console.ReadKey();
                        continue;
                    }
                }
            }


        }

        private static void CreateBoard()
        {
            Board = new string[3, 3]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("\nDo you want to play again? Y/N");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain.Contains("Y"))
            {
                CreateBoard();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Board[i, j].Equals("X") && !Board[i, j].Equals("O"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsHorizontalWin(string playerLetter)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0].Contains(playerLetter) &&
                    Board[i, 0].Equals(Board[i, 1]) &&
                    Board[i, 1].Equals(Board[i, 2]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsVerticalWin(string playerLetter)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[0, i].Contains(playerLetter) &&
                    Board[0, i].Equals(Board[1, i]) &&
                    Board[1, i].Equals(Board[2, i]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDiagonalWin(string playerLetter)
        {
            if (Board[0, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[2, 2].Equals(playerLetter) ||
                Board[2, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[0, 2].Equals(playerLetter))
            {
                return true;
            }
            else return false;
        }

        private static bool HasWon(string playerLetter)
        {
            if (IsHorizontalWin(playerLetter) || IsVerticalWin(playerLetter) || IsDiagonalWin(playerLetter))
            {
                return true;
            }
            else return false;
        }

        private static bool PlaceMark(string square, string player)
        {
            string otherPlayer = (player == "X") ? "O" : "X";
            //find the selected square
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (Board[i, j].Equals(square) &&
                        (!Board[i, j].Equals(otherPlayer) || !Board[i, j].Equals(player)))
                    {
                        Board[i, j] = player;
                        return true;
                    }
                }
            }
            return false;
        }

        private static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t" + Board[i, 0] + " | " + Board[i, 1] + " | " + Board[i, 2]);
                if (i < 2)
                {
                    Console.WriteLine("\t----------");
                }
            }

        }


    }



}
