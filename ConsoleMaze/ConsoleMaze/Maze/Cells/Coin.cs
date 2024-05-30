using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Coin : BaseCell
    {
        public Coin(int x, int y, MazeLevel maze, int coinCount) : base(x, y, maze)
        {
            CoinCount = coinCount;
        }

        public int CoinCount { get; set; }

        public override bool TryToStep()
        {
            Maze.Hero.Money += CoinCount;
            Maze[X, Y] = new Ground(X, Y, Maze);
            return true;
        }
    }
}
