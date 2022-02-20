using BattleShipConsoleApp.PlayerComponents.Common;
using BattleShipConsoleApp.PlayerComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsoleApp.PlayerComponents
{
    public class BattleshipStateTracker : IBattleshipLogic
    {
        public Board ActiveBoard { get; private set; }
        public void CreateABoard()
        {
            ActiveBoard = Board.CreateNewBoard();
        }
        public void AddABatthleshipToBoard(int size, BattleshipDirection direction, int startPosition_x, int startPosition_y)
        {
            if (ActiveBoard == null) throw new ArgumentNullException(nameof(ActiveBoard));
            ActiveBoard.AddABattleship(size, direction, startPosition_x, startPosition_y);
        }
        public AttackResult ResponseToAttack(int x, int y)
        {
            if (ActiveBoard == null) throw new ArgumentNullException(nameof(ActiveBoard));

            return ActiveBoard.TakenAttack(new Attack()
            {
                X = x,
                Y = y
            });
        }
        public GameResult Conduct()
        {
            if (ActiveBoard == null) throw new ArgumentNullException(nameof(ActiveBoard));
            return ActiveBoard.AreAllBattleshipsSunk() ? GameResult.Lost : GameResult.NoLostYet;
        }

    }
}
