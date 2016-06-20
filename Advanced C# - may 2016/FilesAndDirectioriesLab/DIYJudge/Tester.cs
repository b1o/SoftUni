using System;
using System.IO;
using System.Reflection;

namespace DIYJudge
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            Console.WriteLine("Reading files...");

            var mistmatchPath = GetMismatchPath(expectedOutputPath);
            var actualOutputLines = File.ReadAllLines(userOutputPath);
            var expectedOutputlines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatch;
            var mistmatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputlines, out hasMismatch);

            PrintOutput(mistmatches, hasMismatch, mistmatchPath);
            Console.WriteLine("Files Read!");
        }

        private static void PrintOutput(string[] mistmatches, bool hasMismatch, string mistmatchPath)
        {
            if (hasMismatch)
            {
                foreach (var mistmatch in mistmatches)
                {
                    Console.WriteLine(mistmatch);
                }

                File.WriteAllLines(mistmatchPath, mistmatches);
                return;
            }
        }


        private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines,
            out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            string[] mismatches = new string[actualOutputLines.Length];
            Console.WriteLine("Comparing Files...");

            for (int i = 0; i < actualOutputLines.Length; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLine = expectedOutputLines[i];

                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at {i} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }
            return mismatches;
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            var indexOf = expectedOutputPath.LastIndexOf('\\');
            var directoryPath = expectedOutputPath.Substring(0, indexOf);
            var finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}