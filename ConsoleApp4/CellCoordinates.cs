using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class CellCoordinates
    {
        public CellCoordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }

        public bool InBounds(Cell[,] cells)
        {
            var inBoundsLength = this.Col >= 0 && this.Col < cells.GetLength(1);
            var inBoundsWidth = this.Row >= 0 && this.Row < cells.GetLength(0);
            return inBoundsLength && inBoundsWidth;
        }
    }
}
