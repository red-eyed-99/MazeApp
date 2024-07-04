using Microsoft.AspNetCore.Mvc;
using ConsoleMaze.Maze;

namespace WebMaze.Controllers
{
    public class MazeController : Controller
    {
        public IActionResult Index(int width, int height)
        {
            var mazeBuilder = new MazeBuilder();
            var maze = mazeBuilder.Build(width, height);
            return View(maze);
        }
    }
}
