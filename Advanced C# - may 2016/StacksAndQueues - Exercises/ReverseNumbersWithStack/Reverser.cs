using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    public class Reverser
    {
        public static void Main()
        {
            Stack<int> numberStack = new Stack<int>();

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            foreach (var i in input)
            {
                numberStack.Push(i);
            }

            for (int i = 0; i < input.Count; i++)
            {
                Console.Write($"{numberStack.Pop()} ");
            }
        }
    }
}
