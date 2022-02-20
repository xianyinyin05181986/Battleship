using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsoleApp.PlayerComponents
{
    public class BattleshipStateTracker : IBattleshipLogic
    {

        public void AddBatthleshipToBoard(Board board, params BattleshipInBoard[] Battleships)
        {
            
        }

        GameResult IBattleshipLogic.Conduct()
        {
            throw new NotImplementedException();
        }

        void IBattleshipLogic.CreateABoard()
        {
            throw new NotImplementedException();
        }

        AttackResult IBattleshipLogic.ResponseToAttack(Attack attack)
        {
            throw new NotImplementedException();
        }
    }
}
