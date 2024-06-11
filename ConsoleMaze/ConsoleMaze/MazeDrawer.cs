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
                { typeof(TeleportIn), "֍" },
                { typeof(TeleportOut), "֎" },
                { typeof(HealPotion), "h" },
                { typeof(Puddle), "o" },
                { typeof(WolfPit), "w" },
                { typeof(Tavern), "T" },

                { typeof(Bull), "Ʊ" },
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

                { typeof(Bull), ConsoleColor.Red },
            };

        public void Draw(MazeLevel maze)
        {
            Console.Clear();

            Console.WriteLine();

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);

                    Console.ForegroundColor = GetColorByCellType(cell);
                    Console.Write(GetSymbolByCellType(cell));
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            ShowHeroStatus(maze);
        }

        public void Redraw(MazeLevel maze, List<int[]> cellsToRedrawCoordinates)
        {
            foreach (var cell in cellsToRedrawCoordinates)
            {
                var currentCell = maze.GetCellOrUnit(cell[0], cell[1]);
                RedrawCell(currentCell);
            }

            RedrawCell(maze.Hero);

            foreach (var enemy in maze.Enemies)
            {
                RedrawCell(enemy);
            }

            Console.ResetColor();

            ShowHeroStatus(maze);
        }

        public void RedrawCell(IBaseCell cell)
        {
            Console.SetCursorPosition(cell.X, cell.Y + 1);
            Console.ForegroundColor = GetColorByCellType(cell);
            Console.Write(GetSymbolByCellType(cell));
        }

        private ConsoleColor GetColorByCellType(IBaseCell cell)
        {
            return ColorSymbolDictionary[cell.GetType()];
        }

        private string GetSymbolByCellType(IBaseCell cell)
        {
            return TypeSymbolDictionary[cell.GetType()];
        }

        public void ShowMessage(MazeLevel maze)
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.Write(maze.Message + new string(' ', !string.IsNullOrEmpty(maze.Message) ? Console.BufferWidth - maze.Message.Length : Console.BufferWidth));

            maze.Message = string.Empty;
        }

        private void ShowHeroStatus(IMazeLevel maze)
        {
            for (int afterMazeLineNumber = 2; afterMazeLineNumber <= 4; afterMazeLineNumber++)
            {
                Console.SetCursorPosition(0, maze.Height + afterMazeLineNumber);
                Console.Write(new string(' ', Console.BufferWidth));
            }

            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"HP: {maze.Hero.HealthPoint}/{maze.Hero.MaxHealth}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}/{maze.Hero.MaxFatigue}");
            Console.WriteLine($"Money: {maze.Hero.Money}");
        }
    }
}