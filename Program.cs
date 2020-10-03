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
            TicTacToe game = new TicTacToe(5,4);
            while (!game.win)
            {
                game.PrintGrid();
                PrintNextTurn(game);
                AskForInput(game);
            }
            game.PrintGrid();
            Console.WriteLine(game.WhosTurn() + " is winner!!!");
        }

        static public void PrintNextTurn(TicTacToe game)
        {
            Console.WriteLine("Next turn: " + game.WhosTurn());
        }

        static public void AskForInput(TicTacToe game)
        {
            int x = 0, y = 0;
            while (true)
            {
                Console.WriteLine("Input x, y values in range [1," + game.GetGrid().GetLength(0) + "]");
                string[] s = Console.ReadLine().Split(' ');
                x = int.Parse(s[1]);
                y = int.Parse(s[0]);
                if (x > 0 && x <= game.GetGrid().GetLength(0) && y > 0 && y <= game.GetGrid().GetLength(0))
                    if (game.GetGrid()[x - 1, y - 1] == TicTacToe.mark.Z)
                        break;
                Console.WriteLine("Wrong input!");
            }
            game.makeTurn(x, y);
        }

    }
}
