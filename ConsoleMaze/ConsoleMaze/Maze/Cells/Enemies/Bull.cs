using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class Bull : BaseEnemy
    {
        private Random random = new Random();

        public Bull(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep()
        {
            throw new NotImplementedException();
        }

        public override void Step()
        {

        }
    }
}
