
namespace BattleShipConsoleApp.PlayerComponents
{
    public interface IBattleshipLogic
    {
        void CreateABoard();
        void AddBatthleshipToBoard(Board board, params BattleshipInBoard[] Battleships);
        AttackResult ResponseToAttack(Attack attack);
        GameResult Conduct();

    }
    /// <summary>
    /// Take an “attack” at a given position, and report back whether the attack resulted in a
    /// hit or a miss
    /// </summary>
    public enum AttackResult
    {
        Hit,
        Miss,
    }

    /// <summary>
    /// whether the player has lost the game yet (i.e. all battleships are sunk
    /// according to the game rules)
    /// </summary>
    public enum GameResult
    {
        NoLostYet,
        Lost,
    }
}