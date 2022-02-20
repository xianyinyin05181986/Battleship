namespace BattleShipConsoleApp.PlayerComponents.Enums
{
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