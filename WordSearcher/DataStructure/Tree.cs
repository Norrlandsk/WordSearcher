using System;
using WordSearcher.DataObjects;

namespace WordSearcher.DataStructure
{
    /// <summary>
    /// Abstract binary data structure for saving search results.
    /// </summary>
    internal class Tree
    {
        /// <summary>
        /// The starting point of the tree.
        /// </summary>
        private Node _root;

        /// <summary>
        /// Constructor that initializes the root node as null.
        /// </summary>
        public Tree()
        {
            _root = null;
        }

        /// <summary>
        /// Method for creating a new node and populating it with a search result object.
        /// If the root node is null, the new node becomes the root.
        /// Otherwise a recursive insertion method is called using the new node as the parameter.
        /// </summary>
        public void Insert(SearchResult sr)
        {
            if (_root == null)
            {
                _root = new Node(sr);
            }
            else
            {
                InsertChild(_root, new Node(sr));
            }
        }

        /// <summary>
        /// Method for deciding where to insert the new node.
        /// </summary>
        private void InsertChild(Node root, Node newNode)
        {
            if (root == null) // If the root node is null.
            {
                root = newNode; // Insert the new node as the root node.
            }

            // If the new node's value < the current root node.
            if (String.Compare(newNode.Result.Word, root.Result.Word, comparisonType: StringComparison.OrdinalIgnoreCase) < 0)
            {
                if (root.Left == null) // If the left child position is empty.
                {
                    root.Left = newNode; // Insert the new node.
                }
                else // If the left child position is occupied.
                {
                    InsertChild(root.Left, newNode); // Recursively call the method again, now with the left child as the root node.
                }
            }
            else // If the new node's value > the current root node.
            {
                if (root.Right == null) // If the right child position is empty.
                {
                    root.Right = newNode; // Insert the new node.
                }
                else // If the right child position is occupied.
                {
                    InsertChild(root.Right, newNode); // Recursively call the method again, now with the right child as the root node.
                }
            }
        }

        /// <summary>
        /// Method for recursivley printing out all the nodes in the tree in an ascending order.
        /// From the root node the method via recursion travels down the left postion of each node until root == null is true.
        /// Then it continues with the previous method call on the stack and executes it, IE prints the current node's information.
        /// Afterwards the current node's right position is passed to the method and previous steps are executed again untill root == null is true.
        /// These steps are executed on all nodes in the tree.
        /// </summary>
        private void PrintTree(Node root)
        {
            if (root == null) return;

            PrintTree(root.Left);
            Console.WriteLine($"Word: {root.Result.Word}");
            foreach (var item in root.Result.WordCount)
            {
                Console.WriteLine($"Document ID: {item.Key}");
                Console.WriteLine($"Count: {item.Value}");
            }
            Console.WriteLine("\n\n");
            PrintTree(root.Right);
        }

        /// <summary>
        /// A public method for retrieving the private field _root.
        /// If _root is not null, passes the _root node to the private PrintTree().
        /// </summary>
        public void PrintTree()
        {
            if (_root == null)
            {
                Console.Clear();
                Console.WriteLine("No previous searches has been done");
                return;
            }
            PrintTree(_root);
        }

    }
}