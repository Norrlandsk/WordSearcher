namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Node
    {
        //public string Word { get; set; }
        //public int DocumentId { get; set; }
        //public int Count { get; set; }

        public SearchResult Result { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
        }

        public Node(SearchResult sr)
        {
            this.Result = sr;
        }
    }
}