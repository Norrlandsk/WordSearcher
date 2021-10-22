namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SearchResult
    {
        private string _word;
        private IOrderedEnumerable<KeyValuePair<int, int>> _wordCount;

        //public SearchResult(string word, Dictionary<int, int> wordCount)
        //{
        //    _word = word;
        //    _wordCount = wordCount;
        //}

        public SearchResult(string word, IOrderedEnumerable<KeyValuePair<int, int>> wordCount)
        {
            _word = word;
            _wordCount = wordCount;
        }

        public string Word
        {
            get => _word;

            set => _word = value;
        }

        public IOrderedEnumerable<KeyValuePair<int, int>> WordCount
        {
            get => _wordCount;

            set => _wordCount = value;
        }
    }
}