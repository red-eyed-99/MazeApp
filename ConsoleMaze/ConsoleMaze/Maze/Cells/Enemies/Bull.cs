using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleMaze.Maze.Cells;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class Bull : BaseEnemy
    {
        private Random random = new Random();

        private Direction movementDirection;

        public Bull(int x, int y, MazeLevel maze) : base(x, y, maze)
        {
            DetermineMovementDirection(X, Y);
        }

        public override bool TryToStep()
        {
            throw new NotImplementedException();
        }

        public override void Step()
        {
            while (true)
            {
                if (movementDirection == Direction.None)
                {
                    DetermineMovementDirection(X, Y);
                }

                var bullPositionX = X;
                var bullPositionY = Y;

                switch (movementDirection)
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
                else
                {
                    DetermineMovementDirection(X, Y);

                    if (movementDirection == Direction.None)
                    {
                        break;
                    }
                }
            }
        }

        private void DetermineMovementDirection(int bullPositionX, int bullPositionY)
        {
            var availableCellsToMove = Maze.Cells
                            .Where(cell => (cell.X == bullPositionX && Math.Abs(cell.Y - bullPositionY) == 1
                                || Math.Abs(cell.X - bullPositionX) == 1 && cell.Y == bullPositionY) && cell is not Wall && cell is not WeakWall)
                            .ToList();

            if (availableCellsToMove.Any())
            {
                var randomCellToMove = availableCellsToMove[random.Next(availableCellsToMove.Count)];

                if (randomCellToMove.X > bullPositionX)
                {
                    movementDirection = Direction.Right;
                }
                else if (randomCellToMove.X < bullPositionX)
                {
                    movementDirection = Direction.Left;
                }
                else if (randomCellToMove.Y > bullPositionY)
                {
                    movementDirection = Direction.Down;
                }
                else if (randomCellToMove.Y < bullPositionY)
                {
                    movementDirection = Direction.Up;
                }
            }
            else
            {
                movementDirection = Direction.None;
            }
        }
    }
}
