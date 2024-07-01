using ConsoleMaze.Maze;
using ConsoleMaze.Maze.Cells;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Test.Maze.Cells
{
    public class TrapTest
    {
        [Test]
        [TestCase(9, 8)]
        [TestCase(100, 99)]
        [TestCase(0, 0)]
        public void TryToStepTest(int hpInit, int hpResult)
        {
            // Preparing
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<IHero>();

            heroMock.SetupProperty(x => x.HealthPoint);
            heroMock.Object.HealthPoint = hpInit;
            
            mazeMock
                .Setup(x => x.Hero)
                .Returns(heroMock.Object);

            var trap = new Trap(0, 0, mazeMock.Object);

            //Act
            var answer = trap.TryToStep(heroMock.Object);

            //Assert
            Assert.That(answer, Is.True, "We must have posibility to step on the trap");
            if (heroMock.Object.HealthPoint > 0)
            {
                Assert.That(heroMock.Object.HealthPoint, Is.EqualTo(hpResult), "Hero health point must decrease after stepping on trap");
            }
            else
            {
                Assert.That(heroMock.Object.HealthPoint, Is.EqualTo(hpResult), "Hero health shouldn't decrease if it's 0");
            }
            mazeMock.Verify(x => x.ReplaceCell(It.IsAny<BaseCell>()), Times.AtLeastOnce, "After stepping on the trap, the cell must be replaced by the ground");
        }
    }
}
