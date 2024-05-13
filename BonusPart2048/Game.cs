using System;
using System.Collections.Generic;
using System.Text;

namespace BonusPart2048
{
    class Game
    {
        public Board GameBoard2048;
        public Program.GameStatus TheGameStatus;
        public int Points { get; protected set; }

        public Game()
        {
            GameBoard2048 = new Board();
            TheGameStatus = Program.GameStatus.Idle;
            Points = 0;
        }

        public void Move(Program.Direction moveInDirection)
        {
            if (TheGameStatus.Equals(Program.GameStatus.Lose))
            {
                return;
            }
            GameBoard2048.Move(moveInDirection);

        }
    }
}
