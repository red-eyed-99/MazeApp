namespace ConsoleMaze.Maze.Cells.Enemies
{
    public class WallWorm : BaseEnemy
    {
        public int StepsOnWall { get; set; } = 1;

        public WallWorm(int x, int y, MazeLevel maze) : base(x, y, maze)
        {
            DealsDamage = false;
        }

        public override bool TryToStep(IBaseCell unit)
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
            if (Maze[X, Y] is Wall && StepsOnWall < 3)
            {
                StepsOnWall++;
                return;
            }

            if (StepsOnWall == 3)
            {
                StepsOnWall = 1;
                Maze[X, Y] = new WeakWall(X, Y, Maze);
            }

            var posXBeforeStep = X;
            var posYBeforeStep = Y;

            var availableCellsToMove = Maze.Cells
                            .Where(cell => (cell.X == posXBeforeStep && Math.Abs(cell.Y - posYBeforeStep) == 1
                                || Math.Abs(cell.X - posXBeforeStep) == 1 && cell.Y == posYBeforeStep)
                                && Maze.GetCellOrUnit(cell.X, cell.Y) is not IHero
                                && Maze.GetCellOrUnit(cell.X, cell.Y) is not BaseEnemy)
                            .ToList();

            if (availableCellsToMove.Any())
            {
                var cellToStep = availableCellsToMove.FirstOrDefault(cell => cell is Wall);
                if (cellToStep is null)
                {
                    cellToStep = availableCellsToMove[random.Next(availableCellsToMove.Count)];
                }
                cellToStep = (BaseCell)Maze.GetCellOrUnit(cellToStep.X, cellToStep.Y);

                if (cellToStep?.TryToStep(this) ?? false)
                {
                    X = cellToStep.X;
                    Y = cellToStep.Y;
                }
            }
        }
    }
}
