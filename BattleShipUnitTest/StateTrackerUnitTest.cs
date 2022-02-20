using BattleShipConsoleApp.PlayerComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleShipUnitTest
{
    [TestClass]
    public class StateTrackerUnitTest
    {
        [TestMethod]
        public void CanCreateABoard()
        {
            // Prepare 
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            // Execute
            battleshipStateTracker.CreateABoard();
            // Assert
            Assert.IsNotNull(battleshipStateTracker.ActiveBoard);
        }
    }
}
