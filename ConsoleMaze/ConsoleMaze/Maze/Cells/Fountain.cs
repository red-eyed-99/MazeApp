using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Fountain : BaseCell
    {
        public Fountain(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep()
        {
            Maze.Hero.FatiguePoint--;
            Maze[X, Y] = new Ground(X, Y, Maze);
            return true;
        }
    }
}
