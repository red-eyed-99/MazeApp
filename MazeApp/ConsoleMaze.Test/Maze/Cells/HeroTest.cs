using ConsoleMaze.Maze;
using ConsoleMaze.Maze.Cells;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMaze.Maze.Cells.Enemies;

namespace ConsoleMaze.Test.Maze.Cells
{
    public class HeroTest
    {
        [Test]
        [TestCase(10, 9, true, TestName = "Enemy can damage the hero")]
        [TestCase(10, 10, false, TestName = "Enemy can't damage the hero")]
        [TestCase(0, 0, true, TestName = "Hero has 0 hp")]
        public void TryToStepTest(int heroHealthInit, int heroHealthResult, bool enemyDealsDamage)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var enemyMock = new Mock<IBaseEnemy>();
            var hero = new Hero(0, 0, mazeMock.Object, heroHealthInit, 10, 5, 10, 3);

            enemyMock.SetupProperty(enemy => enemy.DealsDamage);
            enemyMock.Object.DealsDamage = enemyDealsDamage;

            var answer = hero.TryToStep(enemyMock.Object);

            Assert.That(answer, Is.True, "Enemy must be able to step on the hero");
            Assert.That(hero.HealthPoint, Is.EqualTo(heroHealthResult));
        }
    }
}
