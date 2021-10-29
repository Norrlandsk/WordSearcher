namespace WordSearcher.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using WordSearcher.DataObjects;

    /// <summary>
    /// Class for handling searches.
    /// </summary>
    internal static class Search
    {
        /// <summary>
        /// Prints the amount of words specified by the user.
        /// n(m^2+m+p) -> O(nm^2+nm+np) -> O(nm^2)
        /// </summary>
        public static void PrintXAmount(List<DocumentObject> docObjList)
        {
            int searchAmount = UserInputInt();

            if (searchAmount >= 1)
            {
                foreach (var item in docObjList) 
                {
                    Array.Sort(item.TextSplitArr);
                    string[] singleWords = item.TextSplitArr.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
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
                PrintXAmount(docObjList);
            }
        }

        /// <summary>
        /// Searches for word specified by the user.
        /// n(m^2+p^2) -> O(nm^2+np^2) -> O(nm^2)
        /// </summary>
        /// <returns>SearchResult object.</returns>
        public static SearchResult SearchForWord(List<DocumentObject> docObjList)
        {
            string searchTerm = UserInputString();
            string searchPattern = string.Format(@"\b{0}\b", searchTerm);
            int counter = 0;

            Dictionary<int, int> searchTermCount = new Dictionary<int, int>();

            foreach (var item in docObjList)
            {
                counter = Regex.Matches(item.Text, searchPattern, RegexOptions.IgnoreCase).Count();

                searchTermCount.Add(item.Id, counter);
            }
            var orderedWordCount = searchTermCount.OrderByDescending(c => c.Value);

            SearchResult searchResult = new SearchResult(searchTerm, orderedWordCount);
            SearchResult.InsertSearchResult(searchResult, Setup.tree);
            return searchResult;
        }

        /// <summary>
        /// Is a helper method for SearchForWord(), prints out the result.
        /// O(n)
        /// </summary>
        public static void PrintSearchResult(SearchResult searchResult)
        {
            Console.WriteLine($"Search term: {searchResult.SearchTerm}\n");
            foreach (var item in searchResult.SearchTermCount)
            {
                Console.WriteLine($"Document ID: {item.Key}");
                Console.WriteLine($"Instances of search term: {item.Value}\n");
            }
        }

        /// <summary>
        /// Verifies correct string input from user.
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

                if (userInput <= 0)
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