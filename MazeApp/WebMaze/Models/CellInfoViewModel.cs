using Microsoft.AspNetCore.Mvc;

namespace WebMaze.Models
{
    public class CellInfoViewModel
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool CanStep { get; set; }
    }
}
