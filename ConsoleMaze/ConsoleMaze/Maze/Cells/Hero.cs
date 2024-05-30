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

        public Hero(int x, int y, MazeLevel maze) : base(x , y, maze) { }

        public override bool TryToStep()
        {
            throw new NotImplementedException();
        }
    }
}
