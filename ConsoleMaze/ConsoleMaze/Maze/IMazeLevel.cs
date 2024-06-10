using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze.Cells.Enemies;

namespace ConsoleMaze.Maze
{
    public interface IMazeLevel
    {
        BaseCell this[int x, int y] { get; set; }

        List<BaseCell> Cells { get; set; }
        List<BaseEnemy> Enemies { get; set; }
        int Height { get; set; }
        IHero Hero { get; set; }
        string Message { get; set; }
        int Width { get; set; }

        IBaseCell GetCellOrUnit(int x, int y);
        void HeroStep(Direction direction);
        void ReplaceCell(BaseCell cell);
    }
}