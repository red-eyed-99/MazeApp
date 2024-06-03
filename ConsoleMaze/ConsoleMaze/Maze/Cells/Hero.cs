using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class Hero : BaseCell
    {
        public int Money { get; set; }

        public int HealthPoint { get; set; }

        public int MaxHealth { get; set; }

        public int FatiguePoint { get; set; }

        public int MaxFatigue { get; set; }

        public Hero(int x, int y, MazeLevel maze, int heroHealth, int maxHealth, int fatiguePoint, int maxFatigue, int money) : base(x, y, maze)
        {
            HealthPoint = heroHealth;
            MaxHealth = maxHealth;
            FatiguePoint = fatiguePoint;
            MaxFatigue = maxFatigue;
            Money = money;
        }

        public override bool TryToStep()
        {
            throw new NotImplementedException();
        }
    }
}
