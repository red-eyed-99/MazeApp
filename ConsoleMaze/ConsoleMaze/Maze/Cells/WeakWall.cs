using ConsoleMaze.Maze.Cells.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class WeakWall : BaseCell
    {
        public int Durability { get; set; } = 3;

        public WeakWall(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            if (unit is WallWorm)
            {
                return true;
            }

            if (unit is Hero)
            {
                Maze.Message = "boom";
                Durability--;
            }

            if (Durability == 0)
            {
                Maze[X, Y] = new Ground(X, Y, Maze);
            }

            return false;
        }
    }
}
