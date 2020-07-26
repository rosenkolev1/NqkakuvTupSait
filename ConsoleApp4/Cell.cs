using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class Cell
    {
        private List<CellCoordinates> neighboursCellCoordinates;

        public Cell(CellColor cellColor, CellCoordinates cellCoordinates)
        {
            this.CellColor = cellColor;
            this.CellCoordinates = cellCoordinates;
            this.neighboursCellCoordinates = new List<CellCoordinates>()
            {
                new CellCoordinates(this.CellCoordinates.Row - 1, this.CellCoordinates.Col - 1),
                new CellCoordinates(this.CellCoordinates.Row - 1, this.CellCoordinates.Col),
                new CellCoordinates(this.CellCoordinates.Row - 1, this.CellCoordinates.Col + 1),
                new CellCoordinates(this.CellCoordinates.Row, this.CellCoordinates.Col - 1),
                new CellCoordinates(this.CellCoordinates.Row, this.CellCoordinates.Col + 1),
                new CellCoordinates(this.CellCoordinates.Row + 1, this.CellCoordinates.Col - 1),
                new CellCoordinates(this.CellCoordinates.Row + 1, this.CellCoordinates.Col),
                new CellCoordinates(this.CellCoordinates.Row + 1, this.CellCoordinates.Col + 1),
            };
            this.GenerationsWhereGreen = this.CellColor == CellColor.Green ? 1 : 0;
        }

        public int GenerationsWhereGreen { get; set; }
        public bool IsChanged { get; set; }
        public CellColor CellColor { get; set; }
        public CellCoordinates CellCoordinates { get; set; }

        public void Check(Cell[,] cells)
        {
            if(this.CellColor == CellColor.Red)
            {
                this.IsChanged = RedCellCheck(cells);
            }
            else if (this.CellColor == CellColor.Green)
            {
                this.IsChanged = GreenCellCheck(cells);
            }
        }

        private bool RedCellCheck(Cell[,] cells)
        {
            int numberOfGreenNeighbours = 0;

            foreach (var cellCoordinates in this.neighboursCellCoordinates.Where(x => x.InBounds(cells)))
            {
                var neighbourCell = cells[cellCoordinates.Row, cellCoordinates.Col];
                if (neighbourCell.CellColor == CellColor.Green) numberOfGreenNeighbours++;
            }
            return numberOfGreenNeighbours == 3 || numberOfGreenNeighbours == 6;
        }

        private bool GreenCellCheck(Cell[,] cells)
        {
            int numberOfGreenNeighbours = 0;

            foreach (var cellCoordinates in this.neighboursCellCoordinates.Where(x => x.InBounds(cells)))
            {
                var neighbourCell = cells[cellCoordinates.Row, cellCoordinates.Col];
                if (neighbourCell.CellColor == CellColor.Green) numberOfGreenNeighbours++;
            }
            return !(numberOfGreenNeighbours == 2 || numberOfGreenNeighbours == 3 || numberOfGreenNeighbours == 6);
        }

        public void ChangeColor()
        {
            if (this.CellColor == CellColor.Red) this.CellColor = CellColor.Green;
            else if (this.CellColor == CellColor.Green) this.CellColor = CellColor.Red;
        }

        public void UpdateGenerationsWhereGreen()
        {
            if(this.CellColor == CellColor.Green) this.GenerationsWhereGreen++;
        }
    }
}