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

            FileHandler.PrintSearchResult(FileHandler.SearchForWord("species", FileHandler.docObj));
        }
    }
}