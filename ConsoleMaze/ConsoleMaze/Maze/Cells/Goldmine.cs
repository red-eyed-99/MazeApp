using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Goldmine : BaseCell
    {
        public int Durability { get; set; } = 3;

        public Goldmine(int x, int y, IMazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(IBaseCell unit)
        {
            Maze.Hero.Money++;
            Durability--;

            if (Durability == 0)
            {
                Maze.ReplaceCell(new Ground(X, Y, Maze));
            }

            return true;
        }
    }
}
