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
    public class GreedyHealerTest
    {
        [Test]
        [TestCase(9, 4, 3, 10, 10, TestName = "Not max health and enough money")]
        [TestCase(2, 2, 10, 10, 10, TestName = "Max health and enough money")]
        [TestCase(0, 0, 5, 5, 10, TestName = "Not max health and not enough money")]
        public void TryToStepTest(int heroMoneyInit, int heroMoneyResult, int heroHealthPointInit, int heroHealthPointResult, int heroMaxHealth)
        {
            // Preparing
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<IHero>();

            heroMock.SetupProperty(hero => hero.HealthPoint);
            heroMock.Object.HealthPoint = heroHealthPointInit;

            heroMock.SetupProperty(hero => hero.Money);
            heroMock.Object.Money = heroMoneyInit;

            heroMock.SetupProperty(hero => hero.MaxHealth);
            heroMock.Object.MaxHealth = heroMaxHealth;

            mazeMock
                .Setup(maze => maze.Hero)
                .Returns(heroMock.Object);

            var greedyHealer = new GreedyHealer(0, 0, mazeMock.Object);

            //Act
            var answer = greedyHealer.TryToStep(heroMock.Object);

            //Assert
            Assert.That(heroMock.Object.Money, Is.EqualTo(heroMoneyResult));
            Assert.That(heroMock.Object.HealthPoint, Is.EqualTo(heroHealthPointResult));
            Assert.That(answer, Is.True, "We must have posibility to step on the greedy healer");

            if (heroHealthPointInit < heroMaxHealth && heroMoneyInit > 1)
            {
                mazeMock.Verify(maze => maze.ReplaceCell(It.IsAny<BaseCell>()), Times.Once, "After stepping on greedy healer it must be replaced by ground");
            }
        }
    }
}
