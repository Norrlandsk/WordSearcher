namespace WordSearcher.DataStructure
{
    using WordSearcher.DataObjects;

    /// <summary>
    /// Class for creating nodes in the tree class.
    /// Node is populated with a search result object.
    /// </summary>
    internal class Node
    {
        public Node(SearchResult searchResult)
        {
            Result = searchResult;
        }

        public Node Left { get; set; }
        public SearchResult Result { get; set; }
        public Node Right { get; set; }
    }
}