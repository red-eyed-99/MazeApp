using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class TeleportIn : BaseCell
    {
        public TeleportOut TeleportOut { get; set; }

        public TeleportIn(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            if (unit is Hero)
            {
                Maze.Hero.X = TeleportOut.X;
                Maze.Hero.Y = TeleportOut.Y;
            }

            return true;
        }
    }
}
