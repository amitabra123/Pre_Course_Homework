using System;


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
        {
            game2048.Board2048.Put2Or4InTwoRandomCells(); 
            while(game2048.TheGameStatus == GameStatus.Idle && !userChoseToExit) 
            {
                Console.Clear();
                ShowGameBoard();
                UserChooseDirection();
            }
            if(game2048.TheGameStatus == GameStatus.Lose)
            {
                ShowGameBoard();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry you lost!");
                Console.WriteLine("Bye Bye");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }    
            else if(!userChoseToExit)
            {
                ShowGameBoard();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wow!! you won (2048!)");
                Console.WriteLine("Bye Bye");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }

        private void ShowGameBoard()
        {
            for (int i = 0; i < game2048.Board2048.Data.GetLength(0); i++)
            {
                for (int j = 0; j < game2048.Board2048.Data.GetLength(1); j++)
                {
                    Console.Write(game2048.Board2048.Data[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public void UserChooseDirection()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("please choose a direction!- to exit press enter");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            ConsoleKey userChooseDirection = Console.ReadKey().Key;
            while (userChooseDirection != ConsoleKey.UpArrow && userChooseDirection != ConsoleKey.DownArrow &&
                userChooseDirection != ConsoleKey.RightArrow && userChooseDirection != ConsoleKey.LeftArrow &&
                userChooseDirection != ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n please choose a valid direction (UpArrow, DownArrow, LeftArrow or RightArrow)!!");
                userChooseDirection = Console.ReadKey().Key;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (userChooseDirection == ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU CHOSE TO EXIT!");
                Console.WriteLine("BYE BYE!");
                Console.ForegroundColor = ConsoleColor.White;
                userChoseToExit = true;
                return;
            }
            MoveAccordingToDirection(userChooseDirection);
        }


        private void MoveAccordingToDirection(ConsoleKey userChooseDirection)
        {
            if (userChooseDirection == ConsoleKey.UpArrow)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("UP");
                Console.ForegroundColor = ConsoleColor.Gray;
                game2048.Move(Direction.Up);
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.DownArrow)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("DOWN");
                Console.ForegroundColor = ConsoleColor.Gray;
                game2048.Move(Direction.Down);
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.RightArrow)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("RIGHT");
                game2048.Move(Direction.Right);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("points: " + game2048.Points);
            }
            else if (userChooseDirection == ConsoleKey.LeftArrow)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("LEFT");
                Console.ForegroundColor = ConsoleColor.Gray;
                game2048.Move(Direction.Left);
                Console.WriteLine("points: " + game2048.Points);
            }
        }
    }
}