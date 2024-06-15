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

        public override bool TryToStep(IBaseCell unit)
        {
            return false;
        }
    }
}
