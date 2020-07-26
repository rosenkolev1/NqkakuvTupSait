using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NqkakuvSait.Core.Models;
using NqkakuvSait.Core.Models.CellsGame;
using NqkakuvSait.Data;
using NqkakuvSait.Data.Models;

namespace NqkakuvSait.Core.Controllers
{
    public class CellsGameController : Controller
    {
        private readonly CellsGameContext context;
        public CellsGameController(CellsGameContext cellsGameContext)
        {
            this.context = cellsGameContext;
        }
        // GET: PlayCellsGameController
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CellsGameInputModel cellsGameInputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }
            this.context.CellGameDataJson.Add(new CellsGameDataModel() { JsonData= JsonSerializer.Serialize(cellsGameInputModel) });
            this.context.SaveChanges();
            return this.RedirectToAction("Result", "CellsGame");
        }

        public ActionResult Result()
        {
            CellsGameViewModel cellsGameViewModel = null;
            try
            {
                var cellsGameInputModelJson = this.context.CellGameDataJson.OrderByDescending(x => x.Id).FirstOrDefault().JsonData;
                var cellsGameInputModel = JsonSerializer.Deserialize<CellsGameInputModel>(cellsGameInputModelJson);
                var grid = new Grid(cellsGameInputModel.GridRows, cellsGameInputModel.GridColumns, cellsGameInputModel.GridLines.Split(";").ToList());
                if(cellsGameInputModel.TargetCellRow < 0 ||
                    cellsGameInputModel.TargetCellRow >= cellsGameInputModel.GridRows ||
                    cellsGameInputModel.TargetCellCol < 0 ||
                    cellsGameInputModel.TargetCellRow >= cellsGameInputModel.GridColumns)
                {
                    throw new Exception("Pi4, poziciite tuka sa kato v programiraneto. A ti si kazal da sledq kletka izvun grid-a. Opravi si gre6kata 4e ma drazni6");
                }
                var gridCells = new List<string>();
                for (int i = 0; i < cellsGameInputModel.CountOfGenerations; i++)
                {
                    grid.NextGeneration();
                    gridCells.Add(grid.VisualiseGrid(";"));
                }
                cellsGameViewModel = new CellsGameViewModel()
                {
                    FinalGrid = grid,
                    targetCellCol = cellsGameInputModel.TargetCellCol,
                    targetCellRow = cellsGameInputModel.TargetCellRow,
                    Grids = gridCells,
                };
            }
            catch (Exception ex)
            {
                var errorViewModel = new ServerSideCellGameErroViewModel() { ErrorMessage = ex.Message, AdditionalDescription = "Ne6to izgurmq v CellGameController vuv Result(). Ina4e kazano, ne6to si osral kato si vuvejdal grid-a. Probvai pak." };
                return View("Error",errorViewModel);
            }
            return View(cellsGameViewModel);
        }
    }
}
