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
                PrintGrid(game);
                PrintNextTurn(game);
                AskForInput(game);
            }
            PrintGrid(game);
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
                Console.WriteLine("Input x, y values in range [1," + game.gridSize + "]");
                string[] s = Console.ReadLine().Split(' ');
                x = int.Parse(s[1]);
                y = int.Parse(s[0]);
                if (x > 0 && x <= game.gridSize && y > 0 && y <= game.gridSize)
                    if (game.isEmpty(x - 1, y - 1))
                        break;
                Console.WriteLine("Wrong input!");
            }
            game.makeTurn(x, y);
        }
        static public void PrintGrid(TicTacToe game)
        {
            int l = game.gridSize;
            TicTacToe.mark[,] grid = game.GetGrid();
            Console.Write("╔");
            for (int i = 0; i < l - 1; i++)
            {
                Console.Write("═╦");
            }
            Console.Write("═╗\n");
            for (var i = 0; i < l; i++)
            {
                Console.Write("║");
                for (var j = 0; j < l; j++)
                {
                    Console.Write((grid[i, j] == TicTacToe.mark.Z ? 
                        " " : grid[i, j].ToString()) + "║");
                }
                if (i < l - 1)
                {
                    Console.Write("\n╠");
                    for (var j = 0; j < l - 1; j++)
                    {
                        Console.Write("═╬");
                    }
                    Console.Write("═╣");
                }
                Console.Write("\n");
            }
            Console.Write("╚");
            for (int i = 0; i < l - 1; i++)
            {
                Console.Write("═╩");
            }
            Console.Write("═╝\n");
        }
    }
}
