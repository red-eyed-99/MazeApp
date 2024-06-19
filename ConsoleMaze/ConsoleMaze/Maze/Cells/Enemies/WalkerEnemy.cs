using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class WalkerEnemy : BaseEnemy
    {
        public Direction ViewDirection { get; set; }

        public WalkerEnemy(int x, int y, MazeLevel maze) : base(x, y, maze)
        {
            HealthPoint = 1;
            DealsDamage = true;
            ViewDirection = Direction.Up;
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
            var availableCellsToMove = Maze.Cells
                            .Where(cell => (cell.X == X && Math.Abs(cell.Y - Y) == 1
                                || Math.Abs(cell.X - X) == 1 && cell.Y == Y) && cell is not Wall && cell is not WeakWall) // вместо is not Wall можно вызывать метод TryToStep и если true то все ок
                            .ToList();

            if (availableCellsToMove.Any())
            {
                var cellToStep = GetCellToMoveByDirection(availableCellsToMove, ViewDirection);

                if (cellToStep?.TryToStep(this) ?? false)
                {
                    X = cellToStep.X;
                    Y = cellToStep.Y;
                }
            }
        }

        private BaseCell GetCellToMoveByDirection(List<BaseCell> availableCellsToMove, Direction direction)
        {
            var cellSides = new Dictionary<Direction, BaseCell>();
           
            switch (direction)
            {
                case Direction.Up:
                    cellSides.Add(Direction.Left, availableCellsToMove.SingleOrDefault(cell => cell.X < X));
                    cellSides.Add(Direction.Right, availableCellsToMove.SingleOrDefault(cell => cell.X > X));
                    cellSides.Add(Direction.Up, availableCellsToMove.SingleOrDefault(cell => cell.Y < Y));
                    cellSides.Add(Direction.Down, availableCellsToMove.SingleOrDefault(cell => cell.Y > Y));               
                    break;
                case Direction.Left:
                    cellSides.Add(Direction.Left, availableCellsToMove.SingleOrDefault(cell => cell.Y > Y));
                    cellSides.Add(Direction.Right, availableCellsToMove.SingleOrDefault(cell => cell.Y < Y));
                    cellSides.Add(Direction.Up, availableCellsToMove.SingleOrDefault(cell => cell.X < X));
                    cellSides.Add(Direction.Down, availableCellsToMove.SingleOrDefault(cell => cell.X > X));
                    break;
                case Direction.Right:
                    cellSides.Add(Direction.Left, availableCellsToMove.SingleOrDefault(cell => cell.Y < Y));
                    cellSides.Add(Direction.Right, availableCellsToMove.SingleOrDefault(cell => cell.Y > Y));
                    cellSides.Add(Direction.Up, availableCellsToMove.SingleOrDefault(cell => cell.X > X));
                    cellSides.Add(Direction.Down, availableCellsToMove.SingleOrDefault(cell => cell.X < X));
                    break;
                case Direction.Down:
                    cellSides.Add(Direction.Left, availableCellsToMove.SingleOrDefault(cell => cell.X > X));
                    cellSides.Add(Direction.Right, availableCellsToMove.SingleOrDefault(cell => cell.X < X));
                    cellSides.Add(Direction.Up, availableCellsToMove.SingleOrDefault(cell => cell.Y > Y));
                    cellSides.Add(Direction.Down, availableCellsToMove.SingleOrDefault(cell => cell.Y < Y));
                    break;
                default:
                    break;
            }

            if (cellSides[Direction.Left] is not null)
            {
                switch (ViewDirection)
                {
                    case Direction.Right:
                        ViewDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        ViewDirection = Direction.Right;
                        break;
                    case Direction.Left:
                        ViewDirection = Direction.Down;
                        break;
                    default:
                        ViewDirection = Direction.Left;
                        break;
                }
                return cellSides[Direction.Left];
            }
            else if (cellSides[Direction.Up] is not null)
            {
                return cellSides[Direction.Up];
            }
            else if (cellSides[Direction.Right] is not null)
            {
                switch (ViewDirection)
                {
                    case Direction.Right:
                        ViewDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        ViewDirection = Direction.Left;
                        break;
                    case Direction.Left:
                        ViewDirection = Direction.Up;
                        break;
                    default:
                        ViewDirection = Direction.Right;
                        break;
                }
                return cellSides[Direction.Right];
            }
            else
            {
                switch (ViewDirection)
                {
                    case Direction.Right:
                        ViewDirection = Direction.Left;
                        break;
                    case Direction.Down:
                        ViewDirection = Direction.Up;
                        break;
                    case Direction.Left:
                        ViewDirection = Direction.Right;
                        break;
                    default:
                        ViewDirection = Direction.Down;
                        break;
                }
                return cellSides[Direction.Down];
            }
        }
    }
}
