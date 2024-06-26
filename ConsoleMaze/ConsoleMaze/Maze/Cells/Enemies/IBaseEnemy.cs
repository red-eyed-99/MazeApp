namespace ConsoleMaze.Maze.Cells.Enemies
{
    public interface IBaseEnemy : IBaseCell
    {
        bool DealsDamage { get; set; }
        int HealthPoint { get; set; }

        void Step();
    }
}