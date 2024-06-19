using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class Goblin : BaseEnemy
    {
        public Goblin(int x, int y, MazeLevel maze) : base(x, y, maze)
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

            if (HealthPoint == 0)
            {
                Maze[X, Y] = new Coin(X, Y, Maze, 10);
                Maze.Enemies.Remove(Maze.Enemies.Single(enemy => enemy.X == X && enemy.Y == Y));
            }

            return true;
        }

        public override void Step()
        {
            if (HeroIsNearby())
            {
                var posXBeforeStep = X;
                var posYBeforeStep = Y;

                var availableCellsToMove = Maze.Cells
                                .Where(cell => (cell.X == posXBeforeStep && Math.Abs(cell.Y - posYBeforeStep) == 1
                                    || Math.Abs(cell.X - posXBeforeStep) == 1 && cell.Y == posYBeforeStep)

                                    && (Math.Abs(cell.Y - Maze.Hero.Y) > Math.Abs(Y - Maze.Hero.Y)
                                    || Math.Abs(cell.X - Maze.Hero.X) > Math.Abs(X - Maze.Hero.X))

                                    && cell is not Wall
                                    && cell is not WeakWall
                                    && Maze.GetCellOrUnit(cell.X, cell.Y) is not Hero)
                                .ToList();


                if (availableCellsToMove.Any())
                {
                    var randomCellToMove = availableCellsToMove[random.Next(availableCellsToMove.Count)];

                    var cellToStep = Maze.GetCellOrUnit(randomCellToMove.X, randomCellToMove.Y);

                    if (cellToStep?.TryToStep(this) ?? false)
                    {
                        X = randomCellToMove.X;
                        Y = randomCellToMove.Y;
                    }
                }

            }        
        }

        private bool HeroIsNearby()
        {
            var cellsNearGoblin = Maze.Cells
                                .Where(cell => (cell.X == X && Math.Abs(cell.Y - Y) <= 2)
                                    || (Math.Abs(cell.X - X) <= 2 && cell.Y == Y)
                                    || (Math.Abs(cell.X - X) == 1 && Math.Abs(cell.Y - Y) == 1))
                                .ToList();

            if (cellsNearGoblin.SingleOrDefault(cell => cell.X == Maze.Hero.X && cell.Y == Maze.Hero.Y) is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

