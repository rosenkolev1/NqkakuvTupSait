using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NqkakuvSait.Core.Models
{
    public class CellsGameViewModel
    {
        public Grid FinalGrid { get; set; }
        public List<string> Grids { get; set; }
        public int targetCellRow { get; set; }
        public int targetCellCol { get; set; }
    }
}
