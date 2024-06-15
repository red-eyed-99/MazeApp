namespace ConsoleMaze.Maze.Cells
{
    public interface IBaseCell
    {
        IMazeLevel Maze { get; }
        int X { get; set; }
        int Y { get; set; }

        bool TryToStep(BaseCell unit);
    }
}