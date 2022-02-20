using BattleShipConsoleApp.PlayerComponents.Common;
using BattleShipConsoleApp.PlayerComponents.Enums;
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
        private List<BattleshipInBoard> Battleships { get; set; } = new List<BattleshipInBoard>();
        public void AddABattleship(int size, BattleshipDirection direction, int x, int y)
        {

            BattleshipInBoard battleship = new BattleshipInBoard(size, direction, new BattleshipSquare { X = x, Y = y });
            if (!IsBattleshipFit(battleship))
            {
                throw new InvalidOperationException("Ship must fit entirely on the board.");
            }
            else
            {
                Battleships.Add(battleship);
            }
        }
        private bool IsBattleshipFit(BattleshipInBoard battleship)
        {
            foreach (var square in battleship.BattleshipSquare)
            {
                foreach (BattleshipInBoard existingBattleship in Battleships)
                {
                    if (existingBattleship.BattleshipSquare.Any(s => s.X == square.X && s.Y == square.Y))
                        return false;
                }
            }
            return true;
        }
        public bool AreAllBattleshipsSunk() => !Battleships.Any(bs => !bs.IsSunk());
        public AttackResult TakenAttack(Attack attack)
        {
            foreach (var battleship in Battleships)
            {
                var hitSquare = battleship.BattleshipSquare.FirstOrDefault(s => s.X == attack.X && s.Y == attack.Y);
                if (hitSquare != null)
                {
                    hitSquare.IsHit = true;
                    return AttackResult.Hit;
                }

            }
            return AttackResult.Miss;
        }
        public static Board CreateNewBoard()
        {
            return new Board();
        }
    }
}