using WordSearcher.DataObjects;

namespace WordSearcher.DataStructure
{
    /// <summary>
    /// 
    /// </summary>
    internal class Node
    {
        public Node(SearchResult sr)
        {
            this.Result = sr;
        }

        public Node Left { get; set; }
        public SearchResult Result { get; set; }
        public Node Right { get; set; }
    }
}

        
