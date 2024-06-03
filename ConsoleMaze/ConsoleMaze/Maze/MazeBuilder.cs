using ConsoleMaze.Maze.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze
{
    public class MazeBuilder
    {
        private MazeLevel maze;
        private Random random = new Random();

        public MazeLevel Build(int width, int height)
        {
            maze = new MazeLevel();

            maze.Width = width;
            maze.Height = height;

            BuildWall();

            BuildGround();

            BuildCoin();

            BuildTrap();

            BuildBlessPoint();

            BuildVitalityPotion();

            BuildFountain();

            BuildBed();

            BuildGreedyHealer();

            BuildGoldmine();

            BuildHealPotion();

            BuildPuddle();

            var hero = new Hero(0, 0, maze, 7, 10, 0, 10, 12);
            maze.Hero = hero;

            return maze;
        }

        private void BuildWall()
        {
            for (int x = 0; x < maze.Width; x++)
            {
                for (int y = 0; y < maze.Height; y++)
                {
                    var wall = new Wall(x, y, maze);
                    maze.Cells.Add(wall);
                }
            }
        }

        private void BuildGround()
        {
            var minerX = 0;
            var minerY = 0;

            var wallToBreak = new List<BaseCell>();

            do
            {
                maze[minerX, minerY] = new Ground(minerX, minerY, maze);

                var cell = maze[minerX, minerY];
                var nearWalls = GetNear<Wall>(cell);
                wallToBreak.AddRange(nearWalls);

                wallToBreak = wallToBreak.Where(x => GetNear<Ground>(x).Count() <= 1).ToList();

                if (!wallToBreak.Any())
                {
                    break;
                }

                var randomCell = GetRandom(wallToBreak);
                wallToBreak.Remove(randomCell);
                minerX = randomCell.X;
                minerY = randomCell.Y;

            } while (wallToBreak.Any());
        }

        private void BuildCoin()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new Coin(randomGround.X, randomGround.Y, maze, 3);
        }

        private void BuildTrap()
        {
            var grounds = maze.Cells
                .Where(x => x is Ground)
                .Where(x => GetNear<Ground>(x).Count >= 2)
                .ToList();

            if (grounds.Any())
            {
                var randomGround = GetRandom(grounds);
                maze[randomGround.X, randomGround.Y] = new Trap(randomGround.X, randomGround.Y, maze);
            }
        }

        private void BuildBlessPoint()
        {
            var deadend = maze.Cells.FirstOrDefault(x => GetNear<Wall>(x).Count() == 3);

            if (deadend != null)
            {
                maze[deadend.X, deadend.Y] = new BlessPoint(deadend.X, deadend.Y, maze);
            }
        }

        private void BuildVitalityPotion()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new VitalityPotion(randomGround.X, randomGround.Y, maze);
        }

        private void BuildFountain()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new Fountain(randomGround.X, randomGround.Y, maze);
        }
      
        private void BuildBed()
        {
            var entrance = maze[0, 0];
            var placesForBed = GetNear<Ground>(entrance);

            if (placesForBed.Any())
            {
                var randomGround = GetRandom(placesForBed.Cast<BaseCell>().ToList());
                maze[randomGround.X, randomGround.Y] = new Bed(randomGround.X, randomGround.Y, maze);
            }
        }

        private void BuildGreedyHealer()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new GreedyHealer(randomGround.X, randomGround.Y, maze);
        }

        private void BuildGoldmine()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new Goldmine(randomGround.X, randomGround.Y, maze);
        }

        private void BuildHealPotion()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new HealPotion(randomGround.X, randomGround.Y, maze);
        }

        private void BuildPuddle()
        {
            var grounds = maze.Cells.Where(x => x is Ground).ToList();
            var randomGround = GetRandom(grounds);
            maze[randomGround.X, randomGround.Y] = new Puddle(randomGround.X, randomGround.Y, maze);
        }

        private BaseCell GetRandom(List<BaseCell> cells)
        {
            var index = random.Next(cells.Count);

            return cells[index];
        }

        private List<TypeOfCell> GetNear<TypeOfCell>(BaseCell currentCell)
            where TypeOfCell : BaseCell
        {
            return maze.Cells
                .Where(cell => cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                    || Math.Abs(cell.X - currentCell.X) == 1 && cell.Y == currentCell.Y)
                .OfType<TypeOfCell>()
                .ToList();
        }
    }
}
