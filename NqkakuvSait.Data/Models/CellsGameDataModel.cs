using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NqkakuvSait.Data.Models
{
    public class CellsGameDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JsonData { get; set; }
    }
}
