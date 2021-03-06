﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Size of the field is not a cube.")]
        public void CreateGameWithIncorrectSizeOfFieldThrowsException()
        {
            Def.Game g = new Def.Game(1, 2, 3, 4, 5, 6, 0);
        }

        [TestMethod]
        public void CreateGameWithCorrectSizeOfFieldAndOne0()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Элемент с тем же ключом уже был добавлен.")]
        public void CreateGameWithCorrectSizeOfFieldAndTwo0ThrowsException()
        {
            Def.Game g = new Def.Game(1, 2, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There is must be one and only one '0' element in parameters for constructor.")]
        public void CreateGameWithCorrectSizeOfFieldAndNo0ThrowsException()
        {
            Def.Game g = new Def.Game(1, 2, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Value is not found.")]
        public void GetLocationFromNotExistValueThrowsException()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);

            Def.Cell C = g.GetLocation(15);
        }

        [TestMethod]
        public void GetLocationFromCorrectValueReturnsCorrectCoordinates()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);

            Def.Cell C = g.GetLocation(2);

            Assert.AreEqual(0, C.X);
            Assert.AreEqual(1, C.Y);
        }

        [TestMethod]
        public void TestIndexerReturnsCorrectValue()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);

            Assert.AreEqual(3, g[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You can not do turn with this value now.")]
        public void TryShiftIncorrectTurn()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);
            g.Shift(1);
        }

        [TestMethod]
        public void TryShiftCorrectTurn()
        {
            Def.Game g = new Def.Game(1, 2, 3, 0);
            g.Shift(2);
            Assert.AreEqual(0, g[0, 1]);
            Assert.AreEqual(2, g[1, 1]);
        }

        [TestMethod]
        public void CreateImmutableGameAndDoTurnAreNotSameObjects()
        {
            Def.GameImmutable g = new Def.GameImmutable(1, 2, 3, 0, 4, 5, 6, 7, 8);
            Def.GameImmutable g1 = g.Shift(4);

            Assert.AreNotSame(g, g1);
        }
    }
}
