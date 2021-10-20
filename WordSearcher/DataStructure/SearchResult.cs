namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SearchResult
    {
        private string _word;
        private List<Dictionary<DocumentObject, int>> _wordCount;

        public SearchResult(string word, List<Dictionary<DocumentObject, int>> wordCount)
        {
            _word = word;
            _wordCount = wordCount;
        }

        public string Word
        {
            get => _word;

            set => _word = value;
        }

        public List<Dictionary<DocumentObject, int>> WordCount
        {
            get => _wordCount;

            set => _wordCount = value;
        }
    }
}