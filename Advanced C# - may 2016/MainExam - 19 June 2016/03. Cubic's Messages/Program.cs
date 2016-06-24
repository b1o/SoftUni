namespace _03.Cubic_s_Messages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Over!")
            {
                string encrypredMessage = input.Trim();
                int count = int.Parse(Console.ReadLine());
                string pattern = @"^([\d]+)([A-Za-z]{" + count + "})([^A-Za-z]*)$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(encrypredMessage);

                if (match.Success)
                {
                    StringBuilder verificationCode = new StringBuilder();
                    string message = match.Groups[2].Value;
                    string indexes = match.Groups[1].Value + match.Groups[3].Value;

                    foreach (var index in indexes)
                    {
                        int a;
                        if (int.TryParse(index.ToString(), out a))
                        {
                            if (a < message.Length)
                            {
                                verificationCode.Append(message[a]);
                            }
                            else
                            {
                                verificationCode.Append(" ");
                            }
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
