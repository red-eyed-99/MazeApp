using ConsoleMaze.Maze.Cells.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class WeakWall : BaseCell
    {
        public int Durability { get; set; } = 3;

        public WeakWall(int x, int y, IMazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(IBaseCell unit)
        {
            if (unit is IWallWorm)
            {
                return true;
            }
            
            if (unit is IHero)
            {
                Maze.Message = "boom";
                Durability--;
            }

            if (Durability == 0)
            {
                Maze.ReplaceCell(new Ground(X, Y, Maze));
            }

            return false;
        }
    }
}
