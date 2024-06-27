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
        [TestCase(3, 2)]
        [TestCase(1, 0)]
        public void TryToStep_Hero(int weakWallDurabilityInit, int weakWallDurabilityResult)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var unitMock = new Mock<IHero>();

            mazeMock.SetupProperty(maze => maze.Message);

            var weakWall = new WeakWall(0, 0, mazeMock.Object);
            weakWall.Durability = weakWallDurabilityInit;

            var answer = weakWall.TryToStep(unitMock.Object);

            Assert.That(answer, Is.False);
            Assert.That(mazeMock.Object.Message, Is.EqualTo("boom"));
            Assert.That(weakWall.Durability, Is.EqualTo(weakWallDurabilityResult));

            if (weakWall.Durability == 0)
            {
                mazeMock.Verify(maze => maze.ReplaceCell(It.IsAny<BaseCell>()), Times.Once);
            }
            else
            {
                mazeMock.Verify(maze => maze.ReplaceCell(It.IsAny<BaseCell>()), Times.Never);
            }
        }

        [Test]
        [TestCase(3, 3)]
        public void TryToStep_WallWorm(int weakWallDurabilityInit, int weakWallDurabilityResult)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var unitMock = new Mock<IWallWorm>();

            var weakWall = new WeakWall(0, 0, mazeMock.Object);
            weakWall.Durability = weakWallDurabilityInit;

            var answer = weakWall.TryToStep(unitMock.Object);

            Assert.That(answer, Is.True, "Wall worm can step on weak wall");
            Assert.That(weakWall.Durability, Is.EqualTo(weakWallDurabilityResult));
        }

        [Test]
        [TestCase(3, 3)]
        public void TryToStep_IBaseEnemy(int weakWallDurabilityInit, int weakWallDurabilityResult)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var unitMock = new Mock<IBaseEnemy>();
            
            mazeMock.SetupProperty(maze => maze.Message);
            mazeMock.Object.Message = "";

            var weakWall = new WeakWall(0, 0, mazeMock.Object);
            weakWall.Durability = weakWallDurabilityInit;

            var answer = weakWall.TryToStep(unitMock.Object);

            Assert.That(answer, Is.False);
            Assert.That(weakWall.Durability, Is.EqualTo(weakWallDurabilityResult));
            Assert.That(mazeMock.Object.Message == "");
        }
    }
}
