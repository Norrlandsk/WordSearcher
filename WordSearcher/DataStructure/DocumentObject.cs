namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DocumentObject
    {
        private static int _id;
        private string _text;

        public DocumentObject(string text, int id)
        {
            _id = id;
            _text = text;
        }

        public int Id
        {
            get => _id;

            set => SetID();
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public static int SetID()
        {
            int count = 0;
            count++;
            return _id = count;
        }
    }
}