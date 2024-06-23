using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Puddle : BaseCell
    {
        public Puddle(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(IBaseCell unit)
        {
            if (unit is Hero)
            {
                Maze.Message = "wap wap";
            }
            return true;
        }
    }
}
