﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze.Cells
{
    public class GreedyHealer : BaseCell
    {
        public GreedyHealer(int x, int y, MazeLevel maze) : base(x, y, maze) { }

        public override bool TryToStep(BaseCell unit)
        {
            if (Maze.Hero.HealthPoint != Maze.Hero.MaxHealth && Maze.Hero.Money > 1)
            {
                Maze.Hero.HealthPoint = Maze.Hero.MaxHealth;
                Maze.Hero.Money = Maze.Hero.Money / 2;
                Maze[X, Y] = new Ground(X, Y, Maze);
            }

            return true;
        }
    }
}
