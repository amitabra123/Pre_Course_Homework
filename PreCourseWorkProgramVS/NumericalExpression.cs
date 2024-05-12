using System;

namespace PreCourseWorkProgramVS
{
    class NumericalExpression
    {
        private const int NOTHING_IN_ARRAY = -1;
        private const int UNITS_START_RANGE = 2;
        private const int UNITS_END_RANGE = 5;
        private const int TENS_END_RANGE = 8;
        private const int HUNDREDS_END_RANGE = 11;
        private const int UNITS_LENGTH_START_RANGE = 1;
        private const int UNITS_LENGTH_END_RANGE = 3;
        private const int HUNDREDS_LENGTH_START_RANGE = 4;
        private const int HUNDREDS_LENGTH_END_RANGE = 6;
        private const int MILLIONS_LENGTH_START_RANGE = 7;
        private const int MILLIONS_LENGTH_END_RANGE = 9;
        private const int BILLIONS_LENGTH_START_RANGE = 10;
        private const int BILLIONS_LENGTH_END_RANGE = 12;

        public long Number;
        private string[] unitsDigits = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private string[] tensDigits = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private string[] unitsForOneTen = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        public NumericalExpression(long number)
        {
            Number = number;
        }


        public override string ToString()
        {
            string theNumericalExpression = "";
            if (Number == 0)
            {
                theNumericalExpression = "zero";
                return theNumericalExpression;
            }
            string numberToString = Number.ToString();
            int[] numberToDigits = new int[numberToString.Length];
            for (int i = 0; i < numberToDigits.Length; i++)
            {
                numberToDigits[numberToDigits.Length - 1 - i] = int.Parse(numberToString[i] + "");
            }

            int[] threeFirstDigits = new int[3];
            int[] threeSecondDigits = new int[3];
            int[] threeThirdDigits = new int[3];
            int[] threeFourthDigits = new int[3];
            for (int i = 0; i < threeFirstDigits.Length; i++)
                threeFirstDigits[i] = NOTHING_IN_ARRAY;
            for (int i = 0; i < threeSecondDigits.Length; i++)
                threeSecondDigits[i] = NOTHING_IN_ARRAY;
            for (int i = 0; i < threeThirdDigits.Length; i++)
                threeThirdDigits[i] = NOTHING_IN_ARRAY;
            for (int i = 0; i < threeFourthDigits.Length; i++)
                threeFourthDigits[i] = NOTHING_IN_ARRAY;


            int indexInFirstArr = 0;
            int indexInSecondArr = 0;
            int indexInThirdArr = 0;
            int indexInFourthArr = 0;
            for (int i = 0; i < numberToDigits.Length; i++)
            {
                if (i <= UNITS_START_RANGE)
                {
                    threeFirstDigits[indexInFirstArr] = numberToDigits[i];
                    indexInFirstArr++;
                }
                else if (i > UNITS_START_RANGE && i <= UNITS_END_RANGE)
                {
                    threeSecondDigits[indexInSecondArr] = numberToDigits[i];
                    indexInSecondArr++;
                }
                else if (i > UNITS_END_RANGE && i <= TENS_END_RANGE)
                {
                    threeThirdDigits[indexInThirdArr] = numberToDigits[i];
                    indexInThirdArr++;
                }
                else if (i > TENS_END_RANGE && i <= HUNDREDS_END_RANGE)
                {
                    threeFourthDigits[indexInFourthArr] = numberToDigits[i];
                    indexInFourthArr++;
                }
            }

            if (numberToString.Length >= BILLIONS_LENGTH_START_RANGE && numberToString.Length <= BILLIONS_LENGTH_END_RANGE)
            {
                theNumericalExpression += BillionsToString(threeFourthDigits);
                theNumericalExpression += MillionsToString(threeThirdDigits);
                theNumericalExpression += ThousandsToString(threeSecondDigits);
                theNumericalExpression += UnitsToString(threeFirstDigits);
            }
            else if (numberToString.Length >= MILLIONS_LENGTH_START_RANGE && numberToString.Length <= MILLIONS_LENGTH_END_RANGE)
            {
                theNumericalExpression += MillionsToString(threeThirdDigits);
                theNumericalExpression += ThousandsToString(threeSecondDigits);
                theNumericalExpression += UnitsToString(threeFirstDigits);
            }
            else if (numberToString.Length >= HUNDREDS_LENGTH_START_RANGE && numberToString.Length <= HUNDREDS_LENGTH_END_RANGE)
            {
                theNumericalExpression += ThousandsToString(threeSecondDigits);
                theNumericalExpression += UnitsToString(threeFirstDigits);
            }
            else if (numberToString.Length >= UNITS_LENGTH_START_RANGE && numberToString.Length <= UNITS_LENGTH_END_RANGE)
            {
                theNumericalExpression += UnitsToString(threeFirstDigits);
            }
            return theNumericalExpression;
        }


