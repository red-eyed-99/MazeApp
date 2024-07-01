using ConsoleMaze.Maze.Cells;
using ConsoleMaze.Maze;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMaze.Test.Maze.Cells
{
    public class GoldmineTest
    {
        [Test]
        [TestCase(9, 10, 3, 2)]
        [TestCase(0, 1, 1, 0)]
        public void TryToStepTest(int heroMoneyInit, int heroMoneyResult, int goldmineDurabilityInit, int goldmineDurabilityResult)
        {
            // Preparing
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<IHero>();

            heroMock.SetupProperty(hero => hero.Money);
            heroMock.Object.Money = heroMoneyInit;

            mazeMock
                .Setup(maze => maze.Hero)
                .Returns(heroMock.Object);

            var goldmine = new Goldmine(0, 0, mazeMock.Object);
            goldmine.Durability = goldmineDurabilityInit;

            //Act
            var answer = goldmine.TryToStep(heroMock.Object);

            //Assert
            Assert.That(answer, Is.True, "We must have posibility to step on the goldmine");
            Assert.That(heroMock.Object.Money, Is.EqualTo(heroMoneyResult), "Hero coins should increase by one");
            Assert.That(goldmine.Durability, Is.EqualTo(goldmineDurabilityResult), "Durability of the goldmine should decrease by one");

            if (goldmine.Durability == 0)
            {
                mazeMock.Verify(maze => maze.ReplaceCell(It.IsAny<BaseCell>()), Times.Once, "If goldmine durability is 0 it must be replaced by ground");
            }
        }
    }
}
