namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;

    public class DocumentObject
    {
        public static List<DocumentObject> docObj = new List<DocumentObject>();
        private static int counter = 0;
        private char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';', '\n', '\r', '‘', '’', '(', ')', '?' };

        public DocumentObject(string text)
        {
            //this.Id = System.Threading.Interlocked.Increment(ref counter);
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