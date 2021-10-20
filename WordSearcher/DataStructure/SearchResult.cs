namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SearchResult
    {
        private string _word;
        private Dictionary<DocumentObject, int> _wordCount;

        public SearchResult(string word, Dictionary<DocumentObject, int> wordCount)
        {
            _word = word;
            _wordCount = wordCount;
        }

        public string Word
        {
            get => _word;

            set => _word = value;
        }

        public Dictionary<DocumentObject, int> WordCount
        {
            get => _wordCount;

            set => _wordCount = value;
        }
    }
}