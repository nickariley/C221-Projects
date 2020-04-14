using System;
using System.Collections.Generic;//unused

namespace TicTacToe
{
    class Program
    {
        private static string[,] Board;

        static void Main(string[] args)
        {
            CreateBoard(); //create 2D array board
            bool isPlaying = true; //Hard Code isPlaying to true to begin game
            string playerLetter = "X"; //Hard Code playerLetter X to being game

            while (isPlaying)
            {
                PrintBoard(); //Print the board to console
                Console.WriteLine($"\n\nPlayer {playerLetter}. Choose your square."); //Ask the user to pick a square to play in
                string answer = Console.ReadLine(); //Create a string named answer to return user input
                if (!int.TryParse(answer, out int number)) //If an integer between 1-9 was not passed into answer do the following code
                {
                    Console.WriteLine("You did not pick a valid square. Press any key to try again");
                    Console.ReadKey();
                    continue; //this will return user to pick a square again
                }
                else
                {
                    if (PlaceMark(answer, playerLetter)) // Else if user choice was valid check the method placemark for the current answer and current playerletter.
                    {
                        PrintBoard(); //once Placemark method has finished comes back Prints the Board and checks the following:
                        if (HasWon(playerLetter)) // Check HasWon method with current playerLetter
                        {
                            Console.WriteLine($"\nPlayer {playerLetter} wins!"); //If HasWon returns true 
                            if (PlayAgain()) //If HasWon returns true check PlayAgain method.
                            {
                                continue; //fall out of method
                            }
                            else break; // break out and go to next else if 
                        }
                        else if (IsTie()) //if haswon was not true, check IsTie method
                        {
                            Console.WriteLine("\nNo winner."); //if IsTie  is true write no winner and ask to play again
                            if (PlayAgain()) //checks PlayAgain method if user inputs y then continue 
                            {
                                continue;
                            }
                            else break; //else if not a tie break out and go to next else statement
                        }
                        else //if not a tie and no one has won switch player letter, if player is X then switch to O else if player is O switch to X and start back to the while loop isPlaying.
                        {
                            playerLetter = playerLetter == "X" ? "O" : "X";
                        }

                    }
                    else //catch all statement for invalid play 
                    {
                        Console.WriteLine($"\nPlayer {playerLetter} cannot play there. Press any key to continue.");
                        Console.ReadKey();
                        continue; //goes back to while loop and asks user for input string answer
                    }
                }
            }


        }

        private static void CreateBoard() //Create 2D Array, CreateBoard is placed in the entry point of the main method to start the game.
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
            string playAgain = Console.ReadLine().ToUpper(); //takes user input and converts to upper case for comparison
            if (playAgain.Contains("Y")) //if user enters y or Y then go to CreateBoard method and return true to exit playagain method, else return false and end program.
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
                for (int j = 0; j < 3; j++) //nested for loop for iterating over all the numbers of board
                {
                    if (!Board[i, j].Equals("X") && !Board[i, j].Equals("O")) //checks to see if the board does not have an X or an O in any spot, if a spot is not filled return false, else if all spots are taken return true.
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
                if (Board[i, 0].Contains(playerLetter) && //if spot 0,0 1,0 or 2,0 has a playerletter and (i is iterating up the rows and 0,1&2 are the column spots within that row.
                    Board[i, 0].Equals(Board[i, 1]) && //if spot 0,0 1,0 or 2,0 equals the same playerletter as whichever iteration it is on and the ,1 and ,2 spots for that iteration are equal.
                    Board[i, 1].Equals(Board[i, 2])) //if all three spots are equal return true else return false and break out.
                {//essentially it checks if 0,0 is equal to 0,1 and if 0,1 is equal to 0,2 same with rows 1 and 2.
                    return true;//if true execute 
                }
            }
            return false;//else break out and continue
        }

        private static bool IsVerticalWin(string playerLetter)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[0, i].Contains(playerLetter) && //same as horizontal but instead of iterating over the rows, this time we iterate over the columns and check 
                    Board[0, i].Equals(Board[1, i]) && // if row 0 column 0  equals row 1 column 0 and
                    Board[1, i].Equals(Board[2, i])) //if row 1 column 0 equal row 2 column 0 return true, else false and iterate to column 1 then column 2 if still false after iterating break out unless true returns.
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDiagonalWin(string playerLetter) //hard coded since only 2 options
        {
            if (Board[0, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[2, 2].Equals(playerLetter) || //top left, middle and bottom right equal or
                Board[2, 0].Equals(playerLetter) && Board[1, 1].Equals(playerLetter) && Board[0, 2].Equals(playerLetter)) // bottom left, middle and top right equal
            {
                return true;
            }
            else return false;
        }

        private static bool HasWon(string playerLetter) //a method that each of the three methods to see if any 1 of them is true, if one returns true if finishes without having to go through all three of them.
        {
            if (IsHorizontalWin(playerLetter) || IsVerticalWin(playerLetter) || IsDiagonalWin(playerLetter))
            {
                return true;
            }
            else return false;
        }

        private static bool PlaceMark(string square, string player) //arguments string square and string player used to pass parameters and check if a mark has been placed in square
        {
            string otherPlayer = (player == "X") ? "O" : "X"; //If player equals X then switch to O else if player is O switch to X  and store value in otherPlayer.
            //find the selected square
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++) //nested for loop for iterating through 2d Array
                {
                    if (Board[i, j].Equals(square) && //if the board = a valid square and
                        (!Board[i, j].Equals(otherPlayer) || !Board[i, j].Equals(player))) //if the board does not already equal the other players mark or if the board does not equal the current player mark.
                    {
                        Board[i, j] = player; //then assign player value to board square.
                        return true; //and return true to fall out of method.
                    }
                }
            }
            return false; // else false to continue
        }

        private static void PrintBoard() //Printing the board to the console window.
        {
            Console.Clear(); //clear existing text on the console to clean it up.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t" + Board[i, 0] + " | " + Board[i, 1] + " | " + Board[i, 2]);//on first run through i = 0 this works in conjunction with the values passed to board in create board and is merely saying print the value in each position of the 2D array. + | for visual lines + \t for indention
                if (i < 2) //if the value is less that 2 print a horizontal line but not 3 we only want 2 lines for tictactoe.
                {
                    Console.WriteLine("\t----------");
                }
            }

        }


    }



}
