using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordSearcher.DataObjects;

namespace WordSearcher.Query
{
    internal static class Search
    {
        public static void PrintXAmount(List<DocumentObject> docObj)
        {
            int searchAmount = UserInputInt();
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

        public static void PrintSearchResult(SearchResult sr)
        {
            Console.WriteLine($"Search term: {sr.Word}\n");
            foreach (var item in sr.WordCount)
            {
                Console.WriteLine($"Document ID: {item.Key}");
                Console.WriteLine($"Instances of search term: {item.Value}\n");
            }
        }

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
                    Console.WriteLine("Invalid input, try again!");
                }
                else
                {
                    isValid = true;
                }
                
            } while (!isValid);
            
            return userInput;
        }

        private static int UserInputInt()
        {
            Console.Write("Enter the amount of words to print: ");
            return Utils.ConfirmCorrectInput();
        }
    }
}