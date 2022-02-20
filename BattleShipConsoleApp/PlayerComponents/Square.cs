namespace BattleShipConsoleApp.PlayerComponents
{
    /// <summary>
    ///  X - horizontal location index - not greater than Width
    ///  Y - vertical location index - not greater than Length
    /// </summary>
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class BattleshipSquare : Square
    {
        public bool IsHit { get; set; } = false;
    }
}