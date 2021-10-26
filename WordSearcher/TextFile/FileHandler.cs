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
        public static List<string> strList = new List<string>();
        

        //public static Tree tree = CreateTree();

       

        //public static List<DocumentObject> docObj = new List<DocumentObject>();

        public static void ReadFiles()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string textOne = File.ReadAllText(Path.Combine(docPath, "Text_1.txt"));
            string textTwo = File.ReadAllText(Path.Combine(docPath, "Text_2.txt"));
            string textThree = File.ReadAllText(Path.Combine(docPath, "Text_3.txt"));

            strList.Add(textOne);
            strList.Add(textTwo);
            strList.Add(textThree);
        }
        public static void CreateDocumentObject(List<string> textList)
        {
            foreach (var item in textList)
            {
                DocumentObject document = new DocumentObject(item);
                DocumentObject.docObj.Add(document);
            }
        }
        public static void PrintXAmount(int userInput, List<DocumentObject> docObj)
        {
            foreach (var item in docObj)
            {
                Array.Sort(item.WordsInText);
                string[] singleWords = item.WordsInText.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
                Console.WriteLine($"\nDocument ID: { item.Id }");

                for (int i = 0; i < userInput; i++)
                {
                    Console.WriteLine(singleWords[i]);
                    
                }
            }
        }
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
            var orderedWordCount = wordCount.OrderByDescending(c => c.Value);

            SearchResult sr = new SearchResult(userInput, orderedWordCount);
            InsertSearchResult(sr);
            return sr;
        }
        //public static Tree CreateTree()
        //{
        //    Tree tree = new Tree();

        //    return tree;
        //}

        public static void InsertSearchResult(SearchResult sr)
        {
            tree.Insert(sr);
        }
    }
}

        







            






        



            


        

