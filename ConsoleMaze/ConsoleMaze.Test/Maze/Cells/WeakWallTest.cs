using ConsoleMaze.Maze;
using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze.Cells.Enemies;
using Moq;
using NUnit.Framework;

namespace ConsoleMaze.Test.Maze.Cells
{
    public class WeakWallTest
    {
        [Test]
        [TestCase(typeof(WallWorm), 2, 2)]
        [TestCase(typeof(Hero), 3, 2)]
        [TestCase(typeof(Hero), 1, 0)]
        public void TryToStepTest(Type unit, int weakWallDurabilityInit, int weakWallDurabilityResult)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var unitMock = new Mock<>();

            mazeMock.SetupProperty(maze => maze.Message);

            var weakWall = new WeakWall(0, 0, mazeMock.Object);
            weakWall.Durability = weakWallDurabilityInit;

            var answer = weakWall.TryToStep(unitMock.Object);

            if (unit == typeof(WallWorm))
            {
                Assert.That(answer, Is.True); 
            }
            else
            {
                Assert.That(answer, Is.False);
            }

            if (unit == typeof(Hero))
            {
                Assert.That(mazeMock.Object.Message, Is.EqualTo("boom"));
            }

            Assert.That(weakWall.Durability, Is.EqualTo(weakWallDurabilityResult));

            if (weakWall.Durability == 0)
            {
                mazeMock.Verify(maze => maze.ReplaceCell(It.IsAny<BaseCell>()), Times.Once);
            }
        }
    }
}
