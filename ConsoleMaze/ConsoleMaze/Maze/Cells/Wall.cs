using ConsoleMaze.Maze.Cells.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            if (unit is WallWorm)
            {
                return true;
            }

            return false;
        }
    }
}
