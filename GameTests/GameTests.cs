using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bowling;

namespace GameTests
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExtraRollThrowsExceptionTest1()
        {
            var game = new Game();
            for (var i = 0; i < 21; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]

        [ExpectedException(typeof(Exception))]
        public void ExtraRollThrowsExceptionTest2()
        {
            var game = new Game();
            for (var i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            for (var i = 0; i < 3; i++)
            {
                game.Roll(5);
            }
            game.Roll(1);
            Assert.AreEqual(33, game.Score());
        }


        [TestMethod]

        public void TestGutterGame()
        {
            var game = new Game();
            for (var i = 0; i < 20; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAll1Game()
        {
            var game = new Game();
            for (var i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(20, game.Score());
        }


        [TestMethod]
        public void TestASpareAndRemaining1Game()
        {
            var game = new Game();

            game.Roll(5);
            game.Roll(5);
            for (var i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(29, game.Score());
        }

        [TestMethod]
        public void TestTwoSpareAndRemaining1Game()
        {
            var game = new Game();

            game.Roll(5);
            game.Roll(5);
            game.Roll(9);
            game.Roll(1);
            for (var i = 0; i < 16; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(46, game.Score());
        }

        [TestMethod]
        public void TestAllSpareGame()
        {
            var game = new Game();

            for (var i = 0; i < 21; i++)
            {
                game.Roll(5);
            }
            Assert.AreEqual(150, game.Score());
        }

        [TestMethod]
        public void TestAStrikeAndRemnaining1Game()
        {
            var game = new Game();
            game.Roll(10);
            for (var i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(30, game.Score());
        }

        [TestMethod]
        public void TestTwoStrikeAndRemnaining1Game()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(10);
            for (var i = 0; i < 16; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(49, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            var game = new Game();
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void TestGame()
        {
            var game = new Game();

            game.Roll(4);
            game.Roll(3);

            game.Roll(10);

            game.Roll(0);
            game.Roll(2);

            game.Roll(5);
            game.Roll(5);

            game.Roll(10);

            game.Roll(7);
            game.Roll(2);

            game.Roll(4);
            game.Roll(6);

            game.Roll(9);
            game.Roll(0);

            game.Roll(3);
            game.Roll(5);

            game.Roll(8);
            game.Roll(2);
            game.Roll(6);

            Assert.AreEqual(121, game.Score());
        }

        [TestMethod]
        public void TestSparesAndRoll10Game()
        {
            var game = new Game();
            for (var i = 0; i < 10; i++)
            {
                game.Roll(9);
                game.Roll(1);
            }
            game.Roll(10);
            Assert.AreEqual(191, game.Score());
        }

        [TestMethod]
        public void Test9GuttersAndRemeining10Game()
        {
            var game = new Game();
            for (var i = 0; i < 18; i++)
            {
                game.Roll(0);
            }
            for (var i = 0; i < 3; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(30, game.Score());
        }

        [TestMethod]
        public void Test8GuttersAndRemeining10Game()
        {
            var game = new Game();
            for (var i = 0; i < 16; i++)
            {
                game.Roll(0);
            }
            for (var i = 0; i < 4; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(60, game.Score());
        }

        [TestMethod]
        public void Test8GuttersASpareAndRemeining10Game()
        {
            var game = new Game();
            for (var i = 0; i < 16; i++)
            {
                game.Roll(0);
            }
            game.Roll(1);
            game.Roll(9);
            for (var i = 0; i < 3; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(50, game.Score());
        }

        [TestMethod]
        public void TestAllFrame9Game()
        {
            var game = new Game();
            for (var i = 0; i < 10; i++)
            {
                game.Roll(9);
                game.Roll(0);
            }

            Assert.AreEqual(90, game.Score());
        }


        [TestMethod]
        public void TestIncompleteGame()
        {
            var game = new Game();
            for (var i = 0; i < 10; i++)
            {
                game.Roll(5);
            }
            game.Roll(10);
            game.Roll(1);

            Assert.AreEqual(92, game.Score());
        }
    }
}
