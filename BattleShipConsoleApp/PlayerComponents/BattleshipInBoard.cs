using BattleShipConsoleApp.PlayerComponents.Common;
using BattleShipConsoleApp.PlayerComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipConsoleApp.PlayerComponents
{
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
                        X = startPosition.X,
                        Y = startPosition.Y + i - 1,
                        IsHit = false,
                    });
                }
                else
                {
                    BattleshipSquare.Add(new BattleshipSquare()
                    {
                        X = startPosition.X + i - 1,
                        Y = startPosition.Y,
                        IsHit = false,
                    });
                }
            }
        }


        // Must be aligned either vertically or horizontally
        public BattleshipDirection Direction { get; private set; }
        // Occupied a list of squares in the board
        public List<BattleshipSquare> BattleshipSquare { get; private set; }
        public bool IsSunk() => !BattleshipSquare.Any(square => !square.IsHit);


    }
}