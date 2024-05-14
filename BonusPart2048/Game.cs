using System;
using System.Collections.Generic;
using System.Text;

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
            } // עברנו על כל התאים, אם יש 2048- ניצח.
            for (int i = 0; i < Board2048.Data.GetLength(0); i++)
            {
                for (int j = 0; j < Board2048.Data.GetLength(1); j++)
                {
                    if (Board2048.Data[i, j] == 0)
                    {
                        return GameStatus.Idle;
                    }
                }
            } // עברנו על כל התאים, אם אחד מהם ריק אז הוא לא הפסיד ולא ניצח
            if (CheckIfLost())
                return GameStatus.Idle;
            // עברנו על כל התאים במידה ואף אחד מהם לא ריק- נבדוק אם אפשר להמשיך למזג
            return GameStatus.Lose;
        }

        private bool CheckIfLost()// מחזיר אמת אם עוד אפשר להמשיך למזג ושקר אם לא
        {
            for (int i = 1; i < Board2048.Data.GetLength(0) - 1; i++)
            {
                for(int j = 0; j < Board2048.Data.GetLength(1); j++)
                {
                    if (Board2048.Data[i, j] == Board2048.Data[i + 1, j])
                        return true;
                    if (Board2048.Data[i, j] == Board2048.Data[i - 1, j])
                        return true;
                }
            }
            for (int i = 0; i < Board2048.Data.GetLength(0); i++)
            {
                for (int j = 1; j < Board2048.Data.GetLength(1)-1; j++)
                {
                    if (Board2048.Data[i, j] == Board2048.Data[i, j+1])
                        return true;
                    if (Board2048.Data[i, j] == Board2048.Data[i, j-1])
                        return true;
                }
            }
            return false;
        }
    }
}
