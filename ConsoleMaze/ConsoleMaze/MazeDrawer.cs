using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMaze.Maze;
using ConsoleMaze.Maze.Cells;

namespace ConsoleMaze
{
    public class MazeDrawer
    {
        public void Draw(MazeLevel maze)
        {
            Console.Clear();

            if (!string.IsNullOrEmpty(maze.Message))
            {
                Console.WriteLine(maze.Message);
            }

            Console.WriteLine($"HP: {maze.Hero.HealthPoint}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}");
            Console.WriteLine($"Money: {maze.Hero.Money}");

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);

                    if (maze.Hero.X == x && maze.Hero.Y == y)
                    {
                        Console.Write("\x1b[38;5;206m" + "@");
                    }
                    else if (cell is Wall)
                    {
                        Console.Write("\x1b[38;5;249m" + "#");
                    }
                    else if (cell is Coin)
                    {
                        Console.Write("\x1b[38;5;228m" + "c");
                    }
                    else if (cell is Ground)
                    {
                        Console.Write("\x1b[38;5;95m" + ".");
                    }
                    else if (cell is Trap)
                    {
                        Console.Write("\x1b[38;5;145m" + "~");
                    }
                    else if (cell is BlessPoint)
                    {
                        Console.Write("\x1b[38;5;165m" + "S");
                    }
                    else if (cell is VitalityPotion)
                    {
                        Console.Write("\x1b[38;5;120m" + "V");
                    }
                    else if (cell is Fountain)
                    {
                        Console.Write("\x1b[38;5;39m" + "F");
                    }
                    else if (cell is Bed)
                    {
                        Console.Write("\x1b[38;5;1m" + "B");
                    }
                    else if (cell is GreedyHealer)
                    {
                        Console.Write("\x1b[38;5;54m" + "G");
                    }
                    else if (cell is Goldmine)
                    {
                        Console.Write("\x1b[38;5;226m" + "C");
                    }
                    else if (cell is TeleportIn)
                    {
                        Console.Write("\x1b[38;5;27m" + "]");
                    }
                    else if (cell is TeleportOut)
                    {
                        Console.Write("\x1b[38;5;214m" + "[");
                    }
                    else if (cell is HealPotion)
                    {
                        Console.Write("\x1b[38;5;9m" + "H");
                    }
                    else if (cell is Puddle)
                    {
                        Console.Write("\x1b[38;5;143m" + "o");
                    }
                    else if (cell is WolfPit)
                    {
                        Console.Write("\x1b[38;5;89m" + "w");
                    }
                    else if (cell is WeakWall)
                    {
                        Console.Write("\x1b[38;5;239m" + "#");
                    }
                }

                maze.Message = string.Empty;
                Console.WriteLine(); 
            }
        }
    }
}