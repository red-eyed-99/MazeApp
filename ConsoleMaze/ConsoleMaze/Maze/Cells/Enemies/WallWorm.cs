using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class WallWorm : BaseEnemy
    {
        private Random random = new Random();

        public int HealthPoint { get; set; }

        public WallWorm(int x, int y, MazeLevel maze) : base(x, y, maze)
        {
            DealsDamage = false;
        }

        public override bool TryToStep(BaseCell unit)
        {
            if (unit is Hero && HealthPoint >= 1)
            {
                HealthPoint--;
            }

            if (unit is BaseEnemy)
            {
                return false;
            }

            return true;
        }

        public override void Step()
        {
            var posXBeforeStep = X;
            var posYBeforeStep = Y;

            var availableCellsToMove = Maze.Cells
                            .Where(cell => cell.X == posXBeforeStep && Math.Abs(cell.Y - posYBeforeStep) == 1
                                || Math.Abs(cell.X - posXBeforeStep) == 1 && cell.Y == posYBeforeStep)
                            .ToList();

            if (availableCellsToMove.Any())
            {
                var randomCellToMove = availableCellsToMove[random.Next(availableCellsToMove.Count)];

                var cellToStep = Maze.GetCellOrUnit(randomCellToMove.X, randomCellToMove.Y);

                if (cellToStep?.TryToStep(this) ?? false)
                {
                    X = randomCellToMove.X;
                    Y = randomCellToMove.Y;

                    if (Maze[posXBeforeStep, posYBeforeStep] is Wall)
                    {

                        Maze[posXBeforeStep, posYBeforeStep] = new WeakWall(posXBeforeStep, posYBeforeStep, Maze);
                    }
                }
            }
        }
    }
}
