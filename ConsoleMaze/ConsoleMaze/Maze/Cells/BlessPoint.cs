using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class BlessPoint : BaseCell
    {
        public BlessPoint(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            Maze.Hero.HealthPoint = Maze.Hero.MaxHealth;

            return true;
        }
    }
}
