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

        public void Draw(MazeLevel maze)
        {
            Console.Clear();

            Console.WriteLine(maze.Message);

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.GetCellOrUnit(x, y);

                    Console.Write(GetSymbolByCellType(cell));
                }

                maze.Message = string.Empty;
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"HP: {maze.Hero.HealthPoint}");
            Console.WriteLine($"Fatigue: {maze.Hero.FatiguePoint}");
            Console.WriteLine($"Money: {maze.Hero.Money}");
        }

        private string GetSymbolByCellType(BaseCell cell)
        {
            return TypeSymbolDictionary[cell.GetType()];
        }
    }
}