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
            var bullPositionX = X;
            var bullPositionY = Y;

            var cellBeforeStep = Maze[X, Y];

            do
            {
                var direction = (Direction)random.Next(0, 4);

                switch (direction)
                {
                    case Direction.Up:
                        bullPositionY--;
                        break;
                    case Direction.Right:
                        bullPositionX++;
                        break;
                    case Direction.Down:
                        bullPositionY++;
                        break;
                    case Direction.Left:
                        bullPositionX--;
                        break;
                    default:
                        break;
                }

                var cellToStep = Maze[bullPositionX, bullPositionY];

                if (cellToStep?.TryToStep() ?? false)
                {
                    X = bullPositionX;
                    Y = bullPositionY;
                    break;
                } 
            } while (true);
        }
    }
}
