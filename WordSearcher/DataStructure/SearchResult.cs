namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchResult
    {
        private string _word;
        private Dictionary<int, int> _wordCount;

        public SearchResult(string word, Dictionary<int, int> wordCount)
        {
            _word = word;
            _wordCount = wordCount;
        }

        public string Word
        {
            get => _word;

            set => _word = value;
        }

        public Dictionary<int, int> WordCount
        {
            get => _wordCount;

            set => _wordCount = value;
        }

        //public DocumentObject GetDocumentObject()
        //{
        //    return this.DocumentObject();
        //}
    }
}