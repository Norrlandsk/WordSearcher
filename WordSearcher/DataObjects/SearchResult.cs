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
        public SearchResult(string searchTerm, IOrderedEnumerable<KeyValuePair<int, int>> searchTermCount)
        {
            SearchTerm = searchTerm;
            SearchTermCount = searchTermCount;
        }

        public string SearchTerm { get; set; }

        public IOrderedEnumerable<KeyValuePair<int, int>> SearchTermCount { get; set; }

        public static void InsertSearchResult(SearchResult sr, Tree tree)
        {
            tree.Insert(sr);
        }
    }
}