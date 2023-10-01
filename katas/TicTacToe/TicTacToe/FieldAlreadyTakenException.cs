using System;
namespace TicTacToe
{
    public class FieldAlreadyTakenException : Exception
    {
        public FieldAlreadyTakenException() : base("The selected field is already taken.")
        {
        }

        public FieldAlreadyTakenException(string message) : base(message)
        {
        }

        public FieldAlreadyTakenException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
