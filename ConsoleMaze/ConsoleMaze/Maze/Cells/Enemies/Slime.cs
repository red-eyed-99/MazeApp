using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class Slime : BaseEnemy
    {
        public Slime(int x, int y, MazeLevel maze) : base(x, y, maze)
        {
            HealthPoint = 1;
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
            var slimePosXBeforeStep = X;
            var slimePosYBeforeStep = Y;

            var availableCellsToMove = Maze.Cells
                            .Where(cell => (cell.X == slimePosXBeforeStep && Math.Abs(cell.Y - slimePosYBeforeStep) == 1
                                || Math.Abs(cell.X - slimePosXBeforeStep) == 1 && cell.Y == slimePosYBeforeStep) && cell is not Wall && cell is not WeakWall)
                            .ToList();

            if (availableCellsToMove.Any())
            {
                var randomCellToMove = availableCellsToMove[random.Next(availableCellsToMove.Count)];

                var cellToStep = Maze.GetCellOrUnit(randomCellToMove.X, randomCellToMove.Y);

                if (cellToStep?.TryToStep(this) ?? false)
                {
                    X = randomCellToMove.X;
                    Y = randomCellToMove.Y;

                    if (Maze[slimePosXBeforeStep, slimePosYBeforeStep] is Ground)
                    {
                        if (random.Next(0, 9) == 1)
                        {
                            Maze[slimePosXBeforeStep, slimePosYBeforeStep] = new Coin(slimePosXBeforeStep, slimePosYBeforeStep, Maze, 1);
                        }
                    }
                }
            }
        }
    }
}