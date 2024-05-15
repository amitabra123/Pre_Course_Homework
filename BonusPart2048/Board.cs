using System;

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

        public int Move(Direction moveInDirection)
        {
            int points;
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
            int points = 0;
            for(int moveTheCells = 0; moveTheCells < Data.GetLength(0); moveTheCells++)
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        if (Data[i, j] == 0 && j < Data.GetLength(1) - 1) // not one before the last 
                        {
                            Data[i, j] = Data[i, j + 1];
                            Data[i, j + 1] = 0;
                        }
                        else if (j < Data.GetLength(1) - 2)// not the last and not one before the last
                        {
                            if (Data[i, j] == Data[i, j + 1] )
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j + 1])
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j + 1] = Data[i, j + 2];
                                    Data[i, j + 2] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i, j + 1] = true;
                                }
                            }
                        }
                        else if(j == Data.GetLength(1) - 2)// one before the last
                        {
                           if (Data[i, j] == Data[i, j + 1])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j + 1])
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j + 1] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i, j + 1] = true;
                                }
                            }
                        }
                        
                        else if (j > 0 && j<Data.GetLength(1)-1)// not the first and not the last
                        {
                            if (Data[i, j] != 0 && Data[i, j - 1] == 0 && hasMerged[i,j-1])
                            {
                                Data[i, j - 1] = Data[i, j];
                                Data[i, j] = Data[i, j + 1];
                            }
                        }
                        else if(j == Data.GetLength(1) - 1)// the last
                        {
                            if (Data[i, j] != 0 && Data[i, j-1] == 0)
                            {
                                Data[i, j-1] = Data[i, j];
                                Data[i, j] = 0;
                            }
                            else if(Data[i,j] != 0 && Data[i,j] == Data[i,j-1])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j - 1])
                                {
                                    Data[i, j - 1] *= 2;
                                    Data[i, j] = 0;
                                    points += Data[i, j-1];
                                    hasMerged[i, j - 1] = true;
                                    hasMerged[i, j] = true;
                                }
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
                    for (int j = Data.GetLength(1)-1; j >= 0; j--)
                    {
                        if (Data[i, j] == 0 && j > 0) // not the last
                        {
                            Data[i, j] = Data[i, j - 1];
                            Data[i, j - 1] = 0;
                        }
                        else if(j > 1) // not the last and not one before the last
                        {
                            if (Data[i, j] == Data[i, j - 1])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j - 1])
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j - 1] = Data[i, j - 2];
                                    Data[i, j - 2] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i, j - 1] = true;
                                }
                            }
                        }
                        else if (j == 1)// one before the last
                        {
                            if (Data[i, j] == Data[i, j - 1])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j - 1])
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j - 1] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i, j - 1] = true;
                                }

                            }
                        }
                        else if (j < Data.GetLength(1)-1 && j > 0)// not the first and not the last
                        {
                            if (Data[i, j] != 0 && Data[i, j + 1] == 0)
                            {
                                Data[i, j + 1] = Data[i, j];
                                Data[i, j] = Data[i, j - 1];
                            }
                        }
                        else if(j == 0)// the last
                        {
                            if (Data[i, 0] != 0 && Data[i, 1] == 0)
                            {
                                Data[i, 1] = Data[i, 0];
                                Data[i, 0] = 0;
                            }
                            else if (Data[i, j] != 0 && Data[i, j] == Data[i, j + 1])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i, j + 1])
                                {
                                    Data[i, j + 1] *= 2;
                                    Data[i, j] = 0;
                                    points += Data[i, j + 1];
                                    hasMerged[i, j + 1] = true;
                                    hasMerged[i, j] = true;
                                }
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
                        if (Data[i, j] == 0 && i < Data.GetLength(0) - 1)// not the last
                        {
                            Data[i, j] = Data[i+1, j];
                            Data[i+1, j] = 0;
                        }
                        else if (i < Data.GetLength(0) - 2)// not the last and not one before the last
                        {
                            if (Data[i, j] == Data[i + 1, j])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i + 1, j])
                                {
                                    Data[i, j] *= 2;
                                    Data[i + 1, j] = Data[i + 2, j];
                                    Data[i + 2, j] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i + 1, j] = true;
                                }
                            }
                        }
                        else if(i == Data.GetLength(0) - 2)// one before the last
                        {
                            if (Data[i, j] == Data[i + 1, j])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i + 1, j])
                                {
                                    Data[i, j] *= 2;
                                    Data[i + 1, j] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i + 1, j] = true;
                                }
                            }
                        }
                        else if (i > 0 && i<Data.GetLength(0)-1)// not the first and not the last
                        {
                            if (Data[i, j] != 0 && Data[i-1, j] == 0)
                            {
                                Data[i-1, j] = Data[i, j];
                                Data[i, j] = Data[i+1, j];
                            }
                        }
                    }
                }
                for (int j = 0; j < Data.GetLength(1); j++) 
                {
                    if (Data[Data.GetLength(0) - 1, j] != 0 && Data[Data.GetLength(0) - 2, j] == 0)
                    {
                        Data[Data.GetLength(0) - 2, j] = Data[Data.GetLength(0) - 1, j];
                        Data[Data.GetLength(1) - 2, j] = 0;
                    }
                    else if (Data[Data.GetLength(0) - 1, j] != 0 && Data[Data.GetLength(0) - 1, j] == Data[Data.GetLength(0) - 2, j])
                    {
                        if (!hasMerged[Data.GetLength(0) - 1, j] && !hasMerged[Data.GetLength(0) - 2, j])
                        {
                            Data[Data.GetLength(0) - 2, j] *= 2;
                            Data[Data.GetLength(0) - 1, j] = 0;
                            points += Data[Data.GetLength(0) - 2, j];
                            hasMerged[Data.GetLength(0) - 2, j] = true;
                            hasMerged[Data.GetLength(0) - 1, j] = true;
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
                        if (Data[i, j] == 0 && i > 0)// not the last
                        {
                            Data[i, j] = Data[i-1, j];
                            Data[i-1, j] = 0;
                        }
                        else if (i > 1)// not the last and not before the last
                        {
                            if (Data[i, j] == Data[i - 1, j])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i - 1, j])
                                {
                                    Data[i, j] *= 2;
                                    Data[i - 1, j] = Data[i - 2, j];
                                    Data[i - 2, j] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i - 1, j] = true;
                                }
                            }
                        }
                        else if(i == 1)// one before the last
                        {
                            if (Data[i, j] == Data[i - 1, j])
                            {
                                if (!hasMerged[i, j] && !hasMerged[i - 1, j])
                                {
                                    Data[i, j] *= 2;
                                    Data[i - 1, j] = 0;
                                    points += Data[i, j];
                                    hasMerged[i, j] = true;
                                    hasMerged[i - 1, j] = true;
                                }
                            }
                        }
                        else if (i < Data.GetLength(0) - 1)// not the first
                        {
                            if (Data[i, j] != 0 && Data[i+1, j] == 0)
                            {
                                Data[i+1, j] = Data[i, j];
                                Data[i, j] = Data[i-1, j];
                            }
                        }
                    }
                }
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[0, j] != 0 && Data[1, j] == 0)
                    {
                        Data[1, j] = Data[0, j];
                        Data[0, j] = 0;
                    }
                    else if (Data[0, j] != 0 && Data[0, j] == Data[1, j])
                    {
                        if (!hasMerged[0, j] && !hasMerged[1, j])
                        {
                            Data[1, j] *= 2;
                            Data[0, j] = 0;
                            points += Data[1, j];
                            hasMerged[1, j] = true;
                            hasMerged[0, j] = true;
                        }
                    }
                }
            }
            return points;
        }
    }
}