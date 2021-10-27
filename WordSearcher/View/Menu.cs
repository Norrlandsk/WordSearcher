using System;
using WordSearcher.DataObjects;
using WordSearcher.DataStructure;
using WordSearcher.Query;

namespace WordSearcher.View
{
    /// <summary>
    /// Class for user interface navigation.
    /// </summary>
    internal class Menu
    {
        public void Main(Tree tree)
        {
            bool isRunning = true;
            int userInput;

            while (isRunning)
            {
                Console.WriteLine("[1] Search for a word");
                Console.WriteLine("[2] Print all results");
                Console.WriteLine("[3] Print x amount of words");
                Console.WriteLine("[4] Exit");
                userInput = Utils.ConfirmCorrectInput(4);

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Search.PrintSearchResult(Search.SearchForWord(DocumentObject.docObj));
                        Utils.ContinueAndClear();
                        break;
                    case 2:
                        Console.Clear();
                        tree.DisplayTree();
                        Utils.ContinueAndClear();
                        break;
                    case 3:
                        Console.Clear();
                        Search.PrintXAmount(DocumentObject.docObj);
                        Utils.ContinueAndClear();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}




