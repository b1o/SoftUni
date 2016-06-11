using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MatrixOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                var temp = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                matrix.Add(temp);
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandTokens = input.Split();
                switch (commandTokens[0])
                {
                    case "remove":
                        string type = commandTokens[1];
                        bool isRow = commandTokens[2] == "row" ? true : false;
                        int position = int.Parse(commandTokens[3]);
                        ApplyAction(matrix, type, isRow, position);
                        break;
                    case "swap":
                        int firstRow = int.Parse(commandTokens[1]);
                        int secondRow = int.Parse(commandTokens[2]);
                        SwapRows(matrix, firstRow, secondRow);
                        break;
                    case "insert":
                        int row = int.Parse(commandTokens[1]);
                        int element = int.Parse(commandTokens[2]);
                        InsertElement(matrix, row, element);
                        break;
                }

                input = Console.ReadLine();
            }

            matrix.ForEach(x => Console.WriteLine(string.Join(" ", x)));
        }

        public static void InsertElement(List<List<int>> matrix, int row, int element)
        {
            if (matrix.Count > row)
            {
                matrix[row].Insert(0, element);
            }
        }

        public static void SwapRows(List<List<int>> matrix, int firstRow, int secondRow)
        {
            if (matrix.Count > 1)
            {
                var temp = matrix[firstRow];
                matrix[firstRow] = matrix[secondRow];
                matrix[secondRow] = temp;
            }
        }

        private static void ApplyAction(List<List<int>> matrix, string type, bool isRow, int position)
        {
            switch (type)
            {
                case "positive":
                    if (isRow)
                    {
                        if (matrix.Count > position)
                        {
                            for (int i = 0; i < matrix[position].Count; i++)
                            {
                                if (matrix[position][i] > 0)
                                {
                                    matrix[position].RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i].Count > position)
                            {
                                if (matrix[i][position] > 0)
                                {
                                    matrix[i].RemoveAt(position);
                                }
                            }
                        }
                    }
                    break;
                case "negative":
                    if (isRow)
                    {
                        if (matrix.Count > position)
                        {
                            for (int i = 0; i < matrix[position].Count; i++)
                            {
                                if (matrix[position][i] < 0)
                                {
                                    matrix[position].RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i].Count > position)
                            {
                                if (matrix[i][position] < 0)
                                {
                                    matrix[i].RemoveAt(position);
                                }
                            }
                        }
                    }
                    break;
                case "odd":
                    if (isRow)
                    {
                        if (matrix.Count > position)
                        {
                            for (int i = 0; i < matrix[position].Count; i++)
                            {
                                if (matrix[position][i] % 2 != 0)
                                {
                                    matrix[position].RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i].Count > position)
                            {
                                if (matrix[i][position] % 2 != 0)
                                {
                                    matrix[i].RemoveAt(position);
                                }
                            }
                        }
                    }
                    break;
                case "even":
                    if (isRow)
                    {
                        if (matrix.Count > position)
                        {
                            for (int i = 0; i < matrix[position].Count; i++)
                        {
                            if (matrix[position][i] % 2 == 0)
                            {
                                matrix[position].RemoveAt(i);
                                i--;
                            }
                        }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i].Count > position)
                            {
                                if (matrix[i][position] % 2 == 0)
                                {
                                    matrix[i].RemoveAt(position);
                                }
                            }
                        }
                    }
                    break;

            }
        }
    }
}
