using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class GreedyHealer : BaseCell
    {
        public GreedyHealer(int x, int y, IMazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(IBaseCell unit)
        {
            if (Maze.Hero.HealthPoint < Maze.Hero.MaxHealth && Maze.Hero.Money > 1)
            {
                Maze.Hero.HealthPoint = Maze.Hero.MaxHealth;
                Maze.Hero.Money = Maze.Hero.Money / 2;
                Maze.ReplaceCell(new Ground(X, Y, Maze));
            }

            return true;
        }
    }
}
