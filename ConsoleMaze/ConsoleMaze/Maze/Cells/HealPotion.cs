using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class HealPotion : BaseCell
    {
        public HealPotion(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep()
        {
            if (Maze.Hero.HealthPoint < Maze.Hero.MaxHealth)
            {
                Maze.Hero.HealthPoint++;
                Maze[X, Y] = new Ground(X, Y, Maze);
            }
            
            return true;
        }
    }
}
