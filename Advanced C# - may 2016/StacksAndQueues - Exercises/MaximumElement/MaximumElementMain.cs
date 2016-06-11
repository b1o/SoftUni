using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    public class MaximumElementMain
    {
        public static void Main()
        {
            int queryCount = int.Parse(Console.ReadLine());
            Stack<int> numberStack = new Stack<int>(); 

            for (int i = 0; i < queryCount; i++)
            {
                string[] queryTokens = Console.ReadLine().Split(' ');
                if (queryTokens.Length > 1)
                {
                    int numberToPush = int.Parse(queryTokens[1]);
                    numberStack.Push(numberToPush);
                }
                else
                {
                    switch (int.Parse(queryTokens[0]))
                    {
                        case 2:
                            if (numberStack.Count != 0)
                            {
                                numberStack.Pop();

                            }
                            break;
                        case 3:
                            Console.WriteLine(GetStackMaximumElement(numberStack));
                            break;
                    }
                }
            }
        }

        public static int GetStackMaximumElement(Stack<int> numbers)
        {
            return numbers.ToArray().Max();
        }
    }
}
