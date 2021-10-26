using System;
using WordSearcher.DataObjects;
using WordSearcher.DataStructure;
using WordSearcher.Query;

namespace WordSearcher.View
{
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
                        Search.PrintSearchResult(Search.SearchForWord(DocumentObject.docObj));
                        break;
                    case 2:
                        tree.DisplayTree();
                        break;
                    case 3:
                        Search.PrintXAmount(DocumentObject.docObj);
                        break;
                    case 4:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}




