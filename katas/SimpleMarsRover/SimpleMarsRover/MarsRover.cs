using System;

namespace SimpleMarsRover
{
    public class MarsRover
    {
        public MarsRover() { }
        public string Execute(string command)
        {
            string position = "0:0:N";
            char facingDirection = 'N';
            foreach (char input in command)
            {
                if (input == 'R')
                {
                    facingDirection = this.TurnRight(facingDirection);
                }
                else if (input == 'L')
                {
                    facingDirection = 'W';
                }
            }
            return "0:0:" + facingDirection;
        }
        private char TurnRight(char facingDirection)
        {
            if (facingDirection == 'N')
            {
                return 'E';
            }
            else if (facingDirection == 'S')
            {
                return 'W';
            }
            else if (facingDirection == 'E')
            {
                return 'S';
            }
            else
            {
                return 'N';
            }
        }
    }
}
