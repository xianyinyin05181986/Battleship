using BattleShipConsoleApp.PlayerComponents;
using BattleShipConsoleApp.PlayerComponents.Common;
using BattleShipConsoleApp.PlayerComponents.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BattleShipUnitTest
{
    [TestClass]
    public class BattleshipUnitTest
    {
        [TestMethod]
        public void BattleshipIsSunkIfItHasBeenHitOnAllTheSquaresItOccupies()
        {
            // Prepare

            BattleshipInBoard battleship = new BattleshipInBoard(5, BattleshipDirection.Vertically, new BattleshipSquare() { X = 1, Y = 1 });

            // Excute 

            foreach (var square in battleship.BattleshipSquares)
            {
                square.IsHit = true;
            }

            // Assert

            Assert.IsTrue(battleship.IsSunk());
        }

        [TestMethod]
        public void BattleshipIsNotSunkIfItHasBeenNotHitOnAllTheSquaresItOccupies()
        {
            // Prepare

            BattleshipInBoard battleship = new BattleshipInBoard(5, BattleshipDirection.Vertically, new BattleshipSquare() { X = 1, Y = 1 });

            // Excute 

            foreach (var square in battleship.BattleshipSquares)
            {
                square.IsHit = true;
            }
            battleship.BattleshipSquares.First().IsHit = false;
            // Assert

            Assert.IsFalse(battleship.IsSunk());
        }
    }
}
