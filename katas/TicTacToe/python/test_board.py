import pytest
from board import Board, FieldAlreadyTakenException

# Helper functions to generate test data
## Generates a board with a winning row at the specified index
def generate_board_with_row_winner(row):
    board = Board()
    for i in range(3):
        board.next_player_chose(row, i)
        board.next_player_chose((row + 1) % 3, i)
    return board

## Generates a board with a winning column at the specified index
def generate_board_with_column_winner(column):
    board = Board()
    for i in range(3):
        board.next_player_chose(i, column)
        board.next_player_chose(i, (column + 1) % 3)
    return board

## Generates test data for diagonal winners
def diagonal_winners_data():
    board1 = Board()
    board1.next_player_chose(0, 0)  # X
    board1.next_player_chose(0, 1)  # O
    board1.next_player_chose(1, 1)  # X
    board1.next_player_chose(0, 2)  # O
    board1.next_player_chose(2, 2)  # X (Winner with diagonal from top-left to bottom-right)

    board2 = Board()
    board2.next_player_chose(0, 2)  # X
    board2.next_player_chose(0, 0)  # O
    board2.next_player_chose(1, 1)  # X
    board2.next_player_chose(1, 0)  # O
    board2.next_player_chose(2, 0)  # X

    return [board1, board2]

## Generates test data for boards with false wins due to empty fields
def false_win_with_empties_data():
    # second row empty
    row_empty = Board()
    row_empty.next_player_chose(0, 0)
    row_empty.next_player_chose(1, 0)
    row_empty.next_player_chose(0, 1)
    row_empty.next_player_chose(1, 1)
    row_empty.next_player_chose(1, 2)

    # third column empty
    column_empty = Board()
    column_empty.next_player_chose(1, 0)
    column_empty.next_player_chose(2, 0)
    column_empty.next_player_chose(1, 1)
    column_empty.next_player_chose(0, 0)
    column_empty.next_player_chose(0, 1)

    # diagonal empty
    diagonal_empty = Board()
    diagonal_empty.next_player_chose(2, 0)
    diagonal_empty.next_player_chose(1, 0)
    diagonal_empty.next_player_chose(2, 1)
    diagonal_empty.next_player_chose(1, 2)

    return [row_empty, column_empty, diagonal_empty]

#end

# Fixtures for parameterized testing

@pytest.fixture(params=[0, 1, 2]) # columns to be filled
def row_winner_board(request):
    """Fixture for generating boards with a winning row."""
    return generate_board_with_row_winner(request.param)

@pytest.fixture(params=[0, 1, 2]) # rows to be filled
def column_winner_board(request):
    """Fixture for generating boards with a winning column."""
    return generate_board_with_column_winner(request.param)

@pytest.fixture(params=[
    # Add more board setups as needed
    # Example: ([(row1, col1), (row2, col2), ...], expected_winner)
    ([(0, 0), (0, 1), (0, 2), (1, 0), (1, 1), (1, 2), (2, 0), (2, 1), (2, 2)], False),
    ([(0, 0), (0, 1), (0, 2), (1, 0), (1, 1), (1, 2), (2, 0), (2, 2)], False)
    # Add more examples as needed
])
def no_winner_board(request):
    """Fixture for generating boards with no winner."""
    coordinates, expected_assertion = request.param
    board = Board()
    for row, col in coordinates:
        board.next_player_chose(row, col)
    return board
#end

# Test functions
def test_should_insert_correct_symbol_of_player():
    """Test if the correct symbol is inserted for each player."""
    board = Board()
    board.next_player_chose(1, 2)
    assert board.get_position(1, 2) == 'X'
    board.next_player_chose(2, 2)
    assert board.get_position(2, 2) == 'O'
    board.next_player_chose(0, 2)
    assert board.get_position(0, 2) == 'X'

def test_should_detect_winner_row(row_winner_board):
    """Test if a winner is correctly detected for rows."""
    assert row_winner_board.is_there_winner()

def test_should_detect_winner_column(column_winner_board):
    """Test if a winner is correctly detected for columns."""
    assert column_winner_board.is_there_winner()

@pytest.mark.parametrize("board", diagonal_winners_data())
def test_should_detect_winner_diagonal(board):
    """Test if a winner is correctly detected for diagonals."""
    assert board.is_there_winner()

def test_should_detect_game_over(no_winner_board):
    """Test if game over is correctly detected."""
    assert no_winner_board.is_game_over()

def test_should_detect_field_already_taken():
    """Test if an exception is raised when a field is already taken."""
    board = Board()
    board.next_player_chose(1, 2)
    with pytest.raises(FieldAlreadyTakenException):
        board.next_player_chose(1, 2)

@pytest.mark.parametrize("board", false_win_with_empties_data())
def test_should_not_detect_empties_as_winner(board):
    """Test if empty fields are not incorrectly detected as winners."""
    assert not board.is_there_winner()