using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public struct Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public enum Color { White, Black }

    public class Checker
    {
        public String Symbol { get; private set; }
        public Color PlayerColor { get; private set; }
        public Position Position { get; set; }

        public Checker(Color playerColor, int row, int col)
        {
            this.PlayerColor = playerColor;
            this.Position = new Position(row, col);
            SetTeam(playerColor);

        }

        private void SetTeam(Color checkerColor)
        {
            if (checkerColor == Color.Black)
            {
                var black = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                this.Symbol = char.ConvertFromUtf32(black);
            }
            else
            {
                var white = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                this.Symbol = char.ConvertFromUtf32(white);
            }
        }
    }
}
