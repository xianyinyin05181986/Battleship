using System;
using System.Collections.Generic;
using System.Linq;

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
    public class BattleshipInBoard : Battleship
    {
        public BattleshipInBoard(int size, BattleshipDirection alignmentDirection, BattleshipSquare startPosition) : base(size)
        {
            Direction = alignmentDirection;
            SetupBattleshipSquare(startPosition);
        }

        /// <summary>
        ///  When align the Battleship, it always starts from startPosition from left to right and from top to bottom
        /// </summary>
        /// <param name="startPosition"></param>
        private void SetupBattleshipSquare(BattleshipSquare startPosition)
        {
            BattleshipSquare = new List<BattleshipSquare>();
            for (int i = 1; i <= Size; i++)
            {
                if (Direction == BattleshipDirection.Vertically)
                {
                    BattleshipSquare.Add(new BattleshipSquare()
                    {
                        X = startPosition.X + i,
                        Y = startPosition.Y,
                        IsHit = false,
                    });
                }
                else
                {
                }
            }
        }


        // Must be aligned either vertically or horizontally
        public BattleshipDirection Direction { get; private set; }
        // Occupied a list of squares in the board
        public List<BattleshipSquare> BattleshipSquare { get; private set; }
        public bool IsSunk()
        {
            if (BattleshipSquare.Any(square => !square.IsHit))
                return false;
            else
                return true;
        }
    }

    public enum BattleshipDirection
    {
        Vertically,
        Horizontally
    }
}