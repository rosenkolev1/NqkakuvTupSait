using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var gridDimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var gridX = gridDimensions[0];
            var gridY = gridDimensions[1];
            var gridLines = new List<string>();
            for (int y = 0; y < gridY; y++)
            {
                var gridLine = Console.ReadLine();
                gridLines.Add(gridLine);
            }
            var grid = new Grid(gridX, gridY, gridLines);


            var targetCellCoordinates = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var targetCellCol = targetCellCoordinates[0];
            var targetCellRow = targetCellCoordinates[1];
            var generations = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Old Grid " + new string('-', 20));
            Console.WriteLine(grid.VisualiseGrid());
            for (int i = 0; i < generations; i++)
            {
                grid.NextGeneration();
                Console.WriteLine();
                Console.WriteLine($"New Grid in generation({grid.CurrentGeneration}) " + new string('-', 20));
                Console.WriteLine(grid.VisualiseGrid());
            }

            Console.WriteLine($"Number of times the cell at coordinates ({targetCellRow} ; {targetCellCol}) has changed colour: {grid.Cells[targetCellRow, targetCellCol].GenerationsWhereGreen}");
        }
    }
}
