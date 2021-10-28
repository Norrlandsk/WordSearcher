namespace WordSearcher.DataObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for handling incoming text files. Dynamically sets id. Contains both the original text in one string,
    /// and the original text split into seperate words in a string array with the private method CreateWordArray().
    /// </summary>
    internal class DocumentObject
    {
        public static List<DocumentObject> docObj = new List<DocumentObject>();
        private static int counter = 0;
        private char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';', '\n', '\r', '‘', '’', '(', ')', '?' };

        public DocumentObject(string text)
        {
            counter++;
            Id = counter;
            Text = text;
            CreateWordArray(Text);
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string[] WordsInText { get; set; }

        private void CreateWordArray(string text)
        {
            WordsInText = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}