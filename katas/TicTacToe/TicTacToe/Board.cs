using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    public class Board
    {
        private char[,] board;
        private int numberOfTurns = 0;
        public Board()
        {
            board = new char[3,3];
        }
        public void NextPlayerChose(int row, int column)
        {
            this.board[row, column] = numberOfTurns++%2 == 0 ? 'X' : 'O';
        }
        public char GetPosition(int row, int column)
        {
            return this.board[row, column];
        }
        public bool IsThereARowWinner()
        {
            for(int i = 0; i < 3; i++)
            {
                bool rowTakenBy = true;
                rowTakenBy = rowTakenBy && board[i, 0] == board[i, 1];
                rowTakenBy = rowTakenBy && board[i, 0] == board[i, 2];
                if(rowTakenBy) return true;
            }
            return false;
        }
        public bool IsThereADiagonalWinner()
        {
            if( board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] )
                return true;
            if(board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;
            return false;
        }
        public bool isGameOver()
        {
            bool remainsFieldsEmpty = true;
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    remainsFieldsEmpty = remainsFieldsEmpty && board[i, j] == '\0';
            return !remainsFieldsEmpty;
        }
    }
}
