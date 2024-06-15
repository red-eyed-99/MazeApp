using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Trap : BaseCell
    {
        public Trap(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            if (Maze.Hero.HealthPoint > 0)
            {
                Maze.Hero.HealthPoint--;
            }

            Maze.ReplaceCell(new Ground(X, Y, Maze));

            return true;
        }
    }
}
