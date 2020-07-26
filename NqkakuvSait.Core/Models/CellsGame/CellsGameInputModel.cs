using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NqkakuvSait.Core.Models.CellsGame
{
    public class CellsGameInputModel
    {
        //TODO: Validation via data annotations
        public int GridRows { get; set; }
        public int GridColumns { get; set; }
        public string GridLines { get; set; }
        public int CountOfGenerations { get; set; }
        public int TargetCellRow { get; set; }
        public int TargetCellCol { get; set; }
    }
}
