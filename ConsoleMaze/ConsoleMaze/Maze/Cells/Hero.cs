using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Hero : BaseCell
    {
        public int Money { get; set; }

        public int HealthPoint { get; set; }

        public Hero(int x, int y, MazeLevel maze, int heroHealth) : base(x, y, maze)
        {
            HealthPoint = heroHealth;
        }

        public override bool TryToStep()
        {
            throw new NotImplementedException();
        }
    }
}
