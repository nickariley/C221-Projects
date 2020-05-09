using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public class Game
    {
        private Board _board;
        private Color _playerColor = Color.Black;
        bool _isPlaying = true;

        public Game()
        {
            this._board = new Board();
        }

        public void Start()
        {
            

            while (_isPlaying)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Enter coordinates for the checker you wish to move EX: 1,1");
                string[] fromPostition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var resultPosition = ProcessInput(fromPostition);
                Console.WriteLine("Enter coordinates for the destination you wish to move to EX: 0,0");
                string[] toPosition = Console.ReadLine().ToString().Substring(0, 3).Split(',');
                var result2Position = ProcessInput(toPosition);


                Position src = resultPosition;
                Position dest = result2Position;
                Checker checker = _board.GetChecker(src);

                //Console.WriteLine($"{fromPostition} {toPosition}"); //is a string test
                //Console.WriteLine($"{resultPosition} {result2Position}"); //is a position test

                if (IsLegalMove(checker.PlayerColor, src, dest))
                {
                    if (IsCapture(src, dest))
                    {
                        _board.RemoveChecker(GetCaptureChecker(src, dest));
                        _board.MoveChecker(checker, dest);
                    }
                    else
                    {
                        _board.MoveChecker(checker, dest);
                    }

                    // Use a ternary to determine next player
                    // If _player == Black, set _player to White, else set _player to Black
                }
                else
                {
                    Console.WriteLine("\nInvalid move.  Press any key to try again.");
                    Console.ReadKey();
                }

                if (CheckForWin())
                {
                    _isPlaying = false;
                    Console.WriteLine($"Player {_playerColor} wins!");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }

        }

        public bool IsLegalMove(Color player, Position source, Position destination)
        {
            //These check that the destination is on the board
            //Both the source position and the destination position must be integers between 0 and 7
            if (source.Row < 0 || source.Row > 7 || source.Col < 0 || source.Col > 7
                || destination.Row < 0 || destination.Row > 7 || destination.Col < 0
                || destination.Col > 7) return false;

            //The row distance between the destination position and the source position must be larger than 0 AND less than or equal to 2
            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Col - source.Col);

            //Checks to make sure that the checker cannot move in a straight line.
            if (colDistance == 0 || rowDistance == 0) return false;

            //Checks the diagonal of the checker.
            if (rowDistance / colDistance != 1) return false;

            //Checks that destination is not further than 2 rows.
            if (rowDistance > 2) return false;

            //These check for Checkers in source and destination
            Checker c = _board.GetChecker(source);

            //Checks if there is a checker at the source position
            if (c == null)
            {
                return false;
            }

            c = _board.GetChecker(destination);
            //Checks if there's a checker at the destination
            if (c != null)
            {
                return false;
            }
            // If we get here, that means the source position has a checker AND the destination position is empty AND destination.Row != source.Row AND destination.Column != source.Destination
            //Checks that a jump is valid by calling IsCapture. If IsCapture is true, then the jump is true.  
            if (rowDistance == 2)
            {
                if (IsCapture(source, destination))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool IsCapture(Position source, Position destination)
        {

            int rowDistance = Math.Abs(destination.Row - source.Row);
            int colDistance = Math.Abs(destination.Col - source.Col);

            if (rowDistance == 2 && colDistance == 2)
            {
                //Finds the middle square
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Col + source.Col) / 2;

                //Hold onto that spot
                Position p = new Position(row_mid, col_mid);

                //Grab the the middle checker
                Checker c = _board.GetChecker(p);

                //Get that jumping checker
                Checker player = _board.GetChecker(source);

                //no checker to jump
                if (c == null)
                {
                    return false;
                }
                else
                {
                    //make sure you're not jumping you're own checker
                    if (c.PlayerColor == player.PlayerColor)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public Checker GetCaptureChecker(Position source, Position destination)
        {
            if (IsCapture(source, destination))
            {
                // there must be a piece in the middle of the source and the destination
                int row_mid = (destination.Row + source.Row) / 2;
                int col_mid = (destination.Col + source.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = _board.GetChecker(p);
                return c;
            }
            return null;

        }

        public Position ProcessInput(string[] userMove)
        {

            int row;
            int col;
            if (!int.TryParse(userMove[0], out row))
            {
                Console.WriteLine("illegal move");
                return new Position(0, 0);
            }
            if (!int.TryParse(userMove[1], out col))
            {
                Console.WriteLine("illegal move");
                return new Position(0, 0);
            }
            return new Position(row, col);

        }

        public void DrawBoard()
        {
            String[][] grid = new String[8][];
            for (int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for (int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach (Checker c in _board._checkers)
            {
                grid[c.Position.Row][c.Position.Col] = c.Symbol;
            }

            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int r = 0; r < 8; r++)
            {
                Console.Write(r); //prints the row number based on iteration of r so this prints 0-7 row markers.
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(" {0}", grid[r][c]);
                }
                Console.WriteLine();
            }
        }

        private bool CheckForWin()
        {
            int white = _board.CountCheckers(Color.White);
            if (white == 0)
            {
                _playerColor = Color.Black;
                return true;
            }

            int black = _board.CountCheckers(Color.Black);
            if (black == 0)
            {
                _playerColor = Color.White;
                return true;
            }

            return false;
        }
    }
}
