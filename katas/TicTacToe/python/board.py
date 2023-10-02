class FieldAlreadyTakenException(Exception):
    """Exception raised when a player tries to take a field that's already taken.

    Attributes:
        message -- explanation of the error
    """

    def __init__(self, message="The selected field is already taken."):
        self.message = message
        super().__init__(self.message)


class Board:
    PlayerX = 'X'
    PlayerO = 'O'
    Empty = '\0'

    def __init__(self):
        self.board = [[self.Empty for _ in range(3)] for _ in range(3)]
        self.number_of_turns = 0

    def next_player_chose(self, row, column):
        if row < 0 or row >= 3 or column < 0 or column >= 3:
            raise IndexError("Row or column out of range")

        if self.board[row][column] != self.Empty:
            raise FieldAlreadyTakenException()

        self.board[row][column] = self.PlayerX if self.number_of_turns % 2 == 0 else self.PlayerO
        self.number_of_turns += 1

    def get_position(self, row, column):
        if row < 0 or row >= 3 or column < 0 or column >= 3:
            raise IndexError("Row or column out of range")

        return self.board[row][column]

    def is_there_winner(self):
        return self._is_there_diagonal_winner() or self._is_there_row_winner() or self._is_there_column_winner()

    def _is_there_row_winner(self):
        for i in range(3):
            if self.board[i][0] == self.Empty:
                continue
            if self.board[i][0] == self.board[i][1] == self.board[i][2]:
                return True
        return False

    def _is_there_column_winner(self):
        for i in range(3):
            if self.board[0][i] == self.Empty:
                continue
            if self.board[0][i] == self.board[1][i] == self.board[2][i]:
                return True
        return False

    def _is_there_diagonal_winner(self):
        if self.board[0][0] != self.Empty and self.board[0][0] == self.board[1][1] == self.board[2][2]:
            return True
        if self.board[0][2] != self.Empty and self.board[0][2] == self.board[1][1] == self.board[2][0]:
            return True
        return False

    def is_game_over(self):
        if self.is_there_winner():
            return True
        return all(cell != self.Empty for row in self.board for cell in row)
