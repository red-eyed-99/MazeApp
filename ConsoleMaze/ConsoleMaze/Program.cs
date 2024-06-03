using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze;

namespace ConsoleMaze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mazeBuilder = new MazeBuilder();
            var maze = mazeBuilder.Build(10, 10);

            var drawer = new MazeDrawer();
            drawer.Draw(maze);

            while (true)
            {
                var mazeBeforeStep = new MazeLevel();
                mazeBeforeStep.Cells = maze.Cells;
                mazeBeforeStep.Hero = maze.Hero;

                drawer.Redraw(maze, mazeBeforeStep);

                //var cellsBeforeStep = new List<BaseCell>(maze.Cells);
                //var heroPosBeforeStep = new int[] { maze.Hero.X, maze.Hero.Y };

                var key = Console.ReadKey();

                switch (key.Key) 
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        maze.HeroStep(Direction.Left);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        maze.HeroStep(Direction.Right);
                        break;

                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        maze.HeroStep(Direction.Up);
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        maze.HeroStep(Direction.Down);
                        break;
                }

                //drawer.Redraw(maze, cellsBeforeStep, heroPosBeforeStep);
            }
        }
    }
}
