using System;
using System.Collections;
using System.Collections.Generic;

namespace BonusPart2048
{
    class Program
    {
        public enum Direction
        {
            Up,   //0
            Down, //1
            Left, //2
            Right //3
        }

        public enum GameStatus
        {
            Win,  //0
            Lose, //1
            Idle  //2
        }

        static void Main(string[] args)
        {
            ConsoleGame consoleGameBoard2048 = new ConsoleGame();
            consoleGameBoard2048.StartAGame();


            /*            Console.WriteLine("Hello World!");
                        Game game2048 = new Game();
                        game2048.Board2048.Put2Or4InTwoRandomCells();
                        game2048.Board2048.PrintBoard();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        game2048.Move(Direction.Down);
                        Console.WriteLine("points: " + game2048.Points);
                        game2048.Board2048.PrintBoard();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        game2048.Move(Direction.Left);
                        Console.WriteLine("points: " + game2048.Points);
                        game2048.Board2048.PrintBoard();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        game2048.Move(Direction.Up);
                        Console.WriteLine("points: " + game2048.Points);
                        game2048.Board2048.PrintBoard();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        game2048.Move(Direction.Right);
                        Console.WriteLine("points: " + game2048.Points);
                        game2048.Board2048.PrintBoard();*/



            /*
            Board board2048 = new Board();
            board2048.Put2Or4InTwoRandomCells();
            board2048.PrintBoard();
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("points: " + board2048.Move(Direction.Left));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Up));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Right));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Left));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Down));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Up));
            board2048.PrintBoard();

            Console.WriteLine("points: " + board2048.Move(Direction.Left));
            board2048.PrintBoard();*/
        }
    }
}
