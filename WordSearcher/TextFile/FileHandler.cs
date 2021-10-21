using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WordSearcher.DataStructure;

namespace WordSearcher.TextFile
{
    internal class FileHandler
    {
        public static string textOne;
        public static string textTwo;
        public static string textThree;

        public static List<string> strList = new List<string>();
        public static List<string> strListOne = new List<string>();
        public static List<string> strListTwo = new List<string>();
        public static List<string> strListThree = new List<string>();

        public static string[] wordsOne;
        public static string[] wordsTwo;
        public static string[] wordsThree;
        public static List<string[]> wordsList = new List<string[]>();

        public static Tree tree = CreateTree();

        public static char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';', '\n', '\r', '‘', '’', '(', ')', '?' };

        public static List<DocumentObject> docObj = new List<DocumentObject>();

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            DocumentObject d1 = new DocumentObject(textOne);
            DocumentObject d2 = new DocumentObject(textTwo);
            DocumentObject d3 = new DocumentObject(textThree);

            docObj.Add(d1);
            docObj.Add(d2);
            docObj.Add(d3);

            strList.Add(textOne);
            strList.Add(textTwo);
            strList.Add(textThree);
        }

        public static void AddStringsToList(List<string> str)
        {
            wordsOne = textOne.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            wordsTwo = textTwo.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            wordsThree = textThree.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            //wordsOne = System.Text.RegularExpressions.Regex.Split(textOne, pattern);

            wordsList.Add(wordsOne);
            wordsList.Add(wordsTwo);
            wordsList.Add(wordsThree);
        }

        //public static void SearchForWord2()
        //{
        //    string pattern = $@"\b\w+natural\b";
        //    Regex rgx = new Regex(pattern);
        //    int counter = 0;

        //    foreach (Match match in rgx.Matches(textOne))
        //    {
        //        counter++;
        //    }

        //    Console.WriteLine(counter);
        //}

        public static SearchResult SearchForWord(string userInput, List<DocumentObject> docObj)
        {
            string pattern = string.Format(@"\b{0}\b", userInput);
            int counter = 0;

            Dictionary<int, int> wordCount = new Dictionary<int, int>();

            foreach (var item in docObj)
            {
                counter = Regex.Matches(item.Text, pattern, RegexOptions.IgnoreCase).Count();
                wordCount.Add(item.Id, counter);
            }

            SearchResult sr = new SearchResult(userInput, wordCount);
            InsertSearchResult(sr);
            return sr;
        }

        public static Tree CreateTree()
        {
            Tree tree = new Tree();

            return tree;
        }

        public static void InsertSearchResult(SearchResult sr)
        {
            //var docuId=sr.WordCount.

            tree.Insert(sr);
        }

        //public static void PrintSearchResult(SearchResult sr)
        //{
        //    Console.WriteLine($"Search term: {sr.Word}\n");
        //    foreach (var item in sr.WordCount)
        //    {
        //        Console.WriteLine($"Document ID: {item.Key}");
        //        Console.WriteLine($"Instances of search term: {item.Value}\n");
        //    }
        //}
    }
}