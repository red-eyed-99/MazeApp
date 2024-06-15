namespace ConsoleMaze.Maze.Cells
{
    public interface IHero : IBaseCell
    {
        int FatiguePoint { get; set; }
        int HealthPoint { get; set; }
        int MaxFatigue { get; set; }
        int MaxHealth { get; set; }
        int Money { get; set; }

        bool TryToStep(IBaseCell unit);
    }
}