        private string UnitsToString(int[] firstThreeDigits)
        {
            string theNumericalExpression = "";
            if (firstThreeDigits[2] != NOTHING_IN_ARRAY && firstThreeDigits[2] != 0)
            {
                theNumericalExpression += unitsDigits[firstThreeDigits[2]];
                theNumericalExpression += " hundred ";
            }
            if (firstThreeDigits[1] == 1)
            {
                theNumericalExpression += unitsForOneTen[firstThreeDigits[0]];
                return theNumericalExpression;
            }
            if (firstThreeDigits[1] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += tensDigits[firstThreeDigits[1]];
                theNumericalExpression += " ";
            }
            if (firstThreeDigits[0] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += unitsDigits[firstThreeDigits[0]];
            }
            return theNumericalExpression;

        }
        private string ThousandsToString(int[] secondThreeDigits)
        {
            string theNumericalExpression = "";
            if (secondThreeDigits[0] == 0 && secondThreeDigits[1] == 0 && secondThreeDigits[2] == 0)
                return theNumericalExpression;
            if (secondThreeDigits[2] != NOTHING_IN_ARRAY && secondThreeDigits[2] != 0)
            {
                theNumericalExpression += unitsDigits[secondThreeDigits[2]];
                theNumericalExpression += " hundred ";
            }
            if (secondThreeDigits[1] == 1)
            {
                theNumericalExpression += unitsForOneTen[secondThreeDigits[0]];
                theNumericalExpression += " thousand ";
                return theNumericalExpression;
            }
            if (secondThreeDigits[1] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += tensDigits[secondThreeDigits[1]];
                theNumericalExpression += " ";
            }
            if (secondThreeDigits[0] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += unitsDigits[secondThreeDigits[0]];
            }
            if (secondThreeDigits[0] != NOTHING_IN_ARRAY || secondThreeDigits[1] != NOTHING_IN_ARRAY || secondThreeDigits[2] !=NOTHING_IN_ARRAY)
            {
                theNumericalExpression += " thousand ";
            }
            return theNumericalExpression;
        }
        private string MillionsToString(int[] thirdThreeDigits)
        {
            string theNumericalExpression = "";
            if (thirdThreeDigits[0] == 0 && thirdThreeDigits[1] == 0 && thirdThreeDigits[2] == 0)
                return theNumericalExpression;
            if (thirdThreeDigits[2] != NOTHING_IN_ARRAY && thirdThreeDigits[2] != 0)
            {
                theNumericalExpression += unitsDigits[thirdThreeDigits[2]];
                theNumericalExpression += " hundred ";
            }
            if (thirdThreeDigits[1] == 1)
            {
                theNumericalExpression += unitsForOneTen[thirdThreeDigits[0]];
                theNumericalExpression += " million ";
                return theNumericalExpression;
            }
            if (thirdThreeDigits[1] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += tensDigits[thirdThreeDigits[1]];
                theNumericalExpression += " ";
            }
            if (thirdThreeDigits[0] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += unitsDigits[thirdThreeDigits[0]];
            }
            if (thirdThreeDigits[0] != NOTHING_IN_ARRAY || thirdThreeDigits[1] != -1 || thirdThreeDigits[2] != -1)
            {
                theNumericalExpression += " million ";
            }
            return theNumericalExpression;
        }
        private string BillionsToString(int[] fourthThreeDigits)
        {
            string theNumericalExpression = "";
            if (fourthThreeDigits[2] != NOTHING_IN_ARRAY && fourthThreeDigits[2] != 0)
            {
                theNumericalExpression += unitsDigits[fourthThreeDigits[2]];
                theNumericalExpression += " hundred ";
            }
            if (fourthThreeDigits[1] == 1)
            {
                theNumericalExpression += unitsForOneTen[fourthThreeDigits[0]];
                theNumericalExpression += " billion ";
                return theNumericalExpression;
            }
            if (fourthThreeDigits[1] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += tensDigits[fourthThreeDigits[1]];
                theNumericalExpression += " ";
            }
            if (fourthThreeDigits[0] != NOTHING_IN_ARRAY)
            {
                theNumericalExpression += unitsDigits[fourthThreeDigits[0]];
            }
            if (fourthThreeDigits[0] != NOTHING_IN_ARRAY || fourthThreeDigits[1] != -1 || fourthThreeDigits[2] != -1)
            {
                theNumericalExpression += " billion ";
            }
            return theNumericalExpression;
        }


        public long GetValue()
        {
            return Number;
        }

        public static long SumLetters(long num)
        {
            string numericalExp;
            long sumOfLettersExpression = 0;
            NumericalExpression numExpression;
            for(long i = 0; i <= num; i++)
            {
                numExpression = new NumericalExpression(i);
                numericalExp = numExpression.ToString();
                sumOfLettersExpression += numExpression.NumOfLettersInExpression(numericalExp);
            }
            return sumOfLettersExpression;
        }
        private int NumOfLettersInExpression(string expression)
        {
            int numberOfLettersInExpression = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsLetter(expression[i]))
                {
                    numberOfLettersInExpression++;
                }
            }
            return numberOfLettersInExpression;
        }

        // Polymorphism allows us to perform a single action in different ways.
        // method overloading is the most common way of implementing polymorphism:
        // the overloading gives us the abillity to redefine a method in more than one way. 
        // it allows us to build several methods with the same names, 
        //                          only if the number of parameters is different or the parameters' types are different.
        public static long SumLetters(NumericalExpression numExpr)
        {
            string numericalExp;
            long sumOfLettersExpression = 0;
            NumericalExpression numExpression;
            for (long i = 0; i <= numExpr.Number; i++)
            {
                numExpression = new NumericalExpression(i);
                numericalExp = numExpression.ToString();
                sumOfLettersExpression += numExpression.NumOfLettersInExpression(numericalExp);
            }
            return sumOfLettersExpression;
        }
    }
}