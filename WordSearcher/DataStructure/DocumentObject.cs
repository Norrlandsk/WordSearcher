namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DocumentObject
    {
        private static int counter = 0;

        private int _id;
        private string _text;

        public DocumentObject(string text)
        {
            //this.Id = System.Threading.Interlocked.Increment(ref counter);
            counter++;
            this._id = counter;
            _text = text;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        //public static int SetID()
        //{
        //    _count++;
        //    return _id = _count;
        //}
    }
}