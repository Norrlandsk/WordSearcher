namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DocumentObject
    {
        private int _id;
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

        public void SetID()
        {
            int count = 0;
            count++;
            _id = count;
        }
    }
}