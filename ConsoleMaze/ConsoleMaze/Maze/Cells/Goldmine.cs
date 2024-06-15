using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Goldmine : BaseCell
    {
        int Durability { get; set; } = 3;

        public Goldmine(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            Maze.Hero.Money++;
            Durability--;

            if (Durability == 0)
            {
                Maze[X, Y] = new Ground(X, Y, Maze);
            }

            return true;
        }
    }
}
