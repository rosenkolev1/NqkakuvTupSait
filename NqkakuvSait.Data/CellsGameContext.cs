using Microsoft.EntityFrameworkCore;
using NqkakuvSait.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NqkakuvSait.Data
{
    public class CellsGameContext : DbContext
    {
        public CellsGameContext()
        {

        }
        public CellsGameContext(DbContextOptions<CellsGameContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<CellsGameDataModel> CellGameDataJson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=.;Database=CellGame;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
