using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public abstract class BaseEnemy : BaseCell
    {
        public Random random = new Random();

        public int HealthPoint { get; set; }

        public bool DealsDamage { get; set; }

        public BaseEnemy(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public abstract void Step();
        
    }
}
