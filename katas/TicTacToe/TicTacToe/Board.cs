
using System;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private const char PlayerX = 'X';
        private const char PlayerO = 'O';
        private const char Empty = '\0';

        private readonly char[,] board;
        private int numberOfTurns = 0;
        
        public Board()
        {
            board = new char[3,3];
        }
        public void NextPlayerChose(int row, int column)
        {
            if (row < 0 || row >= 3 || column < 0 || column >= 3)
                throw new ArgumentOutOfRangeException();

            if(this.board[row, column] != Empty) 
                throw new FieldAlreadyTakenException();

            this.board[row, column] = numberOfTurns++%2 == 0 ? PlayerX : PlayerO;
        }
        public char GetPosition(int row, int column)
        {
            if (row < 0 || row >= 3 || column < 0 || column >= 3)
                throw new ArgumentOutOfRangeException();

            return this.board[row, column];
        }
        public bool IsThereWinner()
        {
            return IsThereADiagonalWinner() || IsThereARowWinner() || IsThereAWinnerColumn();
        }
        private bool IsThereARowWinner()
        {
            for(int i = 0; i < 3; i++)
            {
                if(board[i, 0] == Empty) 
                    continue;
                bool rowTakenBy = board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2];
                if(rowTakenBy) return true;
            }
            return false;
        }
        private bool IsThereAWinnerColumn()
        {
            for(int i = 0; i < 3; i++)
            {
                if(board[0, i] == Empty) 
                    continue;
                bool columnTakenBy = board[0, i] == board[1, i] && board[0, i] == board[2, i];
                if(columnTakenBy) return true;
            }
            return false;
        }
        private bool IsThereADiagonalWinner()
        {
            if(board[0, 0] != Empty)
                if( board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] )
                    return true;
            if(board[0, 2] != Empty)
                if(board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                    return true;
            return false;
        }
        public bool IsGameOver()
        {
            if(this.IsThereWinner())
                return true;

            //LINQ to avoid nested fors as below
            return !this.board.Cast<char>().Any(field => field == Empty);

            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    if(board[i, j] == Empty)
                        return false; //there still moves to be made 

            return true; //Board is full
        }
    }
}
