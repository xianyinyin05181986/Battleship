using BattleShipConsoleApp.PlayerComponents.Enums;

namespace BattleShipConsoleApp.PlayerComponents.Common
{
    public interface IBattleshipLogic
    {
        void CreateABoard();
        void AddABatthleshipToBoard(int size, BattleshipDirection direction, int x, int y);
        AttackResult ResponseToAttack(int x, int y);
        GameResult Conduct();
    }
}