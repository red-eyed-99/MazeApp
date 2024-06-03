using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class WolfPit : BaseCell
    {
        public WolfPit(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep()
        {
            if (Maze.Hero.HealthPoint > 0)
            {
                Maze.Hero.HealthPoint--; 
            }
            Maze[X, Y] = new Ground(X, Y, Maze);
            return true;
        }
    }
}
