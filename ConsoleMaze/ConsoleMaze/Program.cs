﻿using ConsoleMaze.Maze;

namespace ConsoleMaze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mazeBuilder = new MazeBuilder();
            var maze = mazeBuilder.Build(5, 12);

            var drawer = new MazeDrawer();

            while (true)
            {
                drawer.Draw(maze);

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
            }
        }
    }
}
