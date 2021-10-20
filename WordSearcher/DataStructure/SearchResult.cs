namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SearchResult
    {
        private string _text;
        private List<Dictionary<DocumentObject, int>> _wordCount;

        public SearchResult(string text, List<Dictionary<DocumentObject, int>> wordCount)
        {
            _text = text;
            _wordCount = wordCount;
        }

        public string Text
        {
            get => _text;

            set => _text = value;
        }

        public List<Dictionary<DocumentObject, int>> WordCount
        {
            get => _wordCount;

            set => _wordCount = value;
        }
    }
}