namespace BattleShipConsoleApp.PlayerComponents.Common
{
    /// <summary>
    ///  X - horizontal location index - not greater than Width
    ///  Y - vertical location index - not greater than Length
    /// </summary>
    public interface Square
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public class BattleshipSquare : Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; } = false;
    }

    public class Attack : Square
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}