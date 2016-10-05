using System;
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
            def.Game g = new def.Game(1, 2, 3, 4, 5, 6, 0);
        }

        [TestMethod]
        public void CreateGameWithCorrectSizeOfFieldAndOne0()
        {
            def.Game g = new def.Game(1, 2, 3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Элемент с тем же ключом уже был добавлен.")]
        public void CreateGameWithCorrectSizeOfFieldAndTwo0ThrowsException()
        {
            def.Game g = new def.Game(1, 2, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There is must be one and only one '0' element in parameters for constructor.")]
        public void CreateGameWithCorrectSizeOfFieldAndNo0ThrowsException()
        {
            def.Game g = new def.Game(1, 2, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Value is not found.")]
        public void GetLocationFromNotExistValueThrowsException()
        {
            def.Game g = new def.Game(1, 2, 3, 0);

            int x, y;
            g.GetLocation(15, out x, out y);
        }

        [TestMethod]
        public void GetLocationFromCorrectValueReturnsCorrectCoordinates()
        {
            def.Game g = new def.Game(1, 2, 3, 0);

            int x, y;
            g.GetLocation(2, out x, out y);

            Assert.AreEqual(0, x);
            Assert.AreEqual(1, y);
        }

        [TestMethod]
        public void TestIndexerReturnsCorrectValue()
        {
            def.Game g = new def.Game(1, 2, 3, 0);

            Assert.AreEqual(3, g[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You can not do turn with this value now.")]
        public void TryShiftIncorrectTurn()
        {
            def.Game g = new def.Game(1, 2, 3, 0);
            g.Shift(1);
        }

        [TestMethod]
        public void TryShiftCorrectTurn()
        {
            def.Game g = new def.Game(1, 2, 3, 0);
            g.Shift(2);
            Assert.AreEqual(0, g[0, 1]);
            Assert.AreEqual(2, g[1, 1]);
        }
    }
}
