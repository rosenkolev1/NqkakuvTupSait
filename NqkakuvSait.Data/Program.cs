using System;

namespace NqkakuvSait.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CellsGameContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
