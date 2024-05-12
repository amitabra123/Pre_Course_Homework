using System;
using System.Collections.Generic;

namespace PreCourseWorkProgramVS
{
    class Program
    {
        static void Main (string [] args)
        {
            LinkedList list = new LinkedList(10);
            list.Append(6);
            list.Prepend(34);
            list.Append(17);
            list.Append(43);
            list.Prepend(98);
            list.Prepend(22);
            list.Prepend(2);
            list.Append(100);
            Console.WriteLine("the last in list:" + list.Pop());
            Console.WriteLine("the first in list:" + list.Unqueue());
            Console.WriteLine("the list:");
            IEnumerator<int> theListIENumerator = list.ToList();
            while (theListIENumerator.MoveNext())
            {
                Console.WriteLine(theListIENumerator.Current);
            }
            Console.WriteLine("the min is:" + list.GetMinNode().Value);
            Console.WriteLine("the max is:" + list.GetMaxNode().Value);
            list.Sort();
            theListIENumerator = list.ToList();
            while (theListIENumerator.MoveNext())
            {
                Console.WriteLine(theListIENumerator.Current);
            }



            long num = 12;
            NumericalExpression numExp = new NumericalExpression(num);
            Console.WriteLine(numExp.ToString());
            Console.WriteLine(NumericalExpression.SumLetters(numExp));
        }
    }
}
