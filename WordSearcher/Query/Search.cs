using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WordSearcher.DataStructure;

namespace WordSearcher.Query
{
    class Search
    {
        public static void PrintXAmount(int userInput, List<DocumentObject> docObj)
        {
            foreach (var item in docObj)
            {
                Array.Sort(item.WordsInText);
                string[] singleWords = item.WordsInText.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
                Console.WriteLine($"\nDocument ID: { item.Id }");

                for (int i = 0; i < userInput; i++)
                {
                    Console.WriteLine(singleWords[i]);

                }
            }
        }
        public static SearchResult SearchForWord(string userInput, List<DocumentObject> docObj)
        {
            string pattern = string.Format(@"\b{0}\b", userInput);
            int counter = 0;

            Dictionary<int, int> wordCount = new Dictionary<int, int>();

            foreach (var item in docObj)
            {
                counter = Regex.Matches(item.Text, pattern, RegexOptions.IgnoreCase).Count();

                wordCount.Add(item.Id, counter);
            }
            var orderedWordCount = wordCount.OrderByDescending(c => c.Value);

            SearchResult sr = new SearchResult(userInput, orderedWordCount);
            InsertSearchResult(sr);
            return sr;
        }
    }
}
