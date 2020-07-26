using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class Grid
    {
        public int CurrentGeneration { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(int rows, int columns, List<string> gridLines)
        {
            this.Rows = rows;
            this.Columns = columns;
            Cells = new Cell[Rows, Columns];
            this.FillGrid(gridLines);
        }

        private void FillGrid(List<string> gridLines)
        {
            var currentRow = 0;
            foreach (var gridLine in gridLines)
            {
                this.FeedLine(gridLine, currentRow);
                currentRow++;
            }
        }

        private void FeedLine(string gridLine, int row)
        {
            var cellColors = gridLine.ToCharArray().Select(x => x.ToString()).Select(int.Parse).ToList();
            for(int col = 0; col < cellColors.Count; col++)
            {
                var cellCoordinates = new CellCoordinates(row, col);
                this.Cells[row, col] = new Cell((CellColor)cellColors[col], cellCoordinates);
            }
        }

        //Green is 1, Red is 0
        public string VisualiseGrid()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    var colorInt = (int)this.Cells[row, col].CellColor;
                    sb.Append(colorInt.ToString());
                }
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        public string VisualiseGrid(string separator)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    var colorInt = (int)this.Cells[row, col].CellColor;
                    sb.Append(colorInt.ToString());
                }
                sb.Append(separator);
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        public void NextGeneration()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    this.Cells[row, col].Check(this.Cells);  
                }
            }

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    var cell = this.Cells[row, col];
                    if (cell.IsChanged == true) cell.ChangeColor();
                    cell.UpdateGenerationsWhereGreen();
                }
            }

            this.CurrentGeneration++;
        }
    }
}
