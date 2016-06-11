using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class BasicStackOperationsMain
    {
        public static void Main()
        {
            List<int> commandTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Stack<int> numberStack = new Stack<int>();

            int pushCount = commandTokens[0];
            int popCount = commandTokens[1];
            int searchedElement = commandTokens[2];

            List<int> inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < pushCount; i++)
            {
                numberStack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                numberStack.Pop();
            }

            if (numberStack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numberStack.Count > 0)
                {
                    int smallestElement = int.MaxValue;

                    while (numberStack.Count > 0)
                    {
                        int currentElement = numberStack.Pop();
                        if (currentElement < smallestElement)
                        {
                            smallestElement = currentElement;
                        }
                    }

                    Console.WriteLine(smallestElement);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
