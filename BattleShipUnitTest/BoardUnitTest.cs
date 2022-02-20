using BattleShipConsoleApp.PlayerComponents;
using BattleShipConsoleApp.PlayerComponents.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleShipUnitTest
{
    [TestClass]
    public class BoardUnitTest
    {

        [TestMethod]
        public void CanAddBattleShipsOnBoard()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            // Execute 
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);
            // Assert
            Assert.AreEqual(battleshipStateTracker.ActiveBoard.Battleships.Count, 1);
        }
        [TestMethod]
        public void ShipMustFitEntirelyOnTheBoard()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            // Execute and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => battleshipStateTracker.AddABatthleshipToBoard(11, BattleshipDirection.Vertically, 1, 1));
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);
            Assert.AreEqual(battleshipStateTracker.ActiveBoard.Battleships.Count, 1);

        }
        [TestMethod]
        public void ShipCanNotBeAlignedOverlap()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            // Execute 
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);
            // Assert
            Assert.AreEqual(battleshipStateTracker.ActiveBoard.Battleships.Count, 1);
            Assert.ThrowsException<InvalidOperationException>(() => battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1));
            Assert.ThrowsException<InvalidOperationException>(() => battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 5));
        }
        [TestMethod]
        public void ReportHitWhenAShipGetHit()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);

            // Execute and Assert
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(1, 1), AttackResult.Hit);
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(1, 2), AttackResult.Hit);
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(1, 3), AttackResult.Hit);
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(1, 4), AttackResult.Hit);
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(1, 5), AttackResult.Hit);

        }
        [TestMethod]
        public void ReportMissWhenNotHitAnyShip()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);

            // Execute and Assert
            Assert.AreEqual(battleshipStateTracker.ResponseToAttack(2, 1), AttackResult.Miss);

        }

        [TestMethod]
        public void ReportLostWhenAllShipsSunk()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            battleshipStateTracker.CreateABoard();
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Horizontally, 2, 1);

            // Execute

            battleshipStateTracker.ResponseToAttack(1, 1);
            battleshipStateTracker.ResponseToAttack(1, 5);
            battleshipStateTracker.ResponseToAttack(1, 6);
            battleshipStateTracker.ResponseToAttack(6, 6);
            Assert.AreEqual(battleshipStateTracker.Conduct(), GameResult.NoLostYet);
            battleshipStateTracker.ResponseToAttack(1, 2);
            battleshipStateTracker.ResponseToAttack(1, 3);
            battleshipStateTracker.ResponseToAttack(1, 4);
            battleshipStateTracker.ResponseToAttack(2, 1);
            battleshipStateTracker.ResponseToAttack(3, 1);
            battleshipStateTracker.ResponseToAttack(4, 1);
            battleshipStateTracker.ResponseToAttack(5, 1);
            battleshipStateTracker.ResponseToAttack(6, 1);
            Assert.AreEqual(battleshipStateTracker.Conduct(), GameResult.Lost);
        }
    }
}
