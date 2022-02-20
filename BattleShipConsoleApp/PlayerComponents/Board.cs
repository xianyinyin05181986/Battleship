using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipConsoleApp.PlayerComponents
{
    public class Board
    {
        public const int DefaultWidth = 10;
        public const int DefaultLength = 10;
        public int Width { get; private set; } = DefaultWidth;
        public int Length { get; private set; } = DefaultLength;
        public List<BattleshipInBoard> Battleships { get; set; } = new List<BattleshipInBoard>();
        public bool AddABattleship(BattleshipInBoard battleship)
        {
            if (battleship == null)
                throw new ArgumentNullException(nameof(battleship));
            if (!IsBattleshipFit(battleship))
            {
                return false;
            }
            else
            {
                Battleships.Add(battleship);
                return true;
            }
        }
        private bool IsBattleshipFit(BattleshipInBoard battleship)
        {
            foreach (Square square in battleship.BattleshipSquare)
            {
                foreach (BattleshipInBoard existingBattleship in Battleships)
                {
                    if (existingBattleship.BattleshipSquare.Any(s => s.X == square.X && s.Y == square.Y))
                        return false;
                }
            }
            return true;
        }
        public bool AreAllBattleshipsSunk()
        {
            if (!Battleships.Any(bs => bs.IsSunk()))
                return true;
            else
                return false;
        }
        public static Board CreateNewBoard()
        {
            return new Board();
        }
    }
}