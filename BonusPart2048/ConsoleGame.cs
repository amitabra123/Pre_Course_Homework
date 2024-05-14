using System;
using System.Collections.Generic;
using System.Text;

namespace BonusPart2048
{
    class ConsoleGame
    {
        public Game game2048;
        private bool userChoseToExit = false; 
        public ConsoleGame()
        {
            game2048 = new Game();
        }
        public void StartAGame()
        {// פה נעשה משחק שלם
            game2048.Board2048.Put2Or4InTwoRandomCells(); // התחלנו בלשים 2 או 4 בשני תאים רנדומליים..
            while(game2048.TheGameStatus == GameStatus.Idle && !userChoseToExit) // כל עוד אפשר להמשיך לשחק
            {
                ShowGameBoard();
                UserChooseDirection();
            }
            if(game2048.TheGameStatus == GameStatus.Lose)
            {
                Console.WriteLine("Sorry you lost!");
                Console.WriteLine("Bye Bye");
                return;
            }    
            else if(!userChoseToExit)// רק אם הוא לא בחר לצאת והגענו לכאן
            {
                Console.WriteLine("Wow!! you won (2048!)");
                Console.WriteLine("Bye Bye");
                return;
            }
        }

        private void ShowGameBoard()
        {
            for (int i = 0; i < game2048.Board2048.Data.GetLength(0); i++)
            {
                for (int j = 0; j < game2048.Board2048.Data.GetLength(1); j++)
                {
                    Console.Write(game2048.Board2048.Data[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public void UserChooseDirection()
        {
            Console.WriteLine("please choose a direction!- to exit press enter");
            ConsoleKey userChooseDirection = Console.ReadKey().Key;
            while (userChooseDirection != ConsoleKey.UpArrow && userChooseDirection != ConsoleKey.DownArrow &&
                userChooseDirection != ConsoleKey.RightArrow && userChooseDirection != ConsoleKey.LeftArrow &&
                userChooseDirection != ConsoleKey.Enter)
            {
                Console.WriteLine("\n please choose a valid direction (UpArrow, DownArrow, LeftArrow or RightArrow)!!");
                userChooseDirection = Console.ReadKey().Key;

            }
            if (userChooseDirection == ConsoleKey.Enter)
            {
                Console.WriteLine("YOU CHOSE TO EXIT!");
                Console.WriteLine("BYE BYE!");
                userChoseToExit = true;
                return;
            }
            MoveAccordingToDirection(userChooseDirection);
        }

        private void MoveAccordingToDirection(ConsoleKey userChooseDirection)
        {
            if (userChooseDirection == ConsoleKey.UpArrow)
            {
                Console.WriteLine("UP");
                game2048.Move(Direction.Up); // זה מחזיר את הנקודות- לעשות עם זה משהו
                ShowGameBoard();
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.DownArrow)
            {
                Console.WriteLine("DOWN");
                game2048.Move(Direction.Down);
                ShowGameBoard();
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.RightArrow)
            {
                Console.WriteLine("RIGHT");
                game2048.Move(Direction.Right);
                ShowGameBoard();
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.LeftArrow)
            {
                Console.WriteLine("LEFT");
                game2048.Move(Direction.Left);
                ShowGameBoard();
                Console.WriteLine("points: " + game2048.Points);
            }
        }
    }
}