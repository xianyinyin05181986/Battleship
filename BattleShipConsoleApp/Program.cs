using BattleShipConsoleApp.PlayerComponents;
using BattleShipConsoleApp.PlayerComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initial
            BattleshipStateTracker battleshipStateTracker = new BattleshipStateTracker();
            Console.WriteLine("Ini");
            // Create A Board
            battleshipStateTracker.CreateABoard();

            // Add BattleShip
            Console.WriteLine("Loading Battle Ships");
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Vertically, 1, 1);
            battleshipStateTracker.AddABatthleshipToBoard(5, BattleshipDirection.Horizontally, 2, 1);

            // Response to battle
            Console.WriteLine("Game on!");
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 1));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 5));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 6));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(6, 6));

            //  Winning ?
            Console.WriteLine(battleshipStateTracker.Conduct());

            // Continue the battle
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 2));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 3));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(1, 4));

            Console.WriteLine(battleshipStateTracker.ResponseToAttack(2, 1));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(3, 1));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(4, 1));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(5, 1));
            Console.WriteLine(battleshipStateTracker.ResponseToAttack(6, 1));

            //  Winning ?
            Console.WriteLine(battleshipStateTracker.Conduct());

            Console.ReadLine();

        }
    }
}
