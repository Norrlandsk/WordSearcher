using System;
using System.Threading;

namespace WordSearcher
{
    /// <summary>
    /// Helper class. Contains methods to verify user input.
    /// </summary>
    internal static class Utils
    {
        public static int ConfirmCorrectInput(int allowedRange)
        {
            int confirmedChoice;
            do
            {
                string menuChoiceString = Console.ReadLine();

                bool successfulConversion = Int32.TryParse(menuChoiceString, out confirmedChoice);

                if (successfulConversion && confirmedChoice <= allowedRange && confirmedChoice > 0)
                {
                    break;
                }
                else if (string.IsNullOrWhiteSpace(menuChoiceString))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Invalid input!");
                    Thread.Sleep(1050);
                    Console.Clear();
                    break;
                }
            } while (true);
            return confirmedChoice;
        }

        public static int ConfirmCorrectInput()
        {
            int confirmedChoice;
            do
            {
                string menuChoiceString = Console.ReadLine();

                bool successfulConversion = Int32.TryParse(menuChoiceString, out confirmedChoice);

                if (successfulConversion && confirmedChoice > 0)
                {
                    break;
                }
                else if (string.IsNullOrWhiteSpace(menuChoiceString))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Invalid input!");
                    Thread.Sleep(1050);
                    Console.Clear();
                    break;
                }
            } while (true);
            return confirmedChoice;
        }

        public static void ContinueAndClear()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}