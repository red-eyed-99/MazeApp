using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze.Cells.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Maze
{
    public class MazeLevel : IMazeLevel
    {
        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();

        public List<BaseEnemy> Enemies { get; set; } = new List<BaseEnemy>();

        public int Width { get; set; }
        public int Height { get; set; }

        public IHero Hero { get; set; }

        public string Message { get; set; }

        public IBaseCell GetCellOrUnit(int x, int y)
        {
            if (Hero.X == x && Hero.Y == y)
            {
                return Hero;
            }

            var enemy = Enemies.SingleOrDefault(enemy => enemy.X == x && enemy.Y == y);

            if (enemy is not null)
            {
                return enemy;
            }

            return this[x, y];
        }

        public BaseCell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }

            set
            {
                var oldCell = this[x, y];

                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }

                Cells.Add(value);
            }
        }

        public void ReplaceCell(BaseCell baseCell)
        {
            var oldCell = this[baseCell.X, baseCell.Y];

            if (oldCell != null)
            {
                Cells.Remove(oldCell);
            }

            Cells.Add(baseCell);
        }

        public void HeroStep(Direction direction)
        {
            var heroPositionX = Hero.X;
            var heroPositionY = Hero.Y;

            var cellBeforeStep = this[Hero.X, Hero.Y];

            switch (direction) 
            {
                case Direction.Up:
                    heroPositionY--;
                    break;
                case Direction.Right:
                    heroPositionX++;
                    break;
                case Direction.Down:
                    heroPositionY++;
                    break;
                case Direction.Left:
                    heroPositionX--;
                    break;
                default:
                    break;
            }

            var cellToStep = this[heroPositionX, heroPositionY];

            var drawer = new MazeDrawer();

            if (cellToStep?.TryToStep() ?? false)
            {
                if (cellToStep is not TeleportIn)
                {
                    Hero.X = heroPositionX;
                    Hero.Y = heroPositionY;

                    if (Hero.FatiguePoint != Hero.MaxFatigue)
                    {
                        Hero.FatiguePoint++;
                    }
                }

                drawer.Redraw(this, cellBeforeStep);
            }
  
            if (cellToStep is WeakWall weakWall && weakWall.Durability == 0)
            {
                drawer.Redraw(this, cellToStep);
            }

            Enemies.ForEach(x => x.Step());
        }
    }
}