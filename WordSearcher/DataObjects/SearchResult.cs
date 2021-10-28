namespace WordSearcher.DataObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using WordSearcher.DataStructure;

    /// <summary>
    /// Class for handling search results. Contains the search term in a string,
    /// and how many instances the search term was present in each document in a IOrderedEnumerable&lt;KeyValuePair&gt;
    /// </summary>
    internal class SearchResult
    {
        public SearchResult(string word, IOrderedEnumerable<KeyValuePair<int, int>> wordCount)
        {
            Word = word;
            WordCount = wordCount;
        }

        public string Word { get; set; }

        public IOrderedEnumerable<KeyValuePair<int, int>> WordCount { get; set; }

        public static void InsertSearchResult(SearchResult sr, Tree tree)
        {
            tree.Insert(sr);
        }
    }
}