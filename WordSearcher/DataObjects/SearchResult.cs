namespace WordSearcher.DataStructure
{
    using System.Collections.Generic;
    using System.Linq;

    public class SearchResult
    {
        public SearchResult(string word, IOrderedEnumerable<KeyValuePair<int, int>> wordCount)
        {
            Word = word;
            WordCount = wordCount;
        }

        public string Word { get; set; }

        public IOrderedEnumerable<KeyValuePair<int, int>> WordCount { get; set; }
    }
}