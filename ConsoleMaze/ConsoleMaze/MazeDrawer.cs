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
        public Dictionary<Type, string> TypeSymbolDictionary =
            new Dictionary<Type, string>()
            {
                { typeof(Hero), "@" },

                { typeof(Wall), "#" },
                { typeof(WeakWall), "#" },
                { typeof(Coin), "c" },
                { typeof(Ground), "." },
                { typeof(Trap), "~" },
                { typeof(BlessPoint), "$" },
                { typeof(VitalityPotion), "v" },
                { typeof(Fountain), "f" },
                { typeof(Bed), "b" },
                { typeof(GreedyHealer), "H" },
                { typeof(Goldmine), "G" },
                { typeof(TeleportIn), "]" },
                { typeof(TeleportOut), "[" },
                { typeof(HealPotion), "h" },
                { typeof(Puddle), "o" },
                { typeof(WolfPit), "w" },
                { typeof(Tavern), "T" },
            };

        public Dictionary<Type, ConsoleColor> ColorSymbolDictionary =
            new Dictionary<Type, ConsoleColor>()
            {
                { typeof(Hero), ConsoleColor.Green },

                { typeof(Wall), ConsoleColor.Gray },
                { typeof(WeakWall), ConsoleColor.DarkGray },
                { typeof(Coin), ConsoleColor.Yellow },
                { typeof(Ground), ConsoleColor.Magenta },
                { typeof(Trap), ConsoleColor.DarkMagenta },
                { typeof(BlessPoint), ConsoleColor.White },
                { typeof(VitalityPotion), ConsoleColor.White },
                { typeof(Fountain), ConsoleColor.Cyan },
                { typeof(Bed), ConsoleColor.White },
                { typeof(GreedyHealer), ConsoleColor.White },
                { typeof(Goldmine), ConsoleColor.DarkYellow },
                { typeof(TeleportIn), ConsoleColor.Blue },
                { typeof(TeleportOut), ConsoleColor.Blue },
                { typeof(HealPotion), ConsoleColor.White },
                { typeof(Puddle), ConsoleColor.Cyan },
                { typeof(WolfPit), ConsoleColor.DarkMagenta },
                { typeof(Tavern), ConsoleColor.White },
            };

        public void Draw(MazeLevel maze)
        {
            Console.Clear();

            Console.WriteLine(maze.Message);

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);

                    Console.ForegroundColor = GetColorByCellType(cell);
                    Console.Write(GetSymbolByCellType(cell));
                    Console.ResetColor();
                }

                maze.Message = string.Empty;
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"HP: {maze.Hero.HealthPoint}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}");
            Console.WriteLine($"Money: {maze.Hero.Money}");
        }

        public void Redraw(MazeLevel maze, BaseCell cell)
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();

            if (maze.Message == string.Empty)
            {
                Console.Write(new string(' ', Console.BufferWidth));
            }
            else
            {
                Console.Write(maze.Message);
            }

            maze.Message = string.Empty;

            Console.SetCursorPosition(cell.X, cell.Y + 1);

            cell = maze[cell.X, cell.Y];

            Console.ForegroundColor = GetColorByCellType(cell);
            Console.Write(GetSymbolByCellType(cell));

            Console.ForegroundColor = GetColorByCellType(maze.Hero);
            Console.SetCursorPosition(maze.Hero.X, maze.Hero.Y + 1);
            Console.Write("@");
        }
      
        private ConsoleColor GetColorByCellType(IBaseCell cell)
        {
            return ColorSymbolDictionary[cell.GetType()];
        }

        private string GetSymbolByCellType(IBaseCell cell)
        {
            return TypeSymbolDictionary[cell.GetType()];
        }
    }
}