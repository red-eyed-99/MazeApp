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

            Console.WriteLine(maze.Hero.FatiguePoint);

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze[x, y];

                    if (maze.Hero.X == x && maze.Hero.Y == y)
                    {
                        Console.Write("@");
                    }
                    else if (cell is Wall)
                    {
                        Console.Write("#");
                    }
                    else if (cell is Coin)
                    {
                        Console.Write("c");
                    }
                    else if (cell is Ground)
                    {
                        Console.Write(".");
                    }
                    else if (cell is Trap)
                    {
                        Console.Write("~");
                    }
                    else if (cell is BlessPoint)
                    {
                        Console.Write("S");
                    }
                    else if (cell is VitalityPotion)
                    {
                        Console.Write("V");
                    }
                    else if (cell is Fountain)
                    {
                        Console.Write("F");
                    }
                }

                Console.WriteLine(); 
            }
        }
    }
}
