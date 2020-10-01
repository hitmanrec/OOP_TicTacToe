using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.printGrid();
            printNextTurn(game);
            game.makeTurn(1, 1);

            game.printGrid();
            printNextTurn(game);
            game.makeTurn(1, 2);

            game.printGrid();
            printNextTurn(game);
            game.makeTurn(2, 1);

            game.printGrid();
            printNextTurn(game);
            game.makeTurn(1, 3);

            game.printGrid();
            printNextTurn(game);
            game.makeTurn(3, 1);

            game.printGrid();
            printNextTurn(game);
        }

        static public void printNextTurn(TicTacToe game)
        {
            if (!game.win)
            {
                Console.WriteLine("Next turn: " + game.WhosTurn());
            }
            else
            {
                Console.WriteLine(game.WhosTurn() + " is winner!!!");
            }
        }
    }
}
