using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using WordSearcher.DataObjects;

namespace WordSearcher.Query
{
    /// <summary>
    /// Class for handling searches.
    /// </summary>
    internal static class Search
    {
        /// <summary>
        /// Prints the amount of words specified by the user.
        /// </summary>
        /// <param name="docObj"></param>
        public static void PrintXAmount(List<DocumentObject> docObj)
        {
            int searchAmount = UserInputInt();

            if (searchAmount >= 1)
            {

                foreach (var item in docObj)
                {
                    Array.Sort(item.WordsInText);
                    string[] singleWords = item.WordsInText.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
                    Console.WriteLine($"\nDocument ID: { item.Id }");

                    for (int i = 0; i < searchAmount && i < singleWords.Length; i++)
                    {
                        Console.WriteLine(singleWords[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                PrintXAmount(docObj);
            }
        }

        /// <summary>
        /// Searches for word specified by the user.
        /// O(n^2+10)
        /// </summary>
        /// <param name="docObj"></param>
        /// <returns>SearchResult object.</returns>
        public static SearchResult SearchForWord(List<DocumentObject> docObj)
        {
            string searchWord = UserInputString();
            string searchPattern = string.Format(@"\b{0}\b", searchWord);
            int counter = 0;

            Dictionary<int, int> wordCount = new Dictionary<int, int>();

            foreach (var item in docObj)
            {
                counter = Regex.Matches(item.Text, searchPattern, RegexOptions.IgnoreCase).Count();

                wordCount.Add(item.Id, counter);
            }
            var orderedWordCount = wordCount.OrderByDescending(c => c.Value);

            SearchResult sr = new SearchResult(searchWord, orderedWordCount);
            SearchResult.InsertSearchResult(sr, Program.tree);
            return sr;
        }

        /// <summary>
        /// Is a helper method for SearchForWord(), prints out the result.
        /// O(n+3)
        /// </summary>
        /// <param name="sr"></param>
        public static void PrintSearchResult(SearchResult sr)
        {
            
            Console.WriteLine($"Search term: {sr.Word}\n");
            foreach (var item in sr.WordCount)
            {
                Console.WriteLine($"Document ID: {item.Key}");
                Console.WriteLine($"Instances of search term: {item.Value}\n");
            }
        }

        /// <summary>
        /// Verifies correct string input from user.
        /// O(n+11)
        /// </summary>
        /// <returns>Verified string input from user.</returns>
        private static string UserInputString()
        {
            bool isValid = false;
            string userInput;
            do
            {
                
                Console.Write("Enter the word to search for: ");
                userInput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(userInput))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, try again!");
                    Thread.Sleep(1250);
                    Console.Clear();
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            return userInput;
        }

        /// <summary>
        /// Verifies correct int input from user.
        /// O(n+8)
        /// </summary>
        /// <returns>Verified int input from user.</returns>
        private static int UserInputInt()
        {
            bool isValid = false;
            int userInput;
            do
            {
                Console.Write("Enter the amount of words to print: ");
                userInput = Utils.ConfirmCorrectInput();

                if(userInput <= 0)
                {
                    break;
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            return userInput;
        }
    }
}