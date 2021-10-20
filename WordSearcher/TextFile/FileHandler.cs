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

        public static char[] delimiterChars = { ' ', ',', '.', ':', '—', '-', ';', '\n', '\r', '‘', '’', '(', ')', '?' };

        public static List<DocumentObject> docObj = new List<DocumentObject>();

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            DocumentObject d1 = new DocumentObject(textOne, DocumentObject.SetID());
            DocumentObject d2 = new DocumentObject(textTwo, DocumentObject.SetID());
            DocumentObject d3 = new DocumentObject(textThree, DocumentObject.SetID());

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

            List<Dictionary<DocumentObject, int>> wordCountDict = new List<Dictionary<DocumentObject, int>>();

            foreach (var item in docObj)
            {
                counter = Regex.Matches(item.Text, pattern, RegexOptions.IgnoreCase).Count();
                Dictionary<DocumentObject, int> wordCount = new Dictionary<DocumentObject, int>();
                wordCount.Add(item, counter);
                wordCountDict.Add(wordCount);
            }

            SearchResult sr = new SearchResult(userInput, wordCountDict);
            return sr;

            //Console.WriteLine(Regex.Matches(textOne, pattern, RegexOptions.IgnoreCase).Count());

            //foreach (var item in wordsOne)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public static void PrintSearchResult(SearchResult sr)
        {
            Console.WriteLine(sr.Word);
            for (int i = 0; i < sr.WordCount.Count; i++)
            {
                Console.WriteLine(sr.WordCount[i]);
            }
        }
    }
}