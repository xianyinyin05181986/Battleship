namespace BattleShipConsoleApp.PlayerComponents
{
    public class Battleship
    {
        public Battleship(int size)
        {
            Size = size;
        }
        // The ships are 1-by-n sized
        public int Size { get; private set; }
    }
}