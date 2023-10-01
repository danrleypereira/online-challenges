using TicTacToe;

namespace TicTacToeTest;
public class BoardShould
{
    private static Board GenerateBoardWithRowWinner(int row)
    {
        var board = new Board();
        for(int i = 0; i < 3; i++)
        {
            board.NextPlayerChose(row, i);
            board.NextPlayerChose((row + 1) % 3, i);
        }
        return board;
    }
    public static IEnumerable<object[]> RowWinnersData()
    {
        yield return new object[] { GenerateBoardWithRowWinner(0) };
        yield return new object[] { GenerateBoardWithRowWinner(1) };
        yield return new object[] { GenerateBoardWithRowWinner(2) };
    }

    private static Board GenerateBoardWithColumnWinner(int column)
    {
        var board = new Board();
        for(int i = 0; i < 3; i++)
        {
            board.NextPlayerChose(i, column);
            board.NextPlayerChose(i, (column + 1) % 3);
        }
        return board;
    }
    public static IEnumerable<object[]> ColumnWinnersData()
    {
        yield return new object[] { GenerateBoardWithColumnWinner(0) };
        yield return new object[] { GenerateBoardWithColumnWinner(1) };
        yield return new object[] { GenerateBoardWithColumnWinner(2) };
    }

    public static IEnumerable<object[]> NoWinnersData()
    {
        var board1 = new Board();
        board1.NextPlayerChose(0, 0); // X
        board1.NextPlayerChose(0, 1); // O
        board1.NextPlayerChose(0, 2); // X
        board1.NextPlayerChose(1, 0); // O
        board1.NextPlayerChose(1, 1); // X
        board1.NextPlayerChose(1, 2); // O
        board1.NextPlayerChose(2, 0); // X
        board1.NextPlayerChose(2, 1); // O
        board1.NextPlayerChose(2, 2); // X
        yield return new object[] { board1 }; // Full board, no winner

        var board2 = new Board();
        board2.NextPlayerChose(0, 0); // X
        board2.NextPlayerChose(0, 1); // O
        board2.NextPlayerChose(0, 2); // X
        board2.NextPlayerChose(1, 0); // O
        board2.NextPlayerChose(1, 1); // X
        board2.NextPlayerChose(1, 2); // O
        board2.NextPlayerChose(2, 0); // X
        board2.NextPlayerChose(2, 2); // O
        yield return new object[] { board2 }; // Not full board, no winner
    }

    public static IEnumerable<object[]> DiagonalWinnersData()
    {
        var board1 = new Board();
        board1.NextPlayerChose(0, 0); // X
        board1.NextPlayerChose(0, 1); // O
        board1.NextPlayerChose(1, 1); // X
        board1.NextPlayerChose(0, 2); // O
        board1.NextPlayerChose(2, 2); // X (Winner with diagonal from top-left to bottom-right)
        yield return new object[] { board1 };

        var board2 = new Board();
        board2.NextPlayerChose(0, 2); // X
        board2.NextPlayerChose(0, 0); // O
        board2.NextPlayerChose(1, 1); // X
        board2.NextPlayerChose(1, 0); // O
        board2.NextPlayerChose(2, 0); // X
        board2.NextPlayerChose(2, 2); // O (Winner with diagonal from top-right to bottom-left)
        yield return new object[] { board2 };
    }
    public static IEnumerable<object[]> FalseWinWithEmptiesData()
    {
        //second row empty
        var rowEmpty = new Board();
        rowEmpty.NextPlayerChose(0, 0);
        rowEmpty.NextPlayerChose(1, 0);
        rowEmpty.NextPlayerChose(0, 1);
        rowEmpty.NextPlayerChose(1, 1);
        rowEmpty.NextPlayerChose(1, 2);
        yield return new object[] { rowEmpty };

        //third column empty
        var columnEmpty = new Board();
        columnEmpty.NextPlayerChose(1, 0);
        columnEmpty.NextPlayerChose(2, 0);
        columnEmpty.NextPlayerChose(1, 1);
        columnEmpty.NextPlayerChose(0, 0);
        columnEmpty.NextPlayerChose(0, 1);
        yield return new object[] { columnEmpty };

        //diagonal empty
        var diagonalEmpty = new Board();
        diagonalEmpty.NextPlayerChose(2, 0);
        diagonalEmpty.NextPlayerChose(1, 0);
        diagonalEmpty.NextPlayerChose(2, 1);
        diagonalEmpty.NextPlayerChose(1, 2);
        yield return new object[] { diagonalEmpty };
    }

    [Fact]
    public void Should_Insert_Correct_Symbol_Of_Player()
    {
        Board board = new Board();
        board.NextPlayerChose(1, 2);
        Assert.Equal('X', board.GetPosition(1, 2));
        board.NextPlayerChose(2, 2);
        Assert.Equal('O', board.GetPosition(2, 2));
        board.NextPlayerChose(0, 2);
        Assert.Equal('X', board.GetPosition(0, 2));
    }
    [Theory]
    [MemberData(nameof(RowWinnersData))]
    public void Should_Detect_A_Winner_Row(Board board)
    {
        Assert.True(board.IsThereWinner());
    }
    [Theory]
    [MemberData(nameof(NoWinnersData))]
    public void Should_Detect_GameOver(Board board)
    {
        Assert.True(board.IsGameOver());
    }
    [Theory]
    [MemberData(nameof(NoWinnersData))]
    public void Should_Detect_That_Field_Is_Already_Taken(Board board)
    {
        Assert.Throws<FieldAlreadyTakenException>(() => board.NextPlayerChose(1,2));
    }
    [Theory]
    [MemberData(nameof(DiagonalWinnersData))]
    public void Should_Detect_A_Winner_Diagonal(Board board)
    {
        Assert.True(board.IsThereWinner());
    }
    [Theory]
    [MemberData(nameof(ColumnWinnersData))]
    public void Should_Detect_A_Winner_Column(Board board)
    {
        Assert.True(board.IsThereWinner());
    }
    [Theory]
    [MemberData(nameof(FalseWinWithEmptiesData))]
    public void Should_Not_Detect_Empties_As_A_Winner(Board board)
    {
        Assert.False(board.IsThereWinner());
    }

}