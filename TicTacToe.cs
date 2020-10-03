using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_TicTacToe
{
    class TicTacToe
    {
        public enum mark { Z , X , O }
        private mark[,] grid;
        private mark turn;
        public int winCondition { get; private set; }
        public bool win { get; private set; }

        public TicTacToe(int gridSize = 3, int winRowSize = 3)
        {
            if (gridSize < 3 || gridSize > 15)
                throw new ArgumentException("Grid size must be at least 3, and less than 16!");
            if(winRowSize < 3 || winRowSize > gridSize)
                throw new ArgumentException("Win row size must be at least 3, and less than grid size!");
            winCondition = winRowSize;
            grid = new mark[gridSize, gridSize];
            for (var i = 0; i < gridSize; i++)
                for (var j = 0; j < gridSize; j++)
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
                if (x > grid.GetLength(0) || x < 1 || y > grid.GetLength(0) || y < 1)
                    throw new ArgumentException("Out of bounds! (x:[1," + grid.GetLength(0) + "] y:[1," + grid.GetLength(0) + "])");
                if (grid[x - 1, y - 1] != mark.Z)
                    throw new ArgumentException("Place already occupied!");
                grid[x - 1, y - 1] = turn;
                win = CheckForWin(turn);
                if(!win)turn = (turn == mark.X) ? mark.O : mark.X;
            }
        }
        public bool CheckForWin(mark who)
        {
            //check rows & cols
            for (int i = 0, l = grid.GetLength(0); i < l; i++)
            {
                int rowCounter = 0, colCounter = 0;
                for(int j = 0; j < l; j++)
                {
                    if (grid[i, j] == who) rowCounter++;
                    else rowCounter = 0;
                    if (grid[j, i] == who) colCounter++;
                    else colCounter = 0;
                    if (rowCounter >= winCondition || colCounter >= winCondition) return true;
                }
            }
            //diagonals 
            for(int i, j, row = winCondition - 1, col = 0, l = grid.GetLength(0); //from bottom left corner
                col <= l - winCondition;)
            {
                i = row;
                j = col;
                int counter = 0;
                while(i >= 0 && j < l)
                {
                    
                    if (grid[i--, j++] == who) counter++;
                    else counter = 0;
                    if (counter >= winCondition) return true;
                }
                if (row < l - 1) row++;
                else col++;
            }
            for (int i, j, l = grid.GetLength(0), row = l - winCondition, col = 0; //from top left corner
                col <= l - winCondition;)
            {
                i = row;
                j = col;
                int counter = 0;
                while(i < l && j < l)
                {
                    
                    if (grid[i++, j++] == who) counter++;
                    else counter = 0;
                    if (counter >= winCondition) return true;
                }
                if (row > 0) row--;
                else col++;
            }
            return false;
        }
        public void PrintGrid()
        {
            Console.Write("╔");
            for (int i = 0; i < grid.GetLength(0)-1; i++){
                Console.Write("═╦");
            }
            Console.Write("═╗\n");
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write("║");
                for (var j = 0; j < grid.GetLength(0); j++)
                {
                    Console.Write(grid[i, j] + "║");
                }
                if(i < grid.GetLength(0) - 1)
                {
                    Console.Write("\n╠");
                    for (var j = 0; j < grid.GetLength(0) - 1; j++)
                    {
                        Console.Write("═╬");
                    }
                    Console.Write("═╣");
                }
                Console.Write("\n");
            }
            Console.Write("╚");
            for (int i = 0; i < grid.GetLength(0)-1; i++)
            {
                Console.Write("═╩");
            }
            Console.Write("═╝\n");
        }
    }
}
