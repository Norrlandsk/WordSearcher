using System;

namespace WordSearcher.DataStructure
{
    internal class Tree
    {
        private Node _root;

        public Tree()
        {
            _root = null;
        }

        public void Insert(SearchResult sr)
        {
            if (_root == null)
            {
                _root = new Node(sr);
                return;
            }
            else
            {
                InsertRec(_root, new Node(sr));
            }
        }

        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
            }

            if (String.Compare(newNode.Result.Word, root.Result.Word, comparisonType: StringComparison.OrdinalIgnoreCase) < 0)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                }
                else
                {
                    InsertRec(root.Left, newNode);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                }
                else
                {
                    InsertRec(root.Right, newNode);
                }
            }
        }

        private void DisplayTree(Node root)
        {
            if (root == null) return;

            DisplayTree(root.Left);
            Console.WriteLine($"Word: {root.Result.Word}");
            foreach (var item in root.Result.WordCount)
            {
                Console.WriteLine($"Document ID: {item.Key}");
                Console.WriteLine($"Count: {item.Value}");
            }
            Console.WriteLine("\n\n");
            DisplayTree(root.Right);
        }

        public void DisplayTree()
        {
            DisplayTree(_root);
        }

    }
}