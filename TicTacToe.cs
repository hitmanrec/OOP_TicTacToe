using System;

namespace oop_TicTacToe
{
    class TicTacToe
    {
        public enum mark { Z = 0, X = 1, O = 2 }
        private mark[,] grid;
        private mark turn;
        public bool win { get; private set; }

        public TicTacToe()
        {
            grid = new mark[3, 3];
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    grid[i, j] = mark.Z;
            turn = mark.X;
            win = false;
        }
        public mark[,] GetGrid()
        {
            return grid;
        }
        public mark WhosTurn()
        {
            return turn;
        }
        
        public void makeTurn(int x, int y)
        {
            if (!win)
            {
                if (x > 3 || x < 1 || y > 3 || y < 1)
                    throw new ArgumentException("Out of bounds! (x:[1,3] y:[1,3])");
                if (grid[x - 1, y - 1] != mark.Z)
                    throw new ArgumentException("Place already occupied!");
                grid[x - 1, y - 1] = turn;
                win = CheckForWin();
                if(!win)turn = (turn == mark.X) ? mark.O : mark.X;
            }
            

        }
        public bool CheckForWin()
        {
            mark checkMark = mark.Z;
            for (var i = 0; i < 3; i++)
            {
                if (grid[i, 0] == mark.Z)
                    continue;
                else
                {
                    checkMark = grid[i, 0];
                    if (checkMark == grid[i, 1] && checkMark == grid[i, 2])
                    {
                        return true;
                    }
                }
            }
            for (var j = 0; j < 3; j++)
            {
                if (grid[0, j] == mark.Z)
                    continue;
                else
                {
                    checkMark = grid[0, j];
                    if (checkMark == grid[1, j] && checkMark == grid[2, j])
                    {
                        return true;
                    }
                }
            }
            if(grid[1,1] != mark.Z && ((grid[0,0] == grid[1,1] && grid[2,2] == grid[2,2]) || (grid[0,2] == grid[2,2] && grid[2,0] == grid[2, 2])))
            {
                return true;
            }
            return false;
        }
        public void printGrid()
        {
            Console.Write("---------\n");
            for (var i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (var j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.Write("|\n");
            }
            Console.Write("---------\n");
        }
    }
}
