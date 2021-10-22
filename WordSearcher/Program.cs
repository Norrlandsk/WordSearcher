namespace WordSearcher
{
    using System;
    using WordSearcher.DataStructure;
    using WordSearcher.TextFile;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!!!!!!!");
            FileHandler.ReadFiles();
            FileHandler.AddStringsToList(FileHandler.strList);

            //FileHandler.PrintSearchResult(FileHandler.SearchForWord("species", FileHandler.docObj));

            FileHandler.SearchForWord("species", FileHandler.docObj);
            FileHandler.SearchForWord("xylophone", FileHandler.docObj);
            FileHandler.SearchForWord("be", FileHandler.docObj);
            FileHandler.SearchForWord("and", FileHandler.docObj);
            FileHandler.SearchForWord("the", FileHandler.docObj);
            FileHandler.SearchForWord("species", FileHandler.docObj);
            FileHandler.SearchForWord("natural", FileHandler.docObj);
            FileHandler.SearchForWord("and", FileHandler.docObj);
            FileHandler.tree.DisplayTree();
            FileHandler.PrintXAmount(50);
        }
    }
}