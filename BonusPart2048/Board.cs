using System;
using System.Collections.Generic;
using System.Text;

namespace BonusPart2048
{
    class Board
    {
        public int [, ] Data { get; protected set; }

        public Board()
        {
            Data = new int[4, 4];
        }

        public void Put2Or4InTwoRandomCells()
        {
            Random randomCell = new Random();
            int firstRandomRow = randomCell.Next(4);
            int firstRandomColumn = randomCell.Next(4);
            int secondRandomRow = randomCell.Next(4);
            int secondRandomColumn = randomCell.Next(4);
            while (firstRandomRow == secondRandomRow)
            {
                secondRandomRow = randomCell.Next(4);
            }
            while (secondRandomColumn == firstRandomColumn)
            {
                secondRandomColumn = randomCell.Next(4);
            }
            Data[firstRandomRow, firstRandomColumn] = 2;
            Data[secondRandomRow, secondRandomColumn] = 4;
        }

        public int Move(Direction moveInDirection)
        {
            int points = 0;
            if (moveInDirection.Equals(Direction.Left))
            {
                points = MoveLeft();
            }
            else if (moveInDirection.Equals(Direction.Right))
            {
                points = MoveRight();
            }
            else if (moveInDirection.Equals(Direction.Up))
            {
               points = MoveUp();
            }
            else
            {
               points = MoveDown();
            }
            AddNew2Or4InARandomCell();
            return points;
        }

        private int MoveLeft()
        {
            bool[,] hasMerged = new bool[Data.GetLength(0), Data.GetLength(1)];
            // מטריצה של שקר- אם תא עבר מיזוג בתור הנוכחי יהפוך לאמת
            //bool hasMerged = false;
            int points = 0;
            for(int moveTheCells = 0; moveTheCells < Data.GetLength(0); moveTheCells++)
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    for (int j = 0; j < Data.GetLength(1) - 1; j++)
                    {
                        if (Data[i, j] == 0 && j < Data.GetLength(1) - 1)
                        {
                            Data[i, j] = Data[i, j + 1];
                            Data[i, j + 1] = 0;
                        }
                        else if (Data[i, j] == Data[i, j + 1] && j < Data.GetLength(1) - 2)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i, j + 1] = Data[i, j + 2];
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (Data[i, j] == Data[i, j + 1] && j == Data.GetLength(1) - 2)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i, j + 1] = 0;
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (j > 0)
                        {
                            if (Data[i, j] != 0 && Data[i, j - 1] == 0)
                            {
                                Data[i, j - 1] = Data[i, j];
                                Data[i, j] = Data[i, j + 1];
                            }
                        }
                    }
                }
            }
            return points;
        }

        private int MoveRight()
        {
            bool[,] hasMerged = new bool[Data.GetLength(0), Data.GetLength(1)];
            int points = 0;
            for (int moveTheCells = 0; moveTheCells < Data.GetLength(0); moveTheCells++)
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    for (int j = Data.GetLength(1)-1; j > 0; j--)
                    {
                        if (Data[i, j] == 0 && j > 0)
                        {
                            Data[i, j] = Data[i, j - 1];
                            Data[i, j - 1] = 0;
                        }
                        else if (Data[i, j] == Data[i, j - 1] && j > 1)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i, j - 1] = Data[i, j - 2];
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (Data[i, j] == Data[i, j - 1] && j == 1)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i, j - 1] = 0;
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                           
                        }
                        else if (j < Data.GetLength(1)-1)
                        {
                            if (Data[i, j] != 0 && Data[i, j + 1] == 0)
                            {
                                Data[i, j + 1] = Data[i, j];
                                Data[i, j] = Data[i, j - 1];
                            }
                        }
                    }
                }
            }
            return points;
        }
        private int MoveUp()
        {
            bool[,] hasMerged = new bool[Data.GetLength(0), Data.GetLength(1)];
            int points = 0;
            for (int moveTheCells = 0; moveTheCells < Data.GetLength(0); moveTheCells++)
            {
                for (int i = 0; i < Data.GetLength(0)-1; i++)
                {
                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        if (Data[i, j] == 0 && i < Data.GetLength(0) - 1)
                        {
                            Data[i, j] = Data[i+1, j];
                            Data[i+1, j] = 0;
                        }
                        else if (Data[i, j] == Data[i+1, j] && i < Data.GetLength(0) - 2) 
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i + 1, j] = Data[i + 2, j];
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (Data[i, j] == Data[i+1, j] && i == Data.GetLength(0) - 2)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i + 1, j] = 0;
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (i > 0)
                        {
                            if (Data[i, j] != 0 && Data[i-1, j] == 0)
                            {
                                Data[i-1, j] = Data[i, j];
                                Data[i, j] = Data[i+1, j];
                            }
                        }
                    }
                }
            }
            return points;
        }
        private int MoveDown()
        {
            bool[,] hasMerged = new bool[Data.GetLength(0), Data.GetLength(1)];
            int points = 0;
            for (int moveTheCells = 0; moveTheCells < Data.GetLength(0); moveTheCells++)
            {
                for (int i = Data.GetLength(0)-1; i > 0; i--)
                {
                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        if (Data[i, j] == 0 && i > 0)
                        {
                            Data[i, j] = Data[i-1, j];
                            Data[i-1, j] = 0;
                        }
                        else if (Data[i, j] == Data[i-1, j] && i > 1)
                        {
                            if (hasMerged[i, j] == false)
                            {
                                Data[i, j] *= 2;
                                Data[i - 1, j] = Data[i - 2, j];
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (Data[i, j] == Data[i-1, j] && i == 1)
                        {
                            if (hasMerged[i, j]==false)
                            {
                                Data[i, j] *= 2;
                                Data[i - 1, j] = 0;
                                points += Data[i, j];
                                hasMerged[i, j] = true;
                            }
                        }
                        else if (i < Data.GetLength(0) - 1)
                        {
                            if (Data[i, j] != 0 && Data[i+1, j] == 0)
                            {
                                Data[i+1, j] = Data[i, j];
                                Data[i, j] = Data[i-1, j];
                            }
                        }
                    }
                }
            }
            return points;
        }
        private void AddNew2Or4InARandomCell()
        {
            Random findRandomCell = new Random();
            int randomRow = findRandomCell.Next(4);
            int randomColumn = findRandomCell.Next(4);
            bool put2Or4InCell = false;
            while (put2Or4InCell == false)
            {
                if (Data[randomRow, randomColumn] == 0)
                {
                    int random2Or4InCell = findRandomCell.Next(2);
                    if (random2Or4InCell == 0)
                        Data[randomRow, randomColumn] = 2;
                    else
                        Data[randomRow, randomColumn] = 4;
                    put2Or4InCell = true;
                }
                else
                {
                    randomRow = findRandomCell.Next(4);
                    randomColumn = findRandomCell.Next(4);
                }
            }
        }


        // למחוק את  הפונקציה הזו בסוף!!
        public void PrintBoard()
        {
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    Console.Write(Data[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}