
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
            if(this.board[row, column] != '\0') throw new FieldAlreadyTakenException();
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
                if(board[i, 0] == '\0') 
                    continue;
                bool rowTakenBy = board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2];
                if(rowTakenBy) return true;
            }
            return false;
        }
        public bool IsThereAWinnerColumn()
        {
            for(int i = 0; i < 3; i++)
            {
                if(board[0, i] == '\0') 
                    continue;
                bool columnTakenBy = board[0, i] == board[1, i] && board[0, i] == board[2, i];
                if(columnTakenBy) return true;
            }
            return false;
        }
        public bool IsThereADiagonalWinner()
        {
            if(board[0, 0] != '\0')
                if( board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] )
                    return true;
            if(board[0, 2] != '\0')
                if(board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                    return true;
            return false;
        }
        public bool IsGameOver()
        {
            bool remainsFieldsEmpty = true;
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    remainsFieldsEmpty = remainsFieldsEmpty && board[i, j] == '\0';
            return !remainsFieldsEmpty;
        }
    }
}
