using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Tavern : BaseCell
    {
        public Tavern(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep()
        {
            if (Maze.Hero.Money >= 2 && Maze.Hero.FatiguePoint > 0)
            {
                Maze.Hero.Money -= 2;
                Maze.Hero.FatiguePoint -= 5;
                Maze[X, Y] = new Ground(X, Y, Maze);
            }

            return true;
        }
    }
}
