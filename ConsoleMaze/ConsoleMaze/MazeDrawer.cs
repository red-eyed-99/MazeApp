using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMaze.Maze;
using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze.Cells.Enemies;

namespace ConsoleMaze
{
    public class MazeDrawer
    {
        public void Draw(MazeLevel maze)
        {
            Console.Clear();

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);

                    if (cell is Hero)
                    {
                        Console.Write("@");
                    }
                    else if (cell is BaseEnemy)
                    {
                        Console.Write("E");
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
                    else if (cell is Bed)
                    {
                        Console.Write("B");
                    }
                    else if (cell is GreedyHealer)
                    {
                        Console.Write("G");
                    }
                    else if (cell is Goldmine)
                    {
                        Console.Write("C");
                    }
                    else if (cell is TeleportIn)
                    {
                        Console.Write("]");
                    }
                    else if (cell is TeleportOut)
                    {
                        Console.Write("[");
                    }
                    else if (cell is HealPotion)
                    {
                        Console.Write("H");
                    }
                    else if (cell is Puddle)
                    {
                        Console.Write("o");
                    }
                    else if (cell is WolfPit)
                    {
                        Console.Write("w");
                    }
                    else if (cell is WeakWall)
                    {
                        Console.Write("=");
                    }
                }

                maze.Message = string.Empty;
                Console.WriteLine();
            }

            Console.WriteLine();

            if (!string.IsNullOrEmpty(maze.Message))
            {
                Console.WriteLine(maze.Message);
            }

            Console.WriteLine($"HP: {maze.Hero.HealthPoint}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}");
            Console.WriteLine($"Money: {maze.Hero.Money}");
        }

        public void Redraw(MazeLevel maze, MazeLevel mazeBeforeStep)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);               

                    if (cell is Hero)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("@");
                    }
                    else if (cell is BaseEnemy)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("E");
                    }

                    var heroBeforeStep = mazeBeforeStep.Hero;
                    var heroBeforeStepCell = maze[heroBeforeStep.X, heroBeforeStep.Y];

                    var cellBeforeStep = mazeBeforeStep[heroBeforeStep.X, heroBeforeStep.Y];

                    if ((heroBeforeStepCell != cellBeforeStep) || (heroBeforeStep.X == x && heroBeforeStep.Y == y))
                    {
                        if (heroBeforeStepCell is Wall)
                        {
                            Console.Write("#");
                        }
                        else if (heroBeforeStepCell is Coin)
                        {
                            Console.Write("c");
                        }
                        else if (heroBeforeStepCell is Ground)
                        {
                            Console.Write(".");
                        }
                        else if (heroBeforeStepCell is Trap)
                        {
                            Console.Write("~");
                        }
                        else if (heroBeforeStepCell is BlessPoint)
                        {
                            Console.Write("S");
                        }
                        else if (heroBeforeStepCell is VitalityPotion)
                        {
                            Console.Write("V");
                        }
                        else if (heroBeforeStepCell is Fountain)
                        {
                            Console.Write("F");
                        }
                        else if (heroBeforeStepCell is Bed)
                        {
                            Console.Write("B");
                        }
                        else if (heroBeforeStepCell is GreedyHealer)
                        {
                            Console.Write("G");
                        }
                        else if (heroBeforeStepCell is Goldmine)
                        {
                            Console.Write("C");
                        }
                        else if (heroBeforeStepCell is TeleportIn)
                        {
                            Console.Write("]");
                        }
                        else if (heroBeforeStepCell is TeleportOut)
                        {
                            Console.Write("[");
                        }
                        else if (heroBeforeStepCell is HealPotion)
                        {
                            Console.Write("H");
                        }
                        else if (heroBeforeStepCell is Puddle)
                        {
                            Console.Write("o");
                        }
                        else if (heroBeforeStepCell is WolfPit)
                        {
                            Console.Write("w");
                        }
                        else if (heroBeforeStepCell is WeakWall)
                        {
                            Console.Write("=");
                        }
                    }
                }

                maze.Message = string.Empty;
                Console.WriteLine();
                Console.WriteLine();
            }

            if (!string.IsNullOrEmpty(maze.Message))
            {
                Console.WriteLine(maze.Message);
            }

            Console.WriteLine($"HP: {maze.Hero.HealthPoint}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}");
            Console.WriteLine($"Money: {maze.Hero.Money}");
        }

        public void Redraw(MazeLevel maze, List<BaseCell> cellsBeforeStep, int[] heroPosBeforeStep)
        {
            var cellToRedraw = cellsBeforeStep.SingleOrDefault(cell => maze.Cells.Contains(cell) == false);

            var cell = maze[heroPosBeforeStep[0], heroPosBeforeStep[1]];

            if (cellToRedraw != null)
            {
                if (maze.Hero.X == cell.X && maze.Hero.Y == cell.Y)
                {
                    Console.SetCursorPosition(cellToRedraw.X, cellToRedraw.Y);
                    Console.Write(".");
                }
                else
                {
                    Console.SetCursorPosition(heroPosBeforeStep[0], heroPosBeforeStep[1]);

                    if (cell is Coin)
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
                    else if (cell is Bed)
                    {
                        Console.Write("B");
                    }
                    else if (cell is GreedyHealer)
                    {
                        Console.Write("G");
                    }
                    else if (cell is Goldmine)
                    {
                        Console.Write("C");
                    }
                    else if (cell is TeleportIn)
                    {
                        Console.Write("]");
                    }
                    else if (cell is TeleportOut)
                    {
                        Console.Write("[");
                    }
                    else if (cell is HealPotion)
                    {
                        Console.Write("H");
                    }
                    else if (cell is Puddle)
                    {
                        Console.Write("o");
                    }
                    else if (cell is WolfPit)
                    {
                        Console.Write("w");
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(heroPosBeforeStep[0], heroPosBeforeStep[1]);

                if (cell is Coin)
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
                else if (cell is Bed)
                {
                    Console.Write("B");
                }
                else if (cell is GreedyHealer)
                {
                    Console.Write("G");
                }
                else if (cell is Goldmine)
                {
                    Console.Write("C");
                }
                else if (cell is TeleportIn)
                {
                    Console.Write("]");
                }
                else if (cell is TeleportOut)
                {
                    Console.Write("[");
                }
                else if (cell is HealPotion)
                {
                    Console.Write("H");
                }
                else if (cell is Puddle)
                {
                    Console.Write("o");
                }
                else if (cell is WolfPit)
                {
                    Console.Write("w");
                }
            }

            Console.SetCursorPosition(maze.Hero.X, maze.Hero.Y);
            Console.Write("@");
        }
    }
}