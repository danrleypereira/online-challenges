using Microsoft.VisualBasic.FileIO;
using TicTacToe;

namespace TicTacToeTest;

public class BoardShould
{
    public static IEnumerable<object[]> RowWinnersData()
    {
        var board1 = new Board();
        board1.NextPlayerChose(0, 0);
        board1.NextPlayerChose(1, 0);
        board1.NextPlayerChose(0, 1);
        board1.NextPlayerChose(1, 1);
        board1.NextPlayerChose(0, 2);
        yield return new object[] { board1 };

        var board2 = new Board();
        board2.NextPlayerChose(1, 0);
        board2.NextPlayerChose(2, 0);
        board2.NextPlayerChose(1, 1);
        board2.NextPlayerChose(0, 0);
        board2.NextPlayerChose(1, 2);
        yield return new object[] { board2 };

        var board3 = new Board();
        board3.NextPlayerChose(2, 0);
        board3.NextPlayerChose(1, 0);
        board3.NextPlayerChose(2, 1);
        board3.NextPlayerChose(1, 1);
        board3.NextPlayerChose(2, 2);
        yield return new object[] { board3 };
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
    public static IEnumerable<object[]> ColumnWinnersData()
    {
        var board1 = new Board();
        board1.NextPlayerChose(0, 0);
        board1.NextPlayerChose(1, 1);
        board1.NextPlayerChose(1, 0);
        board1.NextPlayerChose(1, 2);
        board1.NextPlayerChose(2, 0);
        yield return new object[] { board1 };

        var board2 = new Board();
        board2.NextPlayerChose(0, 0);
        board2.NextPlayerChose(0, 1);
        board2.NextPlayerChose(1, 0);
        board2.NextPlayerChose(1, 1);
        board2.NextPlayerChose(1, 2);
        board2.NextPlayerChose(2, 1);
        yield return new object[] { board2 };

        var board3 = new Board();
        board3.NextPlayerChose(2, 2);
        board3.NextPlayerChose(2, 1);
        board3.NextPlayerChose(1, 2);
        board3.NextPlayerChose(0, 1);
        board3.NextPlayerChose(0, 2);
        yield return new object[] { board3 };
    }


    [Fact]
    public void InsertionOnEmptyFieldTest()
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
    public void RowWins(Board board)
    {
        Assert.True(board.IsThereARowWinner());
    }
    [Theory]
    [MemberData(nameof(NoWinnersData))]
    public void GameOverWithoutWinner(Board board)
    {
        Assert.True(board.IsGameOver());
    }
    [Theory]
    [MemberData(nameof(NoWinnersData))]
    public void InsertionInAlreadyTakenField(Board board)
    {
        Assert.Throws<FieldAlreadyTakenException>(() => board.NextPlayerChose(1,2));
    }
    [Theory]
    [MemberData(nameof(DiagonalWinnersData))]
    public void DiagonalWins(Board board)
    {
        Assert.True(board.IsThereADiagonalWinner());
    }
    [Theory]
    [MemberData(nameof(ColumnWinnersData))]
    public void ColumnWins(Board board)
    {
        Assert.True(board.IsThereAWinnerColumn());
    }

}