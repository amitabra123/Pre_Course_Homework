using System;

namespace BonusPart2048
{
    class Game
    {
        public Board Board2048;
        public GameStatus TheGameStatus;
        public int Points { get; protected set; }

        public Game()
        {
            Board2048 = new Board();
            TheGameStatus = GameStatus.Idle;
            Points = 0;
        }

        public void Move(Direction moveInDirection)
        {
            if (TheGameStatus.Equals(GameStatus.Lose))
            {
                return;
            }
            Points += Board2048.Move(moveInDirection);
            TheGameStatus = CheckGameStatus();
        }

        public GameStatus CheckGameStatus()
        {
            for(int i = 0; i < Board2048.Data.GetLength(0); i++)
            {
                for(int j = 0; j < Board2048.Data.GetLength(1); j++)
                {
                    if (Board2048.Data[i, j] == 2048)
                    { 
                        return GameStatus.Win;
                    }
                }
            } 
            for (int i = 0; i < Board2048.Data.GetLength(0); i++)
            {
                for (int j = 0; j < Board2048.Data.GetLength(1); j++)
                {
                    if (Board2048.Data[i, j] == 0)
                    {
                        return GameStatus.Idle;
                    }
                }
            } 
            if (CheckIfLost())
                return GameStatus.Idle;
            return GameStatus.Lose;
        }

        private bool CheckIfLost()
        {
            for (int i = 0; i < Board2048.Data.GetLength(0); i++)
            {
                for(int j = 0; j < Board2048.Data.GetLength(1); j++)
                {
                    if (i < Board2048.Data.GetLength(0) - 1 && Board2048.Data[i, j] == Board2048.Data[i + 1, j])
                        return true;
                    if (i > 0 && Board2048.Data[i, j] == Board2048.Data[i - 1, j])
                        return true;
                    if (j < Board2048.Data.GetLength(1) - 1 && Board2048.Data[i, j] == Board2048.Data[i, j + 1])
                        return true;
                    if(j>0 && Board2048.Data[i, j] == Board2048.Data[i, j - 1])
                        return true;
                }
            }
            return false;
        }
    }
}
