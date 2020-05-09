using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public class Board
    {
        public List<Checker> _checkers;
        public Board()
        {
            _checkers = new List<Checker>();
            for (int r = 0; r < 3; r++) //used with the following 2 for statements in order to print the 1st 3 rows of checkers, then rows 5, 6 & 7 by calling 5 + r
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    _checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                    _checkers.Add(c);
                }
            }
        }

        public Checker GetChecker(Position pos)
         {
            Checker found = null;
            foreach (Checker checker in _checkers)
            {
                if (pos.Equals(checker.Position))
                {
                    found = checker;
                    break;
                }
            }
            return found;
        }

         public void RemoveChecker(Checker checker)
         {
            foreach (Checker item in _checkers)
            {
                if (item.Equals(checker))
                {
                    _checkers.Remove(item);
                    break;
                }
            }
        }

         public void MoveChecker(Checker checker, Position dest)
         {
            _checkers.Remove(checker);
            checker.Position = dest;
            _checkers.Add(checker);
         }

        public int CountCheckers(Color color)
        {
            int count = 0;
            foreach (Checker checker in _checkers)
            {
                if (checker.PlayerColor == color)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
