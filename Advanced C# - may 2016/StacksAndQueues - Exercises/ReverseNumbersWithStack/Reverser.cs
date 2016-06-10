using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    public class Reverser
    {
        public static void Main()
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Stack<int> numbersStack = new Stack<int>();

            foreach (var number in input)
            {
                numbersStack.Push(number);
            }

            for (int i = 0; i < numbersStack.Count; i++)
            {
                Console.Write($"{numbersStack.Pop()} ");
            }
        }
    }
}
