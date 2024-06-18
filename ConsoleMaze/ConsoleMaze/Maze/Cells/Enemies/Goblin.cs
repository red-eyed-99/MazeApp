using System;
using System.Collections.Generic;
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
                                    && cell is not Wall
                                    && cell is not WeakWall
                                    && Maze.GetCellOrUnit(cell.X, cell.Y) is not Hero)
                                .ToList();

                if (availableCellsToMove.Any())
                {
                    if (X == Maze.Hero.X || Y == Maze.Hero.Y)
                    {
                        _ = availableCellsToMove
                            .Where(cell => X == Maze.Hero.X
                            ?
                                Math.Abs(cell.Y - Maze.Hero.Y) == Math.Abs(Y - Maze.Hero.Y) || Math.Abs(cell.Y - Maze.Hero.Y) > Math.Abs(Y - Maze.Hero.Y)
                            :
                                Math.Abs(cell.X - Maze.Hero.X) == Math.Abs(X - Maze.Hero.X) || Math.Abs(cell.X - Maze.Hero.X) > Math.Abs(X - Maze.Hero.X));

                        var randomCellToMove = availableCellsToMove[random.Next(availableCellsToMove.Count)];

                        var cellToStep = Maze.GetCellOrUnit(randomCellToMove.X, randomCellToMove.Y);

                        if (cellToStep?.TryToStep(this) ?? false)
                        {
                            X = randomCellToMove.X;
                            Y = randomCellToMove.Y;
                        }
                    }
                }
                // находим одинак коорд (x или y) +
                // значение по модулю разности противоположных одинаковой координате координат гоблина и героя должно либо остаться либо увеличиться +
                // если нет совпадающих коорд то четверти
                // предусмотреть возможность идти в стророну героя при отстутствии другого выбора (если разница коорд между гоб и гер 4 клетки)        
            }
        }

        private bool HeroIsNearby()
        {
            return todo;               
        }
    }
}
