using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Bed : BaseCell
    {
        public Bed(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(IBaseCell unit)
        {
            Maze.Hero.FatiguePoint = 0;
            Maze[X, Y] = new Ground(X, Y, Maze);
            return true;
        }
    }
}
