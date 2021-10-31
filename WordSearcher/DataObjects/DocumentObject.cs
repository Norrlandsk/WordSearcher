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
        public static List<DocumentObject> docObjList = new List<DocumentObject>();
        private static int idCounter = 0;
        private char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';', '\n', '\r', '‘', '’', '(', ')', '?', '!' };

        public DocumentObject(string text)
        {
            idCounter++;
            Id = idCounter;
            Text = text;
            CreateTextSplitArr(Text);
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string[] TextSplitArr { get; set; }

        private void CreateTextSplitArr(string text)
        {
            TextSplitArr = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}